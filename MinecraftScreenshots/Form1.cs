using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MinecraftScreenshots
{
    public partial class Form1 : Form
    {
        private string folderPath = @"C:\Users\beau\curseforge\minecraft\Instances\Better MC [FORGE] - BMC4\screenshots";
        private string[] imageFiles;
        private int index = 0;

        public Form1()
        {
            InitializeComponent();

            LoadImages();

            if (imageFiles.Length > 0)
            {
                DisplayImage(0);
            }

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void LoadImages()
        {
            imageFiles = Directory.GetFiles(folderPath)
                .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("png") || file.ToLower().EndsWith("bmp"))
                .ToArray();
        }

        private void DisplayImage(int index)
        {
            if (index >= 0 && index < imageFiles.Length)
            {
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = Image.FromFile(imageFiles[index]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                index = (index + 1) % imageFiles.Length;
                DisplayImage(index);

            }
            else if (e.KeyCode == Keys.Left)
            {
                index = (index - 1) % imageFiles.Length;
                DisplayImage(index);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Width = 200;
        }
    }
}
