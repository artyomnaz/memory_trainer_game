namespace Memory_Trainer.Quad_Shulte
{
    partial class FormLevel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLevel));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.Level1Button = new System.Windows.Forms.Button();
            this.Level2Button = new System.Windows.Forms.Button();
            this.Level3Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Memory_Trainer.Properties.Resources.fon;
            this.pictureBox1.Location = new System.Drawing.Point(0, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(405, 218);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TimeLabel.Font = new System.Drawing.Font("Magneto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeLabel.Location = new System.Drawing.Point(102, 39);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(203, 24);
            this.TimeLabel.TabIndex = 2;
            this.TimeLabel.Text = "Выберите уровень:";
            // 
            // Level1Button
            // 
            this.Level1Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Level1Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Level1Button.Font = new System.Drawing.Font("Magneto", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level1Button.Location = new System.Drawing.Point(49, 92);
            this.Level1Button.Name = "Level1Button";
            this.Level1Button.Size = new System.Drawing.Size(76, 70);
            this.Level1Button.TabIndex = 4;
            this.Level1Button.Text = "1";
            this.Level1Button.UseVisualStyleBackColor = false;
            this.Level1Button.Click += new System.EventHandler(this.Level1Button_Click);
            // 
            // Level2Button
            // 
            this.Level2Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Level2Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Level2Button.Font = new System.Drawing.Font("Magneto", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level2Button.Location = new System.Drawing.Point(164, 92);
            this.Level2Button.Name = "Level2Button";
            this.Level2Button.Size = new System.Drawing.Size(76, 70);
            this.Level2Button.TabIndex = 5;
            this.Level2Button.Text = "2";
            this.Level2Button.UseVisualStyleBackColor = false;
            this.Level2Button.Click += new System.EventHandler(this.Level2Button_Click);
            // 
            // Level3Button
            // 
            this.Level3Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Level3Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Level3Button.Font = new System.Drawing.Font("Magneto", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level3Button.Location = new System.Drawing.Point(280, 92);
            this.Level3Button.Name = "Level3Button";
            this.Level3Button.Size = new System.Drawing.Size(76, 70);
            this.Level3Button.TabIndex = 6;
            this.Level3Button.Text = "3";
            this.Level3Button.UseVisualStyleBackColor = false;
            this.Level3Button.Click += new System.EventHandler(this.Level3Button_Click);
            // 
            // FormLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 212);
            this.Controls.Add(this.Level3Button);
            this.Controls.Add(this.Level2Button);
            this.Controls.Add(this.Level1Button);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор уровня";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Button Level1Button;
        private System.Windows.Forms.Button Level2Button;
        private System.Windows.Forms.Button Level3Button;
    }
}