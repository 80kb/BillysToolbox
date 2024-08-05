using kartlib.Serial;
using System.Data;

namespace BillysToolbox.Editors
{
    public partial class KCLEditorForm : Form, IEditor
    {
        public class KCLObjectGroup
        {
            public string _name { get; set; }
            public int _flag { get; set; }
            public int _variant { get; set; }
            public int _blight { get; set; }
            public int _depth { get; set; }
            public int _effect { get; set; }

            public KCLObjectGroup(string name, int flag, int variant, int blight, int depth, int effect)
            {
                _name = name;
                _flag = flag;
                _variant = variant;
                _blight = blight;
                _depth = depth;
                _effect = effect;
            }
        }

        private DataTable Table;
        private List<KCLObjectGroup> KCLObjects;
        private bool UpdateDebounce = true;
        private OBJ? Obj;
        private KCL Kcl;
        private U8? ParentInstance;

        public KCLEditorForm(KCL kcl)
        {
            InitializeComponent();

            // Initialize mesh dataGrid
            this.Table = new DataTable();
            this.Table.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("Use", typeof(bool)),
                new DataColumn("Group Name", typeof(string)),
                new DataColumn("Flag", typeof(string))
            });
            this.Table.Columns[1].ReadOnly = true;
            this.dataGridView.DataSource = this.Table;
            this.dataGridView.Columns[0].Width = 35;
            this.dataGridView.Columns[1].Width = 350;
            foreach (DataGridViewColumn column in this.dataGridView.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            // Initialize Flag ComboBox
            foreach (KClFlagCalculator._KCLFlag k in KClFlagCalculator.KCLFlags)
                this.flagComboBox.Items.Add(k._flag);

            // Set value defaults
            this.blightComboBox.SelectedIndex = 0;
            this.depthComboBox.SelectedIndex = 0;
            this.flagComboBox.SelectedIndex = 0;
            PopulateVariants(this.flagComboBox.SelectedIndex);
            this.KCLObjects = new List<KCLObjectGroup>();

            this.Kcl = kcl;
            ParseOBJ(kcl.ToOBJ(), true);
        }

