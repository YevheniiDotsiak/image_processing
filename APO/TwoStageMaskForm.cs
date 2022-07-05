using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO
{
    public partial class TwoStageMaskForm : Form
    {
        public TwoStageMaskForm(Image img)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("columnName1", "Column №1");
            dataGridView1.Columns.Add("columnName2", "Column №2");
            dataGridView1.Columns.Add("columnName3", "Column №3");
            dataGridView1.Rows.Add(0, 0, 0);
            dataGridView1.Rows.Add(0, 0, 0);
            dataGridView1.Rows.Add(0, 0, 0);

            dataGridView2.Columns.Add("columnName1", "Column №1");
            dataGridView2.Columns.Add("columnName2", "Column №2");
            dataGridView2.Columns.Add("columnName3", "Column №3");
            dataGridView2.Rows.Add(0, 0, 0);
            dataGridView2.Rows.Add(0, 0, 0);
            dataGridView2.Rows.Add(0, 0, 0);

            pictureBox1.Image = img;

        }

        string fileName = "TwoStageFiltered";
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

            int N11 = Int32.Parse(dataGridView2[0, 0].Value.ToString());
            int N12 = Int32.Parse(dataGridView2[1, 0].Value.ToString());
            int N13 = Int32.Parse(dataGridView2[2, 0].Value.ToString());
            int N21 = Int32.Parse(dataGridView2[0, 1].Value.ToString());
            int N22 = Int32.Parse(dataGridView2[1, 1].Value.ToString());
            int N23 = Int32.Parse(dataGridView2[2, 1].Value.ToString());
            int N31 = Int32.Parse(dataGridView2[0, 2].Value.ToString());
            int N32 = Int32.Parse(dataGridView2[1, 2].Value.ToString());
            int N33 = Int32.Parse(dataGridView2[2, 2].Value.ToString());

            while (File.Exists(@"TempImages\\" + fileName + ".bmp")) { fileName += "1"; }
            pictureBox1.Image.Save(@"TempImages\\" + fileName + ".bmp");
            var src = CvInvoke.Imread(@"TempImages\\" + fileName + ".bmp");
            Image<Bgr, byte> dst = new Image<Bgr, byte>(src.Width, src.Height);
            Image<Bgr, byte> dst2 = new Image<Bgr, byte>(src.Width, src.Height);
            Bitmap bmp;

            Matrix<int> kernel1 = new Matrix<int>(new int[3, 3] { { M11, M12, M13 }, { M21, M22, M23 }, { M31, M32, M33 } });
            Matrix<int> kernel2 = new Matrix<int>(new int[3, 3] { { N11, N12, N13 }, { N21, N22, N23 }, { N31, N32, N33 } });
            Point anchor = new Point(-1, -1);

            CvInvoke.Filter2D(src, dst, kernel1, anchor);
            CvInvoke.Filter2D(dst, dst2, kernel2, anchor);

            CvInvoke.Imwrite(@"TempImages\\" + fileName + ".bmp", dst2);
            bmp = new Bitmap(@"TempImages\\" + fileName + ".bmp");
            pictureBox1.Image = bmp;
            this.Hide();
        }
    }
}
