using System;
using System.IO;
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

namespace APO
{
    public partial class ImageForm : Form
    {

        public bool Grayscale = false;
        public int value = 0;
        string fileName;

        public ImageForm()
        {
            InitializeComponent();
        }
        // ***************************************************************************************
        private void ImageForm_Load(object sender, EventArgs e)
        {
            fileName = Path.GetFileName(Text);
            int i, j;
            Bitmap bmp = new Bitmap(pictureBox2.Image);

            int[] R = new int[256];
            int[] G = new int[256];
            int[] B = new int[256];
            Color GrayTest;
            for (i = 0; i < bmp.Width; ++i)
                for (j = 0; j < bmp.Height; ++j)
                {
                    GrayTest = bmp.GetPixel(i, j); //Wczytanie obrazu szaroodcieniowego obowiązkowo w formacie BMP
                    ++R[GrayTest.R];                // Wczytanie obrazu kolorowego 
                    ++G[GrayTest.G];
                    ++B[GrayTest.B];
                    if ((int)GrayTest.R == (int)GrayTest.G && (int)GrayTest.R == (int)GrayTest.B)
                    {
                        Grayscale = true;
                    }
                    else Grayscale = false;
                }
        }

        public void saveImage(PictureBox pB)
        {
            if (pB.Image != null)
            {
                SaveFileDialog sfd2 = new SaveFileDialog();
                sfd2.Title = "Save image as...";
                sfd2.OverwritePrompt = true;
                sfd2.CheckPathExists = true;
                sfd2.Filter = "Image Files(.BMP)|*.BMP|Image Files(.JPG)|*.JPG|Image Files(.PNG)|*.PNG|All Files(*.*)|*.*";
                sfd2.ShowHelp = true;

                if (sfd2.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pB.Image.Save(sfd2.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Can not save this file...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Oops..Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // zapisz obr/zdj
        // ***************************************************************************************
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage(pictureBox2);
        }

        // ***************************************************************************************
        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.pictureBox2.Image != null)
            {
                try
                {
                    HistogramForm histFrm = new HistogramForm(); // reprezentacja graficzna - histFrm
                    int i, j; // Algorytm tworzenia histogramu wczytanych obrazów monochromatycznych i kolorowych
                    if (Grayscale)
                    {
                        histFrm.pictureBoxRGB.Visible = false;
                        histFrm.chartHistGray.Visible = true;
                        int[] intens = new int[256];
                        Bitmap bmpGray = new Bitmap(pictureBox2.Image);
                        Color intensPixel;
                        for (i = 0; i < bmpGray.Width; ++i)
                            for (j = 0; j < bmpGray.Height; ++j)
                            {
                                intensPixel = bmpGray.GetPixel(i, j);
                                intens[intensPixel.R] += 1;
                            }
                        histFrm.chartHistGray.Series["Series1"].LegendText = "Intensivity of pixels";
                        histFrm.chartHistGray.Series["Series1"].Color = Color.Red;
                        histFrm.chartHistGray.Series["Series1"].Points.Clear();
                        histFrm.chartHistGray.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
                        for (i = 0; i < 256; ++i)
                        {
                            histFrm.chartHistGray.Series["Series1"].Points.AddXY(i, intens[i]);
                        }
                        histFrm.pictureBox3.Image = bmpGray;
                        histFrm.buttonListBlue.Visible = false;
                        histFrm.buttonListRed.Visible = false;
                        histFrm.buttonListGreen.Visible = false;
                        histFrm.Text = "Histogram of " + this.Text;
                    }
                    else
                    {

                        histFrm.StartPosition = FormStartPosition.CenterScreen;
                        histFrm.Text = "Histogram of " + this.Text;
                        Bitmap barChart = null;
                        Bitmap barChartR = null;
                        Bitmap barChartG = null;
                        Bitmap barChartB = null;
                        int width = 768, height = 600;
                        Bitmap bmp = new Bitmap(pictureBox2.Image);
                        barChart = new Bitmap(width, height);
                        barChartR = new Bitmap(width, height);
                        barChartG = new Bitmap(width, height);
                        barChartB = new Bitmap(width, height);
                        int[] R = new int[256];
                        int[] G = new int[256];
                        int[] B = new int[256];

                        Color color;
                        for (i = 0; i < bmp.Width; ++i)
                            for (j = 0; j < bmp.Height; ++j)
                            {
                                color = bmp.GetPixel(i, j);
                                ++R[color.R];
                                ++G[color.G];
                                ++B[color.B];
                            }
                        int max = 0;
                        for (i = 0; i < 256; ++i)
                        {
                            if (R[i] > max)
                                max = R[i];
                            if (G[i] > max)
                                max = G[i];
                            if (B[i] > max)
                                max = B[i];
                        }
                        int min = 0;
                        for (i = 0; i < 256; ++i)
                        {
                            if (R[i] < min)
                                min = R[i];
                        }
                        double point = (double)max / height;

                        for (i = 0; i < width - 3; ++i)
                        {
                            for (j = height - 1; j > height - R[i / 3] / point; --j)
                            {
                                barChart.SetPixel(i, j, Color.Red);
                            }
                            ++i;
                            for (j = height - 1; j > height - G[i / 3] / point; --j)
                            {
                                barChart.SetPixel(i, j, Color.Green);
                            }
                            ++i;
                            for (j = height - 1; j > height - B[i / 3] / point; --j)
                            {
                                barChart.SetPixel(i, j, Color.Blue);
                            }
                        }

                        for (i = 0; i < width - 3; ++i)
                        {
                            for (j = height - 1; j > height - R[i / 3] / point; --j)
                            {
                                barChartR.SetPixel(i, j, Color.Red);
                            }
                            ++i;
                        }

                        for (i = 0; i < width - 3; ++i)
                        {
                            for (j = height - 1; j > height - G[i / 3] / point; --j)
                            {
                                barChartG.SetPixel(i, j, Color.Green);
                            }
                            ++i;
                        }

                        for (i = 0; i < width - 3; ++i)
                        {
                            for (j = height - 1; j > height - B[i / 3] / point; --j)
                            {
                                barChartB.SetPixel(i, j, Color.Blue);
                            }
                            ++i;
                        }
                        histFrm.pictureBox3.Image = bmp;
                        histFrm.pictureBoxRGB.Image = barChart;
                        histFrm.pictureBoxRed.Image = barChartR;
                        histFrm.pictureBoxGreen.Image = barChartG;
                        histFrm.pictureBoxBlue.Image = barChartB;
                    }
                    histFrm.Show();
                }
                catch
                {
                    MessageBox.Show("Ops..Error,please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Open image before...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ***************************************************************************************
        private void profileLineToolStripMenuItem_Click(object sender, EventArgs e)
        {   // Implementacja linii profilu
            Image img = pictureBox2.Image;
            PlotProfileForm plotForm = new PlotProfileForm(img);
            plotForm.Text = this.Text;
            plotForm.Width = pictureBox2.Image.Width + 16;
            plotForm.Height = pictureBox2.Image.Height + 39;
            plotForm.Show();

        }

        // ***************************************************************************************
        private void stretchToolStripMenuItem_Click(object sender, EventArgs e)
        {   // Rozciąganie histogramu
            if (Grayscale)
            {
                int i, j;
                int im_min = 0;
                int im_max = 0;
                Bitmap bmp = new Bitmap(pictureBox2.Image);
                int new_max = 255;
                Bitmap img_stretch = new Bitmap(pictureBox2.Image.Width, pictureBox2.Image.Height);
                int[] Intens = new int[256];

                Color color;
                for (i = 0; i < bmp.Width; ++i)
                    for (j = 0; j < bmp.Height; ++j)
                    {
                        color = bmp.GetPixel(i, j);
                        Intens[color.B] += 1;
                    }

                for (i = 0; i < Intens.Length; ++i)
                {
                    if (Intens[i] > 0) im_max = i;
                }

                for (i = 255; i > -1; --i)
                {
                    if (Intens[i] > 0) im_min = i;
                }

                Color current_pixel;
                for (i = 0; i < bmp.Width; ++i)
                    for (j = 0; j < bmp.Height; ++j)
                    {
                        current_pixel = bmp.GetPixel(i, j);
                        var newPixelValue = ((current_pixel.B - im_min) * new_max) / (im_max - im_min);
                        img_stretch.SetPixel(i, j, Color.FromArgb(newPixelValue, newPixelValue, newPixelValue));
                    }
                pictureBox2.Image = img_stretch;
                pictureBox2.Refresh();
            }
            else MessageBox.Show("Image is not a grayscale!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // GrayScale funkcja
        // ***************************************************************************************
        private void toGrayscaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap originalbmp = new Bitmap(pictureBox2.Image);
            Bitmap newbmp = new Bitmap(originalbmp.Width, originalbmp.Height);

            for (int row = 0; row < originalbmp.Width; row++)
            {
                for (int column = 0; column < originalbmp.Height; column++)
                {
                    Color colorValue = originalbmp.GetPixel(row, column);
                    int averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3;
                    newbmp.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue));
                }
            }
            Grayscale = true;
            pictureBox2.Image = newbmp;
            pictureBox2.Refresh();
        }
        // negacja
        // ***************************************************************************************
        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            if (Grayscale)
            {
                Bitmap bmp = new Bitmap(pictureBox2.Image);
                Bitmap negateBmp = new Bitmap(pictureBox2.Image.Width, pictureBox2.Image.Height);

                for (int row = 0; row < bmp.Width; row++)
                {
                    for (int column = 0; column < bmp.Height; column++)
                    {
                        Color colorValue = bmp.GetPixel(row, column);
                        int negateValue = (255 - (int)colorValue.R);
                        negateBmp.SetPixel(row, column, Color.FromArgb(negateValue, negateValue, negateValue));
                    }
                }
                pictureBox2.Image = negateBmp;
                pictureBox2.Refresh();
            }
            else MessageBox.Show("Image is not a grayscale!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        // progowanie
        // ***************************************************************************************
        public Image doTreshold(int tresholdValue, Image img)
        {   
            Bitmap bmp = new Bitmap(img);
            Bitmap treshholdBmp = new Bitmap(img.Width, img.Height);

            for (int row = 0; row < bmp.Width; row++)
            {
                for (int column = 0; column < bmp.Height; column++)
                {
                    Color colorValue = bmp.GetPixel(row, column);
                    if (colorValue.R > tresholdValue) { treshholdBmp.SetPixel(row, column, Color.FromArgb(255, 255, 255)); }
                    else treshholdBmp.SetPixel(row, column, Color.FromArgb(0, 0, 0));
                }
            }
            return treshholdBmp;
        }
        // progowanie z zachowaniem poziomów szarości
        // ***************************************************************************************
        private void thresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            if (Grayscale)
            {
                TreshholdLevelForm trForm = new TreshholdLevelForm(pictureBox2.Image);
                trForm.ShowDialog();
                pictureBox2.Image = doTreshold(Data.Value, pictureBox2.Image);
            }
            else MessageBox.Show("Image is not a grayscale!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageForm dublicateForm = new ImageForm();
            dublicateForm.pictureBox2.Image = this.pictureBox2.Image;
            dublicateForm.Text = this.Text + "Duplicate";
            dublicateForm.Show();
        }

        // wygładzanie liniowe
        // ***************************************************************************************
        public void BlurImage(PictureBox pictureBox2, string method, int maskSize)
        {
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Bgr, byte> dst = new Image<Bgr, byte>(src.Width, src.Height);
            Size size;
            if (maskSize == 3) { size = new Size(3, 3); }
            else if (maskSize == 5) { size = new Size(5, 5); }
            else size = new Size(7, 7);
            Point anchor = new Point(-1, -1);
            Bitmap bmp;

            if (method == "Isolated")
            {
                CvInvoke.Blur(src, dst, size, anchor, Emgu.CV.CvEnum.BorderType.Isolated);
                CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
                bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
                pictureBox2.Image = bmp;
            }
            else if (method == "Reflect")
            {
                CvInvoke.Blur(src, dst, size, anchor, Emgu.CV.CvEnum.BorderType.Reflect);
                CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
                bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
                pictureBox2.Image = bmp;
            }
            else if (method == "Replicate")
            {
                CvInvoke.Blur(src, dst, size, anchor, Emgu.CV.CvEnum.BorderType.Replicate);
                CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
                bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
                pictureBox2.Image = bmp;
            }
        }

        public void GaussianBlurImage(PictureBox pictureBox2, string method, int maskSize)
        {
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Bgr, byte> dst = new Image<Bgr, byte>(src.Width, src.Height);
            Size size;
            if (maskSize == 3) { size = new Size(3, 3); }
            else if (maskSize == 5) { size = new Size(5, 5); }
            else size = new Size(7, 7);
            int sigmaX = 0;
            int sigmaY = 0;
            Bitmap bmp;

            if (method == "Isolated")
            {
                CvInvoke.GaussianBlur(src, dst, size, sigmaX, sigmaY, Emgu.CV.CvEnum.BorderType.Isolated);
                CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
                bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
                pictureBox2.Image = bmp;
            }
            else if (method == "Reflect")
            {
                CvInvoke.GaussianBlur(src, dst, size, sigmaX, sigmaY, Emgu.CV.CvEnum.BorderType.Reflect);
                CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
                bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
                pictureBox2.Image = bmp;
            }
            else if (method == "Replicate")
            {
                CvInvoke.GaussianBlur(src, dst, size, sigmaX, sigmaY, Emgu.CV.CvEnum.BorderType.Replicate);
                CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
                bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
                pictureBox2.Image = bmp;
            }
        }
        // filtracja medianowa
        // ***************************************************************************************
        public void MedianBlurImage(PictureBox pictureBox2, int size)
        {
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Bgr, byte> dst = new Image<Bgr, byte>(src.Width, src.Height);
            Bitmap bmp;
            CvInvoke.MedianBlur(src, dst, size);
            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox2.Image = bmp;
        }

        // Sobel, Laplacian, Canny
        // ***************************************************************************************
        public void CannyDetectEdge(PictureBox pictureBox2)
        {
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Gray, Byte> srcImg = src.ToImage<Gray, Byte>();
            Image<Gray, byte> dst = new Image<Gray, byte>(src.Width, src.Height);
            dst = srcImg.Canny(20, 50);
            Bitmap bmp;
            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox2.Image = bmp;
        }
        public void SobelDetectEdge(PictureBox pictureBox2)
        {
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Gray, float> srcImg = src.ToImage<Gray, float>();
            Image<Gray, float> dst = new Image<Gray, float>(src.Width, src.Height);
            dst = srcImg.Sobel(1, 1, 3);
            Bitmap bmp;
            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox2.Image = bmp;
        }
        public void LaplacianDetectEdge(PictureBox pictureBox2)
        {
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Gray, float> srcImg = src.ToImage<Gray, float>();
            Image<Gray, float> dst = new Image<Gray, float>(src.Width, src.Height);
            dst = srcImg.Laplace(5);
            Bitmap bmp;
            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox2.Image = bmp;
        }
        // wyostrzanie liniowe oparte na 3 maskach laplasjanowych
        // ***************************************************************************************
        public void WyostrzanieLiniowe(PictureBox pictureBox2, int method)
        {
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Bgr, byte> dst = new Image<Bgr, byte>(src.Width, src.Height);
            Bitmap bmp;
            Matrix<float> kernel;
            if (method == 1) { kernel = new Matrix<float>(new float[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } }); }
            else if (method == 2) { kernel = new Matrix<float>(new float[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } }); }
            else { kernel = new Matrix<float>(new float[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } }); }
            Point anchor = new Point(-1, -1);
            CvInvoke.Filter2D(src, dst, kernel, anchor);
            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox2.Image = bmp;
        }
        // kierunkowa detekcja krawędzi w oparciu o maskę Prewitta
        // ***************************************************************************************
        public void WyostrzanieLinioweKierunkowe(PictureBox pictureBox2, string method)
        {
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Bgr, byte> dst = new Image<Bgr, byte>(src.Width, src.Height);
            Bitmap bmp;
            Matrix<float> kernel;
            if (method == "N") { kernel = new Matrix<float>(new float[3, 3] { { 1, 1, 1 }, { 1, -2, 1 }, { -1, -1, -1 } }); }
            else if (method == "S") { kernel = new Matrix<float>(new float[3, 3] { { -1, -1, -1 }, { 1, -2, 1 }, { 1, 1, 1 } }); }
            else if (method == "E") { kernel = new Matrix<float>(new float[3, 3] { { -1, 1, 1 }, { -1, -2, 1 }, { -1, 1, 1 } }); }
            else if (method == "W") { kernel = new Matrix<float>(new float[3, 3] { { 1, 1, -1 }, { 1, -2, -1 }, { 1, 1, -1 } }); }
            else if (method == "NE") { kernel = new Matrix<float>(new float[3, 3] { { 1, 1, 1 }, { -1, -2, 1 }, { -1, -1, 1 } }); }
            else if (method == "NW") { kernel = new Matrix<float>(new float[3, 3] { { 1, 1, 1 }, { 1, -2, -1 }, { 1, -1, -1 } }); }
            else if (method == "SE") { kernel = new Matrix<float>(new float[3, 3] { { -1, -1, 1 }, { -1, -2, 1 }, { 1, 1, 1 } }); }
            else { kernel = new Matrix<float>(new float[3, 3] { { 1, -1, -1 }, { 1, -2, -1 }, { 1, 1, 1 } }); } //SW
            Point anchor = new Point(-1, -1);
            CvInvoke.Filter2D(src, dst, kernel, anchor);
            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox2.Image = bmp;
        }
        // filtracja medianowa
        // ***************************************************************************************
        private void toolStripTextBox1_DoubleClick(object sender, EventArgs e)
        {
            int size = Int32.Parse(toolStripTextBox1.Text);
            if (size % 2 == 0) ++size;
            toolStripTextBox1.Text = size.ToString();
            MedianBlurImage(pictureBox2, size);

        }
        // operacje punktowe dwuargumentowe
        // ***************************************************************************************
        private void logicOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogicOperationForm lof = new LogicOperationForm();
            lof.Show();
        }
        // ***************************************************************************************
        private void laplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaplacianDetectEdge(pictureBox2);
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SobelDetectEdge(pictureBox2);
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CannyDetectEdge(pictureBox2);
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurImage(pictureBox2, "Isolated", 3);
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurImage(pictureBox2, "Isolated", 5);
        }