        public KCLEditorForm(KCL kcl, U8? parentInstance)
        {
            ParentInstance = parentInstance;
            InitializeComponent();

            // Initialize mesh dataGrid
            this.Table = new DataTable();
            this.Table.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("Use", typeof(bool)),
                new DataColumn("Group Name", typeof(string)),
                new DataColumn("Flag", typeof(string))
            });
            this.Table.Columns[1].ReadOnly = true;
            this.dataGridView.DataSource = this.Table;
            this.dataGridView.Columns[0].Width = 35;
            this.dataGridView.Columns[1].Width = 350;
            foreach (DataGridViewColumn column in this.dataGridView.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            // Initialize Flag ComboBox
            foreach (KClFlagCalculator._KCLFlag k in KClFlagCalculator.KCLFlags)
                this.flagComboBox.Items.Add(k._flag);

            // Set value defaults
            this.blightComboBox.SelectedIndex = 0;
            this.depthComboBox.SelectedIndex = 0;
            this.flagComboBox.SelectedIndex = 0;
            PopulateVariants(this.flagComboBox.SelectedIndex);
            this.KCLObjects = new List<KCLObjectGroup>();

            this.Kcl = kcl;
            ParseOBJ(kcl.ToOBJ(), true);
        }

        public void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = Path.GetFileNameWithoutExtension(Kcl.Filename);
            sfd.Filter = "KCL Files (*.kcl)|*.kcl";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                KeyValuePair<ushort, bool>[] CollisionFlags = SaveCurrentFile();
                KCL final = FileConverter.OBJToKCL(this.Obj, CollisionFlags);
                byte[] buffer = final.Write();
                File.WriteAllBytes(sfd.FileName, buffer);
            }
        }

        public void Save()
        {
            if (ParentInstance != null)
            {
                int index = ParentInstance.FindIndexFromName(Kcl.Filename);
                if (index > 0)
                {
                    KeyValuePair<ushort, bool>[] CollisionFlags = SaveCurrentFile();
                    KCL final = FileConverter.OBJToKCL(this.Obj, CollisionFlags);
                    ParentInstance.Nodes[index].Data = final.Write();
                }
            }
            else if (!File.Exists(Kcl.Filename))
            {
                SaveAs();
                return;
            }
            else
            {
                KeyValuePair<ushort, bool>[] CollisionFlags = SaveCurrentFile();
                KCL final = FileConverter.OBJToKCL(this.Obj, CollisionFlags);
                byte[] buffer = final.Write();
                File.WriteAllBytes(Kcl.Filename, buffer);
            }
        }

        //----- Helper Methods -----

        private void PopulateVariants(int index)
        {
            this.variantComboBox.Items.Clear();
            this.variantComboBox.Items.AddRange(KClFlagCalculator.KCLFlags[index]._variants);
            this.variantComboBox.SelectedIndex = 0;
        }

        private void PopulateFromSelectedMesh(int index)
        {
            this.flagComboBox.SelectedIndex = this.KCLObjects[index]._flag;
            this.variantComboBox.SelectedIndex = this.KCLObjects[index]._variant;
            this.blightComboBox.SelectedIndex = this.KCLObjects[index]._blight;
            this.depthComboBox.SelectedIndex = this.KCLObjects[index]._depth;

            this.softWallCheckBox.Checked = ((this.KCLObjects[index]._effect & 0x4) >> 2) > 0;
            this.rejectCheckBox.Checked = ((this.KCLObjects[index]._effect & 0x2) >> 1) > 0;
            this.trickCheckBox.Checked = (this.KCLObjects[index]._effect & 0x1) > 0;
        }

        private void AddKCLObjectToTable(KCLObjectGroup kclObject)
        {
            ushort flag = KClFlagCalculator.CalculateFlag(
                kclObject._flag,
                kclObject._variant,
                kclObject._blight,
                kclObject._depth,
                kclObject._effect);
            this.Table.Rows.Add(true, kclObject._name, flag.ToString("X4"));
        }

        private void UpdateObject(int index)
        {
            KCLObjectGroup current = this.KCLObjects[index];
            current._flag = this.flagComboBox.SelectedIndex;
            current._variant = this.variantComboBox.SelectedIndex;
            current._blight = this.blightComboBox.SelectedIndex;
            current._depth = this.depthComboBox.SelectedIndex;

            int eX = this.softWallCheckBox.Checked ? 1 : 0;
            int eY = this.rejectCheckBox.Checked ? 1 : 0;
            int eZ = this.trickCheckBox.Checked ? 1 : 0;
            current._effect = (eX << 2) | (eY << 1) | eZ;

            this.Table.Rows[index][2] = KClFlagCalculator.CalculateFlag(current._flag, current._variant, current._blight, current._depth, current._effect).ToString("X4");
        }

        private void LowerWalls()
        {
            for (int i = 0; i < this.Obj?.Groups.Count; i++)
            {
                ushort currentFlag = Convert.ToUInt16((string)this.Table.Rows[i][2], 16);
                int baseFlagValue = KClFlagCalculator.GetFlag(currentFlag);
                if (baseFlagValue == 0x0C || baseFlagValue == 0x0F)
                {
                    foreach (OBJ._Face face in this.Obj.Groups[i].Faces)
                    {
                        for (int j = 0; j < face.Vertices.Length; j++)
                        {
                            this.Obj.Vertices[(int)face.Vertices[j]] = new Vector3f
                            (
                                this.Obj.Vertices[(int)face.Vertices[j]].X,
                                this.Obj.Vertices[(int)face.Vertices[j]].Y - 50,
                                this.Obj.Vertices[(int)face.Vertices[j]].Z
                            );
                        }
                    }
                }
            }
        }

        private KeyValuePair<ushort, bool>[] SaveCurrentFile()
        {
            if (this.Obj == null)
                return null;

            this.dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (this.lowerWallsToolStripMenuItem.Checked)
                LowerWalls();

            KeyValuePair<ushort, bool>[] CollisionFlags = new KeyValuePair<ushort, bool>[this.dataGridView.Rows.Count];
            for (int i = 0; i < this.Table.Rows.Count; i++)
            {
                CollisionFlags[i] = new KeyValuePair<ushort, bool>(
                    Convert.ToUInt16((string)this.Table.Rows[i][2], 16),
                    (bool)this.Table.Rows[i][0]
                );
            }

            return CollisionFlags;
        }

        //----- Public Methods -----

        public void ParseOBJ(OBJ obj, bool fromKCL = false)
        {
            this.Obj = obj;
            this.KCLObjects.Clear();
            this.Table.Clear();

            // Add underlying data
            foreach (OBJ._Group group in obj.Groups)
            {
                KCLObjectGroup? kclObject;
                if (fromKCL)
                {
                    ushort flag = ushort.Parse(group.Name, System.Globalization.NumberStyles.HexNumber);
                    string name = KClFlagCalculator.FlagString(flag);
                    kclObject = new KCLObjectGroup(
                        name,
                        KClFlagCalculator.GetFlag(flag),
                        KClFlagCalculator.GetVariant(flag),
                        KClFlagCalculator.GetBlight(flag),
                        KClFlagCalculator.GetDepth(flag),
                        KClFlagCalculator.GetEffect(flag)
                    );
                }
                else
                {
                    string name = group.Name;
                    kclObject = new KCLObjectGroup(name, 0, 0, 0, 0, 0);
                }

                if (kclObject != null)
                {
                    this.KCLObjects.Add(kclObject);
                    AddKCLObjectToTable(kclObject);
                }
            }
        }

        //----- UI Methods -----

        private void flagComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateVariants(this.flagComboBox.SelectedIndex);

            if (this.dataGridView.SelectedRows.Count > 0 && this.UpdateDebounce)
                UpdateObject(this.dataGridView.SelectedRows[0].Index);
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.UpdateDebounce = false;

            if (this.dataGridView.SelectedRows.Count > 0)
                PopulateFromSelectedMesh(this.dataGridView.SelectedRows[0].Index);

            this.UpdateDebounce = true;
        }

        private void variantComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count > 0 && this.UpdateDebounce)
                UpdateObject(this.dataGridView.SelectedRows[0].Index);
        }

        private void blightComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count > 0 && this.UpdateDebounce)
                UpdateObject(this.dataGridView.SelectedRows[0].Index);
        }

        private void depthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count > 0 && this.UpdateDebounce)
                UpdateObject(this.dataGridView.SelectedRows[0].Index);
        }

        private void trickCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count > 0 && this.UpdateDebounce)
                UpdateObject(this.dataGridView.SelectedRows[0].Index);
        }

        private void rejectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count > 0 && this.UpdateDebounce)
                UpdateObject(this.dataGridView.SelectedRows[0].Index);
        }

        private void softWallCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dataGridView.SelectedRows.Count > 0 && this.UpdateDebounce)
                UpdateObject(this.dataGridView.SelectedRows[0].Index);
        }

        private void KCLEditor_Deactivate(object sender, EventArgs e)
        {
            this.menuStrip1.Visible = false;
        }

        private void KCLEditor_Activated(object sender, EventArgs e)
        {
            this.menuStrip1.Visible = true;
        }

        private void importOBJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportOBJ importOBJ = new ImportOBJ();
            if (importOBJ.ShowDialog() == DialogResult.OK)
            {
                if (importOBJ.OBJ != null)
                    ParseOBJ(importOBJ.OBJ);
            }
        }
    }
}
