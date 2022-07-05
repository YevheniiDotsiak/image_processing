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
    public partial class TreshholdLevelForm : Form
    {
        Bitmap bmpOr;
        Bitmap bmpCl;
        Image img;
        ImageForm imgFrm = new ImageForm();

        public TreshholdLevelForm(Image picture)
        {
            InitializeComponent();
            img = picture;
            pictureBoxTresHold.Image = img;
            bmpOr = (Bitmap)pictureBoxTresHold.Image;
            bmpCl = (Bitmap)bmpOr.Clone();
        }

        private void buttonAcceptValue_Click(object sender, EventArgs e)
        {
            Data.Value = (int)numericUpDown1.Value;
            this.Hide();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {   // rozciąganie zakresu
            Data.Value = (int)numericUpDown1.Value;
            pictureBoxTresHold.Image = imgFrm.doTreshold(Data.Value, bmpCl);
            bmpCl = (Bitmap)bmpOr.Clone();
        }
    }
}
