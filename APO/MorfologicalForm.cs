using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;

namespace APO
{
    public partial class MorfologicalForm : Form
    {
        public MorfologicalForm(Image img)
        {
            InitializeComponent();
            pictureBox2.Image = img;
        }

        string fileName = "MorfOperationImage";
        private void buttonApply_Click(object sender, EventArgs e)
        {
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Bgr, byte> dst = new Image<Bgr, byte>(src.Width, src.Height);
            Bitmap bmp;

            string operation = comboBoxOperation.SelectedItem.ToString();
            string kernelType = comboBoxKernelType.SelectedItem.ToString();
            string borderType = comboBoxBorderType.SelectedItem.ToString();
            string Kernelsize = comboBoxKernelSize.SelectedItem.ToString();

            int size = Int32.Parse(Kernelsize);


            if (operation == "Erode")
            {
                if (kernelType == "Cross")
                {
                    var kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Cross, new Size(size, size), new Point(-1, -1));
                    if (borderType == "Reflect")
                    {
                        CvInvoke.Erode(src, dst, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Reflect, new MCvScalar(1.0));
                    }
                    else if (borderType == "Replicate")
                    {
                        CvInvoke.Erode(src, dst, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar(1.0));
                    }
                    else //default
                    {
                        CvInvoke.Erode(src, dst, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0));
                    }
                }
                else //ellipse
                {
                    var kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Ellipse, new Size(size, size), new Point(-1, -1));
                    if (borderType == "Reflect")
                    {
                        CvInvoke.Erode(src, dst, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Reflect, new MCvScalar(1.0));
                    }
                    else if (borderType == "Replicate")
                    {
                        CvInvoke.Erode(src, dst, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar(1.0));
                    }
                    else //default
                    {
                        CvInvoke.Erode(src, dst, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0));
                    }
                }
            }
            else if (operation == "Dilate")
            {
                if (kernelType == "Cross")
                {
                    var kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Cross, new Size(size, size), new Point(-1, -1));
                    if (borderType == "Reflect")
                    {
                        CvInvoke.Dilate(src, dst, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Reflect, new MCvScalar(1.0));
                    }
                    else if (borderType == "Replicate")
                    {
                        CvInvoke.Dilate(src, dst, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar(1.0));
                    }
                    else //default
                    {
                        CvInvoke.Dilate(src, dst, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0));
                    }
                }
                else //ellipse
                {
                    var kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Ellipse, new Size(size, size), new Point(-1, -1));
                    if (borderType == "Reflect")
                    {
                        CvInvoke.Dilate(src, dst, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Reflect, new MCvScalar(1.0));
                    }
                    else if (borderType == "Replicate")
                    {
                        CvInvoke.Dilate(src, dst, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar(1.0));
                    }
                    else //default
                    {
                        CvInvoke.Dilate(src, dst, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0));
                    }
                }
            }
            else if (operation == "Open")
            {
                if (kernelType == "Cross")
                {
                    var kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Cross, new Size(size, size), new Point(-1, -1));
                    if (borderType == "Reflect")
                    {
                        CvInvoke.MorphologyEx(src, dst, Emgu.CV.CvEnum.MorphOp.Open, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Reflect, new MCvScalar(1.0));
                    }
                    else if (borderType == "Replicate")
                    {
                        CvInvoke.MorphologyEx(src, dst, Emgu.CV.CvEnum.MorphOp.Open, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar(1.0));
                    }
                    else //default
                    {
                        CvInvoke.MorphologyEx(src, dst, Emgu.CV.CvEnum.MorphOp.Open, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0));
                    }
                }
                else //ellipse
                {
                    var kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Ellipse, new Size(size, size), new Point(-1, -1));
                    if (borderType == "Reflect")
                    {
                        CvInvoke.MorphologyEx(src, dst, Emgu.CV.CvEnum.MorphOp.Open, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Reflect, new MCvScalar(1.0));
                    }
                    else if (borderType == "Replicate")
                    {
                        CvInvoke.MorphologyEx(src, dst, Emgu.CV.CvEnum.MorphOp.Open, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar(1.0));
                    }
                    else //default
                    {
                        CvInvoke.MorphologyEx(src, dst, Emgu.CV.CvEnum.MorphOp.Open, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0));
                    }
                }
            }
            else //close
            {
                if (kernelType == "Cross")
                {
                    var kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Cross, new Size(size, size), new Point(-1, -1));
                    if (borderType == "Reflect")
                    {
                        CvInvoke.MorphologyEx(src, dst, Emgu.CV.CvEnum.MorphOp.Close, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Reflect, new MCvScalar(1.0));
                    }
                    else if (borderType == "Replicate")
                    {
                        CvInvoke.MorphologyEx(src, dst, Emgu.CV.CvEnum.MorphOp.Close, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar(1.0));
                    }
                    else //default
                    {
                        CvInvoke.MorphologyEx(src, dst, Emgu.CV.CvEnum.MorphOp.Close, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0));
                    }
                }
                else //ellipse
                {
                    var kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Ellipse, new Size(size, size), new Point(-1, -1));
                    if (borderType == "Reflect")
                    {
                        CvInvoke.MorphologyEx(src, dst, Emgu.CV.CvEnum.MorphOp.Close, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Reflect, new MCvScalar(1.0));
                    }
                    else if (borderType == "Replicate")
                    {
                        CvInvoke.MorphologyEx(src, dst, Emgu.CV.CvEnum.MorphOp.Close, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar(1.0));
                    }
                    else //default
                    {
                        CvInvoke.MorphologyEx(src, dst, Emgu.CV.CvEnum.MorphOp.Close, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0));
                    }
                }
            }

            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox2.Image = bmp;
            this.Hide();
        }
    }
}
