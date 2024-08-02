using kartlib.Serial;

namespace BillysToolbox.Editors
{
    public partial class BLIGHTEditorForm : Form, IEditor
    {
        private BLIGHT? FileInstance;
        private U8? ParentInstance;

        public BLIGHTEditorForm(BLIGHT fileinstance)
        {
            FileInstance = fileinstance;
            InitializeComponent();
            PopulateUI();
        }

        public BLIGHTEditorForm(BLIGHT fileinstance, U8? parentInstance)
        {
            FileInstance = fileinstance;
            ParentInstance = parentInstance;
            InitializeComponent();
            PopulateUI();
        }

        public void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = Path.GetFileNameWithoutExtension(FileInstance.Filename);
            sfd.Filter = "BLIGHT Files (*.blight)|*.blight";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                byte[] buffer = FileInstance.Write();
                File.WriteAllBytes(sfd.FileName, buffer);
            }
        }

        public void Save()
        {
            if (ParentInstance != null)
            {
                int index = ParentInstance.FindIndexFromName(FileInstance.Filename);
                if (index > 0)
                {
                    ParentInstance.Nodes[index].Data = FileInstance.Write();
                }
            }
            else if (!File.Exists(FileInstance.Filename))
            {
                SaveAs();
                return;
            }
            else
            {
                byte[] buffer = FileInstance.Write();
                File.WriteAllBytes(FileInstance.Filename, buffer);
            }
        }

        private void PopulateUI()
        {
            if (FileInstance == null) return;

            // clear ui first
            lightObjectListBox.Items.Clear();
            ambientLightListBox.Items.Clear();
            lightObjectPropertyGrid.SelectedObject = null;
            ambientLightPropertyGrid.SelectedObject = null;

            // light objects
            for (int i = 0; i < FileInstance.LightObjects.Count; i++)
                lightObjectListBox.Items.Add("Light Object " + i);
            lightObjectListBox.SelectedIndex = 0;
            lightObjectPropertyGrid.SelectedObject = FileInstance.LightObjects[lightObjectListBox.SelectedIndex];

            // ambient lights
            for (int i = 0; i < FileInstance.AmbientLights.Count; i++)
                ambientLightListBox.Items.Add("Ambient Light " + i);
            ambientLightListBox.SelectedIndex = 0;
            ambientLightPropertyGrid.SelectedObject = FileInstance.AmbientLights[ambientLightListBox.SelectedIndex];
        }

        private void lightObjectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FileInstance == null) return;
            lightObjectPropertyGrid.SelectedObject = FileInstance.LightObjects[lightObjectListBox.SelectedIndex];
        }

        private void ambientLightListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FileInstance == null) return;
            ambientLightPropertyGrid.SelectedObject = FileInstance.AmbientLights[ambientLightListBox.SelectedIndex];
        }
    }
}
