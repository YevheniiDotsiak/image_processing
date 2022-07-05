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

namespace APO
{
    public partial class Anaconda : Form
    {

        public Anaconda()
        {
            InitializeComponent();
        }

        string fName = "";
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files(*.BMP;*.PNG;*.JPG|*.BMP;*.PNG;*.JPG|All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ImageForm imgFrm = new ImageForm();
                    imgFrm.pictureBox2.Image = new Bitmap(ofd.FileName);
                    fName = ofd.FileName;
                    imgFrm.Text = fName;
                    imgFrm.Show();
                }
                catch
                {
                    MessageBox.Show("Can not open this file...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Anaconda_Load(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"TempImages");
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    file.Delete();
                }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplikacja zbiorcza z ćwiczeń laboratoryjnych" +
                "\nAutor: Yevhenii Dotsiak" +
                "\nProwadzący: mgr inż.Łukasz Roszkowiak" +
                "\nAlgorytmy Przetwarzania Obrazów 2022" +
                "\nWIT grupa ID: ID06IO2");
        }
    }
}
       
        



       

       

       
