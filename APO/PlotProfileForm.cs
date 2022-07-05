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
    public partial class PlotProfileForm : Form
    {
        Image img;
        Bitmap bmpOrg;
        Bitmap bmpCln;
        plotChartForm plotChFrm = new plotChartForm();
        public PlotProfileForm(Image picture)
        { 
           InitializeComponent();
            img = picture;
            pictureBoxPlot.Image = img;
            bmpOrg = (Bitmap)pictureBoxPlot.Image;
            bmpCln = (Bitmap)bmpOrg.Clone();
            plotChFrm.Owner = this;
        }

        List<Point> lp = new List<Point>();
        dynamic X1, X2, Y1, Y2;
        

        void DrawPlotProfile(List<double> intensivity)
        {
            plotChFrm.chart1.Series["Series1"].LegendText = "Intensivity of pixels";
            plotChFrm.chart1.Series["Series1"].Color = Color.Black;
            plotChFrm.chart1.Series["Series1"].Points.Clear();
            plotChFrm.chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i < intensivity.Count; ++i)
            {
                plotChFrm.chart1.Series["Series1"].Points.AddXY(i, intensivity[i]);
            }
            plotChFrm.Show();
        }
        

        private void pictureBoxPlot_MouseDown(object sender, MouseEventArgs e)
        {
            lp.Add(new Point(e.X, e.Y));
            if (lp.Count <= 2)
            {
                
                if (lp.Count > 1)
                {
                    pictureBoxPlot.Image = bmpCln;
                    using (Graphics g = Graphics.FromImage(pictureBoxPlot.Image))
                    {
                        g.DrawLine(Pens.Yellow, lp[0], lp[1]);
                        X1 = lp[0].X;
                        X2 = lp[1].X;
                        Y1 = lp[0].Y;
                        Y2 = lp[1].Y;
                        pictureBoxPlot.Refresh();
                        PlotValues();
                        DrawPlotProfile(PlotValues());
                        
                    }
                }
            }
            else
            {
                pictureBoxPlot.Image = bmpOrg;
                bmpCln = (Bitmap)bmpOrg.Clone();
                pictureBoxPlot.Refresh();
                lp.Clear();
                plotChFrm.Hide();
            }
        }

        public List<double> PlotValues()
        {
            int x1 = X1;
            int x2 = X2;
            int y1 = Y1;
            int y2 = Y2;
            
            double deltaX = Math.Abs(x2 - x1);
            double deltaY = Math.Abs(y2 - y1);
            int signX = x1 < x2 ? 1 : -1;
            int signY = y1 < y2 ? 1 : -1;
            double error = deltaX - deltaY;
            List<Point> res = new List<Point>();
            while (x1 != x2 || y1 != y2)
            {
                res.Add(new Point(x1, y1));
                double error2 = error * 2;
                if (error2 > -deltaY)
                {
                    error -= deltaY;
                    x1 += signX;
                }
                if (error2 < deltaX)
                {
                    error += deltaX;
                    y1 += signY;
                }
            }
            res.Add(new Point(x2, y2));
            

            Color color;
            Bitmap bmp = bmpOrg;
            List<double> intensivity = new List<double>();
            for (int i = 0; i < res.Count; ++i)
            {
                color = bmp.GetPixel(res[i].X, res[i].Y);
                
                double intensValue = Math.Round(0.24 * color.R + 0.69 * color.G + 0.07 * color.B);   
                intensivity.Add(intensValue);
            }
            return intensivity; 
        }
    }
}
