using System;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO
{
    public partial class LogicOperationForm : Form
    {
        public LogicOperationForm()
        {
            InitializeComponent();
        }
        string ImagePath1;
        string ImagePath2;

        private void buttonOpenImg1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files(*.BMP;*.PNG;*.JPG|*.BMP;*.PNG;*.JPG|All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBoxImg1.Image = new Bitmap(ofd.FileName);
                    ImagePath1 = ofd.FileName;
                }
                catch
                {
                    MessageBox.Show("Can not open this file...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonOpenImg2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files(*.BMP;*.PNG;*.JPG|*.BMP;*.PNG;*.JPG|All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBoxImg2.Image = new Bitmap(ofd.FileName);
                    ImagePath2 = ofd.FileName;
                }
                catch
                {
                    MessageBox.Show("Can not open this file...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            string operation = (string)comboBoxOperation.SelectedItem;
            Console.WriteLine("{0}",operation);
            var img1 = CvInvoke.Imread(ImagePath1);
            Size size = new Size(img1.Width,img1.Height);
            var img2 = CvInvoke.Imread(ImagePath2);
            var imgResult = img2;
            Bitmap bmp;

            CvInvoke.Resize(img2,img2,size);

            if (operation == "Add")
            {
                CvInvoke.Add(img1, img2, imgResult);
                if (File.Exists(@"TempImages\\" + operation + ".bmp")) { operation += "1"; }
                CvInvoke.Imwrite(@"TempImages\\" + operation + ".bmp", imgResult);
                bmp = new Bitmap(@"TempImages\\" + operation + ".bmp");
                ImageForm imgFrm = new ImageForm();
                imgFrm.pictureBox2.Image = bmp;
                imgFrm.Show();
                operation = null;
            }
            else if (operation == "Blending")
            {
                double alpha = 0.5;
                double beta = 0.5;
                double gamma = -100;
                CvInvoke.AddWeighted(img1, alpha, img2, beta, gamma, imgResult);
                if (File.Exists(@"TempImages\\" + operation + ".bmp")) { operation += "1"; }
                CvInvoke.Imwrite(@"TempImages\\" + operation + ".bmp", imgResult);
                bmp = new Bitmap(@"TempImages\\" + operation + ".bmp");
                ImageForm imgFrm = new ImageForm();
                imgFrm.pictureBox2.Image = bmp;
                imgFrm.Show();
                operation = null;
            }
            else if (operation == "And")
            {
                CvInvoke.BitwiseAnd(img1, img2, imgResult);
                if (File.Exists(@"TempImages\\" + operation + ".bmp")) { operation += "1"; }
                CvInvoke.Imwrite(@"TempImages\\" + operation + ".bmp", imgResult);
                bmp = new Bitmap(@"TempImages\\" + operation + ".bmp");
                ImageForm imgFrm = new ImageForm();
                imgFrm.pictureBox2.Image = bmp;
                imgFrm.Show();
                operation = null;
            }
            else if (operation == "Or")
            {
                CvInvoke.BitwiseOr(img1, img2, imgResult);
                if (File.Exists(@"TempImages\\" + operation + ".bmp")) { operation += "1"; }
                CvInvoke.Imwrite(@"TempImages\\" + operation + ".bmp", imgResult);
                bmp = new Bitmap(@"TempImages\\" + operation + ".bmp");
                ImageForm imgFrm = new ImageForm();
                imgFrm.pictureBox2.Image = bmp;
                imgFrm.Show();
                operation = null;
            }
            else if (operation == "Xor")
            {
                CvInvoke.BitwiseXor(img1, img2, imgResult);
                if (File.Exists(@"TempImages\\" + operation + ".bmp")) { operation += "1"; }
                CvInvoke.Imwrite(@"TempImages\\" + operation + ".bmp", imgResult);
                bmp = new Bitmap(@"TempImages\\" + operation + ".bmp");
                ImageForm imgFrm = new ImageForm();
                imgFrm.pictureBox2.Image = bmp;
                imgFrm.Show();
                operation = null;
            }
            else if (operation == "Not")
            {
                CvInvoke.BitwiseNot(img1, img2);
                CvInvoke.HConcat(img1, img2, imgResult);
                if (File.Exists(@"TempImages\\" + operation + ".bmp")) { operation += "1"; }
                CvInvoke.Imwrite(@"TempImages\\" + operation + ".bmp", imgResult);

                bmp = new Bitmap(@"TempImages\\" + operation + ".bmp");
                ImageForm imgFrm = new ImageForm();
                imgFrm.pictureBox2.Image = bmp;
                imgFrm.Show();
                operation = null;
            }
            else MessageBox.Show("Test","Error");
        }

        private void LogicOperationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
