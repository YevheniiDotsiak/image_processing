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
    public partial class MaskValuesForm : Form
    {
        public MaskValuesForm(Image img)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("columnName1", "Column №1");
            dataGridView1.Columns.Add("columnName2", "Column №2");
            dataGridView1.Columns.Add("columnName3", "Column №3");
            dataGridView1.Rows.Add(0, 0, 0);
            dataGridView1.Rows.Add(0, 0, 0);
            dataGridView1.Rows.Add(0, 0, 0);
            pictureBox2.Image = img;
        }
        string fileName = "MyMaskImage";
        private void buttonApply_Click(object sender, EventArgs e)
        {
            int M11 = Int32.Parse(dataGridView1[0, 0].Value.ToString());
            int M12 = Int32.Parse(dataGridView1[1, 0].Value.ToString());
            int M13 = Int32.Parse(dataGridView1[2, 0].Value.ToString());
            int M21 = Int32.Parse(dataGridView1[0, 1].Value.ToString());
            int M22 = Int32.Parse(dataGridView1[1, 1].Value.ToString());
            int M23 = Int32.Parse(dataGridView1[2, 1].Value.ToString());
            int M31 = Int32.Parse(dataGridView1[0, 2].Value.ToString());
            int M32 = Int32.Parse(dataGridView1[1, 2].Value.ToString());
            int M33 = Int32.Parse(dataGridView1[2, 2].Value.ToString());

            Console.WriteLine("{0},{1},{2}",M11,M12,M13);
            Console.WriteLine("{0},{1},{2}", M21, M22, M23);
            Console.WriteLine("{0},{1},{2}", M31, M32, M33);


            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox2.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Bgr, byte> dst = new Image<Bgr, byte>(src.Width, src.Height);
            Bitmap bmp;
            Matrix<int> kernel = new Matrix<int>(new int[3, 3] { { M11, M12, M13 }, { M21, M22, M23 }, { M31, M32, M33 } });
            Point anchor = new Point(-1, -1);
            CvInvoke.Filter2D(src, dst, kernel, anchor);
            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox2.Image = bmp;
            this.Hide();
        }
    }
}
