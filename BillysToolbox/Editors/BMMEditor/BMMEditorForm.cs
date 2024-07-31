using kartlib.Serial;

namespace BillysToolbox.Editors
{
    public partial class BMMEditorForm : Form, IEditor
    {
        BMM FileInstance;
        U8? ParentInstance;

        public BMMEditorForm(BMM fileInstance)
        {
            FileInstance = fileInstance;
            InitializeComponent();
        }

        public BMMEditorForm(BMM fileInstance, U8? parentInstance)
        {
            FileInstance = fileInstance;
            ParentInstance = parentInstance;
            InitializeComponent();
        }

        public void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = Path.GetFileNameWithoutExtension(FileInstance.Filename);
            sfd.Filter = "BMM Files (*.bmm)|*.bmm";

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

        private void BMMEditorForm_Load(object sender, EventArgs e)
        {
            int A = FileInstance.RGBAColor[3];
            int R = FileInstance.RGBAColor[0];
            int G = FileInstance.RGBAColor[1];
            int B = FileInstance.RGBAColor[2];
            panel1.BackColor = Color.FromArgb(A, R, G, B);

            textBox2.Text = FileInstance.ScaleS.ToString();
            textBox1.Text = FileInstance.TranslationS.ToString();
            textBox3.Text = FileInstance.ScaleT.ToString();
            textBox4.Text = FileInstance.TranslationT.ToString();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;

                byte A = panel1.BackColor.A;
                byte R = panel1.BackColor.R;
                byte G = panel1.BackColor.G;
                byte B = panel1.BackColor.B;
                FileInstance.RGBAColor = new byte[] { R, G, B, A };
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FileInstance.TranslationS = Convert.ToSingle(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Invalid data entered!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FileInstance.ScaleS = Convert.ToSingle(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Invalid data entered!");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FileInstance.TranslationT = Convert.ToSingle(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Invalid data entered!");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FileInstance.ScaleT = Convert.ToSingle(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("Invalid data entered!");
            }
        }
    }
}
