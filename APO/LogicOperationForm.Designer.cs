
namespace APO
{
    partial class LogicOperationForm
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
            this.pictureBoxImg1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxImg2 = new System.Windows.Forms.PictureBox();
            this.comboBoxOperation = new System.Windows.Forms.ComboBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonOpenImg2 = new System.Windows.Forms.Button();
            this.buttonOpenImg1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImg1
            // 
            this.pictureBoxImg1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxImg1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxImg1.Location = new System.Drawing.Point(1, -1);
            this.pictureBoxImg1.Name = "pictureBoxImg1";
            this.pictureBoxImg1.Size = new System.Drawing.Size(303, 435);
            this.pictureBoxImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImg1.TabIndex = 1;
            this.pictureBoxImg1.TabStop = false;
            // 
            // pictureBoxImg2
            // 
            this.pictureBoxImg2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxImg2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxImg2.Location = new System.Drawing.Point(437, -1);
            this.pictureBoxImg2.Name = "pictureBoxImg2";
            this.pictureBoxImg2.Size = new System.Drawing.Size(294, 435);
            this.pictureBoxImg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImg2.TabIndex = 2;
            this.pictureBoxImg2.TabStop = false;
            // 
            // comboBoxOperation
            // 
            this.comboBoxOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOperation.FormattingEnabled = true;
            this.comboBoxOperation.Items.AddRange(new object[] {
            "Add",
            "Blending",
            "Not",
            "And",
            "Or",
            "Xor"});
            this.comboBoxOperation.Location = new System.Drawing.Point(310, 12);
            this.comboBoxOperation.Name = "comboBoxOperation";
            this.comboBoxOperation.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOperation.TabIndex = 3;
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(324, 423);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(98, 29);
            this.buttonApply.TabIndex = 4;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonOpenImg2
            // 
            this.buttonOpenImg2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenImg2.Location = new System.Drawing.Point(656, 440);
            this.buttonOpenImg2.Name = "buttonOpenImg2";
            this.buttonOpenImg2.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenImg2.TabIndex = 5;
            this.buttonOpenImg2.Text = "Open Image";
            this.buttonOpenImg2.UseVisualStyleBackColor = true;
            this.buttonOpenImg2.Click += new System.EventHandler(this.buttonOpenImg2_Click);
            // 
            // buttonOpenImg1
            // 
            this.buttonOpenImg1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenImg1.Location = new System.Drawing.Point(1, 440);
            this.buttonOpenImg1.Name = "buttonOpenImg1";
            this.buttonOpenImg1.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenImg1.TabIndex = 6;
            this.buttonOpenImg1.Text = "Open Image";
            this.buttonOpenImg1.UseVisualStyleBackColor = true;
            this.buttonOpenImg1.Click += new System.EventHandler(this.buttonOpenImg1_Click);
            // 
            // LogicOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(729, 464);
            this.Controls.Add(this.buttonOpenImg1);
            this.Controls.Add(this.buttonOpenImg2);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.comboBoxOperation);
            this.Controls.Add(this.pictureBoxImg2);
            this.Controls.Add(this.pictureBoxImg1);
            this.Name = "LogicOperationForm";
            this.Text = "LogicOperationForm";
            this.Load += new System.EventHandler(this.LogicOperationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBoxImg1;
        public System.Windows.Forms.PictureBox pictureBoxImg2;
        public System.Windows.Forms.ComboBox comboBoxOperation;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonOpenImg2;
        private System.Windows.Forms.Button buttonOpenImg1;
    }
}