
namespace APO
{
    partial class HistogramForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistogramForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonListBlue = new System.Windows.Forms.Button();
            this.buttonListGreen = new System.Windows.Forms.Button();
            this.buttonListRed = new System.Windows.Forms.Button();
            this.buttonListAll = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.chartHistGray = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBoxRGB = new System.Windows.Forms.PictureBox();
            this.pictureBoxRed = new System.Windows.Forms.PictureBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxGreen = new System.Windows.Forms.PictureBox();
            this.pictureBoxBlue = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // buttonListBlue
            // 
            resources.ApplyResources(this.buttonListBlue, "buttonListBlue");
            this.buttonListBlue.BackColor = System.Drawing.Color.Blue;
            this.buttonListBlue.Name = "buttonListBlue";
            this.buttonListBlue.UseVisualStyleBackColor = false;
            this.buttonListBlue.Click += new System.EventHandler(this.buttonListBlue_Click);
            // 
            // buttonListGreen
            // 
            resources.ApplyResources(this.buttonListGreen, "buttonListGreen");
            this.buttonListGreen.BackColor = System.Drawing.Color.Lime;
            this.buttonListGreen.Name = "buttonListGreen";
            this.buttonListGreen.UseVisualStyleBackColor = false;
            this.buttonListGreen.Click += new System.EventHandler(this.buttonListGreen_Click);
            // 
            // buttonListRed
            // 
            resources.ApplyResources(this.buttonListRed, "buttonListRed");
            this.buttonListRed.BackColor = System.Drawing.Color.Red;
            this.buttonListRed.Name = "buttonListRed";
            this.buttonListRed.UseVisualStyleBackColor = false;
            this.buttonListRed.Click += new System.EventHandler(this.buttonListRed_Click);
            // 
            // buttonListAll
            // 
            resources.ApplyResources(this.buttonListAll, "buttonListAll");
            this.buttonListAll.Name = "buttonListAll";
            this.buttonListAll.UseVisualStyleBackColor = true;
            this.buttonListAll.Click += new System.EventHandler(this.buttonListAll_Click);
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3
            // 
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.buttonListAll);
            this.splitContainer3.Panel1.Controls.Add(this.chartHistGray);
            this.splitContainer3.Panel1.Controls.Add(this.pictureBoxRGB);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.buttonListRed);
            this.splitContainer3.Panel2.Controls.Add(this.pictureBoxRed);
            // 
            // chartHistGray
            // 
            resources.ApplyResources(this.chartHistGray, "chartHistGray");
            this.chartHistGray.BackColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.chartHistGray.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartHistGray.Legends.Add(legend1);
            this.chartHistGray.Name = "chartHistGray";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartHistGray.Series.Add(series1);
            // 
            // pictureBoxRGB
            // 
            resources.ApplyResources(this.pictureBoxRGB, "pictureBoxRGB");
            this.pictureBoxRGB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxRGB.Name = "pictureBoxRGB";
            this.pictureBoxRGB.TabStop = false;
            // 
            // pictureBoxRed
            // 
            resources.ApplyResources(this.pictureBoxRed, "pictureBoxRed");
            this.pictureBoxRed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxRed.Image = global::APO.Properties.Resources.Null;
            this.pictureBoxRed.Name = "pictureBoxRed";
            this.pictureBoxRed.TabStop = false;
            this.pictureBoxRed.Click += new System.EventHandler(this.pictureBoxRed_Click);
            // 
            // splitContainer4
            // 
            resources.ApplyResources(this.splitContainer4, "splitContainer4");
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.buttonListGreen);
            this.splitContainer4.Panel1.Controls.Add(this.pictureBoxGreen);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.buttonListBlue);
            this.splitContainer4.Panel2.Controls.Add(this.pictureBoxBlue);
            // 
            // pictureBoxGreen
            // 
            resources.ApplyResources(this.pictureBoxGreen, "pictureBoxGreen");
            this.pictureBoxGreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxGreen.Image = global::APO.Properties.Resources.Null;
            this.pictureBoxGreen.Name = "pictureBoxGreen";
            this.pictureBoxGreen.TabStop = false;
            // 
            // pictureBoxBlue
            // 
            resources.ApplyResources(this.pictureBoxBlue, "pictureBoxBlue");
            this.pictureBoxBlue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxBlue.Image = global::APO.Properties.Resources.Null;
            this.pictureBoxBlue.Name = "pictureBoxBlue";
            this.pictureBoxBlue.TabStop = false;
            // 
            // HistogramForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.splitContainer1);
            this.Name = "HistogramForm";
            this.Load += new System.EventHandler(this.HistogramForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartHistGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRed)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        public System.Windows.Forms.PictureBox pictureBoxRGB;
        public System.Windows.Forms.PictureBox pictureBoxRed;
        private System.Windows.Forms.SplitContainer splitContainer4;
        public System.Windows.Forms.PictureBox pictureBoxGreen;
        public System.Windows.Forms.PictureBox pictureBoxBlue;
        public System.Windows.Forms.Button buttonListBlue;
        public System.Windows.Forms.Button buttonListGreen;
        public System.Windows.Forms.Button buttonListRed;
        public System.Windows.Forms.Button buttonListAll;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartHistGray;
    }
}