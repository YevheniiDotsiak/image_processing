
namespace APO
{
    partial class TreshholdLevelForm
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonAcceptValue = new System.Windows.Forms.Button();
            this.pictureBoxTresHold = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTresHold)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numericUpDown1.Location = new System.Drawing.Point(3, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(368, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonAcceptValue
            // 
            this.buttonAcceptValue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAcceptValue.Location = new System.Drawing.Point(148, 393);
            this.buttonAcceptValue.Name = "buttonAcceptValue";
            this.buttonAcceptValue.Size = new System.Drawing.Size(75, 23);
            this.buttonAcceptValue.TabIndex = 2;
            this.buttonAcceptValue.Text = "Threshold";
            this.buttonAcceptValue.UseVisualStyleBackColor = true;
            this.buttonAcceptValue.Click += new System.EventHandler(this.buttonAcceptValue_Click);
            // 
            // pictureBoxTresHold
            // 
            this.pictureBoxTresHold.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTresHold.Location = new System.Drawing.Point(3, 29);
            this.pictureBoxTresHold.Name = "pictureBoxTresHold";
            this.pictureBoxTresHold.Size = new System.Drawing.Size(368, 358);
            this.pictureBoxTresHold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTresHold.TabIndex = 3;
            this.pictureBoxTresHold.TabStop = false;
            // 
            // TreshholdLevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(373, 420);
            this.Controls.Add(this.pictureBoxTresHold);
            this.Controls.Add(this.buttonAcceptValue);
            this.Controls.Add(this.numericUpDown1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TreshholdLevelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TreshholdLevelForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTresHold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonAcceptValue;
        public System.Windows.Forms.PictureBox pictureBoxTresHold;
    }
}