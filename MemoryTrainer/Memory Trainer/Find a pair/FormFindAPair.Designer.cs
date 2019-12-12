namespace Memory_Trainer.Find_a_pair
{
    partial class FormFindAPair
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFindAPair));
            this.BackgroundPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPB)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundPB
            // 
            this.BackgroundPB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackgroundPB.BackgroundImage")));
            this.BackgroundPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackgroundPB.Image = ((System.Drawing.Image)(resources.GetObject("BackgroundPB.Image")));
            this.BackgroundPB.Location = new System.Drawing.Point(0, 0);
            this.BackgroundPB.Name = "BackgroundPB";
            this.BackgroundPB.Size = new System.Drawing.Size(1012, 681);
            this.BackgroundPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackgroundPB.TabIndex = 1;
            this.BackgroundPB.TabStop = false;
            // 
            // FormFindAPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(178)))), ((int)(((byte)(209)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1012, 681);
            this.Controls.Add(this.BackgroundPB);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormFindAPair";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Найди пару";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFindAPair_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox BackgroundPB;
    }
}