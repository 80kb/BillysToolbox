using BillysToolbox.Editors;
using kartlib.Serial;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BillysToolbox.Tools.ImageScaler
{
    public partial class ImageScalerForm : Form
    {
        List<Image> Images;
        List<string> ImageNames;
        List<Image> ScaledImages;

        public ImageScalerForm()
        {
            Images = new List<Image>();
            ImageNames = new List<string>();
            ScaledImages = new List<Image>();

            InitializeComponent();
        }

        private void populateList()
        {
            listBox1.Items.Clear();

            for (int i = 0; i < Images.Count; i++)
            {
                listBox1.Items.Add(ImageNames[i]);
            }
        }

        private void scaleImages()
        {
            foreach (Image img in Images)
            {
                ScaledImages.Add(scaleImage(img));
            }
        }

        private Bitmap scaleImage(Image image)
        {
            int newHeight = (int)Math.Pow(2, Math.Ceiling(Math.Log2(image.Height)));
            int newWidth = (int)Math.Pow(2, Math.Ceiling(Math.Log2(image.Width)));

            double scaleFactor = 1.0;
            int MaxPowerOfTwo = 512;
            if (newWidth > MaxPowerOfTwo || newHeight > MaxPowerOfTwo)
            {
                scaleFactor = Math.Min((double)MaxPowerOfTwo / newWidth, (double)MaxPowerOfTwo / newHeight);
            }

            int finalWidth = (int)(newWidth * scaleFactor);
            int finalHeight = (int)(newHeight * scaleFactor);

            return ResizeImage(image, finalWidth, finalHeight);
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void importTexturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Images.Clear();
            ImageNames.Clear();
            ScaledImages.Clear();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Image Files(*.png; *.jpg)|*.png;*.jpg|All files(*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in ofd.FileNames)
                {
                    Images.Add(Image.FromFile(filename));
                    ImageNames.Add(Path.GetFileName(filename));
                }

                populateList();
                scaleImages();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            textBox1.Text = Images[idx].Width.ToString();
            textBox2.Text = Images[idx].Height.ToString();

            textBox4.Text = ScaledImages[idx].Width.ToString();
            textBox3.Text = ScaledImages[idx].Height.ToString();

            pictureBox1.BackgroundImage = ScaledImages[idx];
        }

        private void exportTexturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                for (int i = 0; i < Images.Count; i++)
                {
                    string path = Path.Combine(dialog.FileName, ImageNames[i]);
                    if (File.Exists(path))
                    {
                        MessageBox.Show("Export folder must be empty!", "Directory full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    ScaledImages[i].Save(path);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int X = Convert.ToInt32(textBox4.Text);
                int Y = ScaledImages[listBox1.SelectedIndex].Height;

                ScaledImages[listBox1.SelectedIndex] = ResizeImage(ScaledImages[listBox1.SelectedIndex], X, Y);
            }
            catch
            {
                return;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int Y = Convert.ToInt32(textBox3.Text);
                int X = ScaledImages[listBox1.SelectedIndex].Width;

                ScaledImages[listBox1.SelectedIndex] = ResizeImage(ScaledImages[listBox1.SelectedIndex], X, Y);
            }
            catch
            {
                return;
            }
        }
    }
}
