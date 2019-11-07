namespace Memory_Trainer
{
    partial class FormThimbles
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThimbles));
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbThimble1 = new System.Windows.Forms.PictureBox();
            this.pbThimble2 = new System.Windows.Forms.PictureBox();
            this.pbThimble3 = new System.Windows.Forms.PictureBox();
            this.pbBall = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbThimble1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThimble2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThimble3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Location = new System.Drawing.Point(445, 34);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(126, 23);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Начать игру";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.Button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pbThimble1
            // 
            this.pbThimble1.Image = ((System.Drawing.Image)(resources.GetObject("pbThimble1.Image")));
            this.pbThimble1.Location = new System.Drawing.Point(107, 250);
            this.pbThimble1.Name = "pbThimble1";
            this.pbThimble1.Size = new System.Drawing.Size(200, 250);
            this.pbThimble1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThimble1.TabIndex = 1;
            this.pbThimble1.TabStop = false;
            // 
            // pbThimble2
            // 
            this.pbThimble2.Image = ((System.Drawing.Image)(resources.GetObject("pbThimble2.Image")));
            this.pbThimble2.Location = new System.Drawing.Point(414, 270);
            this.pbThimble2.Name = "pbThimble2";
            this.pbThimble2.Size = new System.Drawing.Size(200, 250);
            this.pbThimble2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThimble2.TabIndex = 2;
            this.pbThimble2.TabStop = false;
            // 
            // pbThimble3
            // 
            this.pbThimble3.Image = ((System.Drawing.Image)(resources.GetObject("pbThimble3.Image")));
            this.pbThimble3.Location = new System.Drawing.Point(721, 250);
            this.pbThimble3.Name = "pbThimble3";
            this.pbThimble3.Size = new System.Drawing.Size(200, 250);
            this.pbThimble3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThimble3.TabIndex = 3;
            this.pbThimble3.TabStop = false;
            // 
            // pbBall
            // 
            this.pbBall.Image = ((System.Drawing.Image)(resources.GetObject("pbBall.Image")));
            this.pbBall.Location = new System.Drawing.Point(468, 395);
            this.pbBall.Name = "pbBall";
            this.pbBall.Size = new System.Drawing.Size(88, 88);
            this.pbBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBall.TabIndex = 4;
            this.pbBall.TabStop = false;
            // 
            // FormThimbles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 681);
            this.Controls.Add(this.pbThimble3);
            this.Controls.Add(this.pbThimble2);
            this.Controls.Add(this.pbThimble1);
            this.Controls.Add(this.pbBall);
            this.Controls.Add(this.buttonStartGame);
            this.MaximumSize = new System.Drawing.Size(1028, 720);
            this.MinimumSize = new System.Drawing.Size(1028, 720);
            this.Name = "FormThimbles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Наперстки";
            ((System.ComponentModel.ISupportInitialize)(this.pbThimble1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThimble2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThimble3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pbThimble1;
        private System.Windows.Forms.PictureBox pbThimble2;
        private System.Windows.Forms.PictureBox pbThimble3;
        private System.Windows.Forms.PictureBox pbBall;
    }
}