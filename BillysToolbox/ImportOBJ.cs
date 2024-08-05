using kartlib.Serial;
using BillysToolbox.Editors;

namespace BillysToolbox
{
    public partial class ImportOBJ : Form
    {
        public OBJ? OBJ;

        public ImportOBJ()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "OBJ files (*.obj)|*.obj|KCL files (*.kcl)|*.kcl";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = ofd.FileName;
                if(Path.GetExtension(ofd.FileName).ToLower() == ".kcl")
                {
                    byte[] buffer = File.ReadAllBytes(ofd.FileName);
                    this.OBJ = FileConverter.KCLToOBJ(new KCL(buffer, ofd.FileName));
                }
                else
                    this.OBJ = new OBJ(File.ReadAllBytes(ofd.FileName), ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