        private void x7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlurImage(pictureBox2, "Isolated", 7);
        }

        private void x3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BlurImage(pictureBox2, "Reflect", 3);
        }

        private void x5ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BlurImage(pictureBox2, "Reflect", 5);
        }

        private void x7ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BlurImage(pictureBox2, "Reflect", 7);
        }

        private void x3ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BlurImage(pictureBox2, "Replicate", 3);
        }

        private void x5ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BlurImage(pictureBox2, "Replicate", 5);
        }

        private void x7ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BlurImage(pictureBox2, "Replicate", 7);
        }

        private void x3ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GaussianBlurImage(pictureBox2, "Isolated", 3);
        }

        private void x5ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GaussianBlurImage(pictureBox2, "Isolated", 5);
        }

        private void x7ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GaussianBlurImage(pictureBox2, "Isolated", 7);
        }

        private void x3ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            GaussianBlurImage(pictureBox2, "Reflect", 3);
        }

        private void x5ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            GaussianBlurImage(pictureBox2, "Reflect", 5);
        }

        private void x7ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            GaussianBlurImage(pictureBox2, "Reflect", 7);
        }

        private void x3ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            GaussianBlurImage(pictureBox2, "Replicate", 3);
        }

        private void x5ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            GaussianBlurImage(pictureBox2, "Replicate", 5);
        }

        private void x7ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            GaussianBlurImage(pictureBox2, "Replicate", 7);
        }
        // equalizacja - biblioteka :з
        // ***************************************************************************************
        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Gray, byte> srcImg = src.ToImage<Gray, byte>();
            Image<Gray, byte> dst = new Image<Gray, byte>(src.Width, src.Height);
            CvInvoke.EqualizeHist(srcImg, dst);
            Bitmap bmp;
            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox2.Image = bmp;
        }

        private void method1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WyostrzanieLiniowe(pictureBox2, 1);
        }

        private void method2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WyostrzanieLiniowe(pictureBox2, 2);
        }

        private void method3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WyostrzanieLiniowe(pictureBox2, 3);
        }

        private void eToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WyostrzanieLinioweKierunkowe(pictureBox2, "E");
        }

        private void wToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WyostrzanieLinioweKierunkowe(pictureBox2, "W");
        }

        private void nEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WyostrzanieLinioweKierunkowe(pictureBox2, "NE");
        }

        private void nWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WyostrzanieLinioweKierunkowe(pictureBox2, "NW");
        }

        private void sEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WyostrzanieLinioweKierunkowe(pictureBox2, "SE");
        }

        private void sWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WyostrzanieLinioweKierunkowe(pictureBox2, "SW");
        }
        private void universalLinearOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaskValuesForm mskValFrm = new MaskValuesForm(pictureBox2.Image);
            mskValFrm.ShowDialog();
            pictureBox2.Image = mskValFrm.pictureBox2.Image;
        }

        private void nToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WyostrzanieLinioweKierunkowe(pictureBox2, "N");
        }

        private void sToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WyostrzanieLinioweKierunkowe(pictureBox2, "S");
        }
        // Implementacja wybranych operacji morfologii matematycznej
        // ***************************************************************************************
        private void operationsOfMathematicalMorphologyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MorfologicalForm morf = new MorfologicalForm(pictureBox2.Image);
            morf.ShowDialog();
            pictureBox2.Image = morf.pictureBox2.Image;
        }
        // Algorytm i program realizujący operację szkieletyzacji (ścieniania)
        // ***************************************************************************************
        private void skeletonizationOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Bgr, byte> skelet = new Image<Bgr, byte>(src.Width, src.Height);
            Image<Bgr, byte> im_open = new Image<Bgr, byte>(src.Width, src.Height);
            Image<Bgr, byte> im_temp = new Image<Bgr, byte>(src.Width, src.Height);
            Image<Bgr, byte> im_bitwise = new Image<Bgr, byte>(src.Width, src.Height);
            var eroded = new Mat();
            var im_copy = new Mat();
            CvInvoke.Threshold(src, im_copy, 127, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
            var kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Cross, new Size(3, 3), new Point(-1, -1));
            int a = 50;
            while (a > 0)
            {
                CvInvoke.MorphologyEx(im_copy, im_open, Emgu.CV.CvEnum.MorphOp.Open, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0));
                CvInvoke.Subtract(im_copy, im_open, im_temp);
                CvInvoke.Erode(im_copy, eroded, kernel, new Point(-1, -1), 2, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1.0));
                CvInvoke.BitwiseOr(skelet, im_temp, im_bitwise);
                skelet = im_bitwise;
                im_copy = eroded;
                --a;
            }
            Bitmap bmp;
            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", skelet);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox2.Image = bmp;
        }
        // redukcja poziomów szarości przez posteryzację
        // ***************************************************************************************
        private void toolStripTextBox2_DoubleClick(object sender, EventArgs e)
        {
            double count = Int32.Parse(toolStripTextBox2.Text);
            double step = Math.Round(255 / count);
            double[] bins = new double[(int)count];
            for (int i = 0; i < count; ++i)
            {
                bins[i] = step * i;
                Console.WriteLine("{0}", bins[i]);
            }
            Bitmap bmp = (Bitmap)pictureBox2.Image;
            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height);
            Color color;
            for (int i = 0; i < bmp.Width; ++i)
                for (int j = 0; j < bmp.Height; ++j)
                {
                    color = bmp.GetPixel(i, j);
                    for(int bin = 0; bin< bins.Length - 1; ++bin) {
                    if(color.R > bins[bin])
                        {
                            NewBmp.SetPixel(i, j, Color.FromArgb((int)bins[bin], (int)bins[bin], (int)bins[bin]));
                        }else if(color.R > bins[bins.Length - 1]) {
                            NewBmp.SetPixel(i, j, Color.FromArgb(255,255,255));
                        }
                    }
                }
            pictureBox2.Image = NewBmp;
        }
        // Implementacja filtracji dwu i jedno etapowej
        // ***************************************************************************************
        private void twostageAndOnestageFiltrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TwoStageMaskForm twoStageF = new TwoStageMaskForm(pictureBox2.Image);
            twoStageF.ShowDialog();
            pictureBox2.Image = twoStageF.pictureBox1.Image;
        }
        // Progowanie adaptacyjne
        // ***************************************************************************************
        private void adaptiveThresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Gray, Byte> srcImg = src.ToImage<Gray, Byte>();
            Image<Gray, byte> dst = new Image<Gray, byte>(src.Width, src.Height);
            CvInvoke.AdaptiveThreshold(srcImg, dst, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.Binary, 11, 5);
            Bitmap bmp;
            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox2.Image = bmp;
        }
        // Progowanie metodą Otsu
        // ***************************************************************************************
        private void otsuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Gray, Byte> srcImg = src.ToImage<Gray, Byte>();
            Image<Gray, byte> dst = new Image<Gray, byte>(src.Width, src.Height);
            CvInvoke.Threshold(srcImg, dst,0,255,Emgu.CV.CvEnum.ThresholdType.Otsu);
            Bitmap bmp;
            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox2.Image = bmp;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
