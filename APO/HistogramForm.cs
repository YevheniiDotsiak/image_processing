using System;
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
    public partial class HistogramForm : Form
    {
        public HistogramForm()
        {
            InitializeComponent();
        }

        public string NameOfImage()
        {
            string name = this.Text;
            name = Text.Remove(0, 13);
            return name;
        }


        private void buttonListAll_Click(object sender, EventArgs e)
        {
            LutForm lutFrm = new LutForm(); // reprezentacja tablicowa - All (RGB)
            lutFrm.StartPosition = FormStartPosition.CenterScreen;
            lutFrm.Text = "LUT of " + NameOfImage();
            lutFrm.dataGridView1.Columns.Add("columnName1", "Text1");
            lutFrm.dataGridView1.Columns.Add("columnName2", "Text2");
            Bitmap bmp = new Bitmap(pictureBox3.Image);
            int[] R = new int[256];
            int[] G = new int[256];
            int[] B = new int[256];
            int i, j;
            Color color;
            for (i = 0; i < bmp.Width; ++i)
                for (j = 0; j < bmp.Height; ++j)
                {
                    color = bmp.GetPixel(i, j);
                    ++R[color.R];
                    ++G[color.G];
                    ++B[color.B];
                }
            for (i = 0; i < 256; ++i)
            {
                int max = Math.Max(R[i], Math.Max(G[i], B[i]));
                lutFrm.dataGridView1.Rows.Add(i, max);
            }
            lutFrm.Show();
        }

        private void buttonListRed_Click(object sender, EventArgs e)
        {
                LutForm lutFrm = new LutForm(); // red
                lutFrm.StartPosition = FormStartPosition.CenterScreen;
                lutFrm.Text = "Red LUT of " + NameOfImage();
                lutFrm.dataGridView1.Columns.Add("columnName1", "Text1");
                lutFrm.dataGridView1.Columns.Add("columnName2", "Text2");

                Bitmap bmp = new Bitmap(pictureBox3.Image);
                int[] R = new int[256];
                int i, j;
                Color color;
                for (i = 0; i < bmp.Width; ++i)
                    for (j = 0; j < bmp.Height; ++j)
                    {
                        color = bmp.GetPixel(i, j);
                        ++R[color.R];
                    }
                for (i = 0; i < 256; ++i)
                {
                    lutFrm.dataGridView1.Rows.Add(i, R[i]);
                }
                lutFrm.Show();
        }

        private void buttonListGreen_Click(object sender, EventArgs e)
        {
            LutForm lutFrm = new LutForm(); // green
            lutFrm.StartPosition = FormStartPosition.CenterScreen;
            lutFrm.Text = "Green LUT of " + NameOfImage();
            lutFrm.dataGridView1.Columns.Add("columnName1", "Text1");
            lutFrm.dataGridView1.Columns.Add("columnName2", "Text2");

            Bitmap bmp = new Bitmap(pictureBox3.Image);
            int[] G = new int[256];
            int i, j;
            Color color;
            for (i = 0; i < bmp.Width; ++i)
                for (j = 0; j < bmp.Height; ++j)
                {
                    color = bmp.GetPixel(i, j);
                    ++G[color.G];
                }
            for (i = 0; i < 256; ++i)
            {
                lutFrm.dataGridView1.Rows.Add(i, G[i]);
            }
            lutFrm.Show();
        }

        private void buttonListBlue_Click(object sender, EventArgs e)
        {
            LutForm lutFrm = new LutForm(); // blue
            lutFrm.StartPosition = FormStartPosition.CenterScreen;
            lutFrm.Text = "Blue LUT of " + NameOfImage();
            lutFrm.dataGridView1.Columns.Add("columnName1", "Text1");
            lutFrm.dataGridView1.Columns.Add("columnName2", "Text2");

            Bitmap bmp = new Bitmap(pictureBox3.Image);
            int[] B = new int[256];
            int i, j;
            Color color;
            for (i = 0; i < bmp.Width; ++i)
                for (j = 0; j < bmp.Height; ++j)
                {
                    color = bmp.GetPixel(i, j);
                    ++B[color.B];
                }
            for (i = 0; i < 256; ++i)
            {
                lutFrm.dataGridView1.Rows.Add(i, B[i]);
            }
            lutFrm.Show();
        }

        private void pictureBoxRed_Click(object sender, EventArgs e)
        {

        }

        private void HistogramForm_Load(object sender, EventArgs e)
        {

        }
    }
}
