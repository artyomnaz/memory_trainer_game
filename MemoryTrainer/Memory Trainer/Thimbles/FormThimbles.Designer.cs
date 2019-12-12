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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.timerShuffle = new System.Windows.Forms.Timer(this.components);
            this.timerOneToTop = new System.Windows.Forms.Timer(this.components);
            this.timerAllToTop = new System.Windows.Forms.Timer(this.components);
            this.label = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonRules = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.pbBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(134)))), ((int)(((byte)(97)))));
            this.buttonStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStartGame.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonStartGame.Location = new System.Drawing.Point(430, 5);
            this.buttonStartGame.Margin = new System.Windows.Forms.Padding(0);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(126, 21);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Начать игру";
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new System.EventHandler(this.ButtonStartGame_Click);
            // 
            // timerShuffle
            // 
            this.timerShuffle.Interval = 40;
            this.timerShuffle.Tick += new System.EventHandler(this.TimerShuffle_Tick);
            // 
            // timerOneToTop
            // 
            this.timerOneToTop.Interval = 20;
            this.timerOneToTop.Tick += new System.EventHandler(this.TimerOneToTop_Tick);
            // 
            // timerAllToTop
            // 
            this.timerAllToTop.Interval = 20;
            this.timerAllToTop.Tick += new System.EventHandler(this.TimerCheckWin_Tick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(168, 5);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(46, 18);
            this.label.TabIndex = 6;
            this.label.Text = "label1";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(173)))), ((int)(((byte)(119)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSave.Location = new System.Drawing.Point(9, 5);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(126, 21);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Сохранить игру";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(134)))), ((int)(((byte)(97)))));
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOpen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonOpen.Location = new System.Drawing.Point(9, 33);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(0);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(126, 21);
            this.buttonOpen.TabIndex = 8;
            this.buttonOpen.Text = "Открыть игру";
            this.buttonOpen.UseVisualStyleBackColor = false;
            this.buttonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // buttonRules
            // 
            this.buttonRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(173)))), ((int)(((byte)(119)))));
            this.buttonRules.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRules.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRules.Location = new System.Drawing.Point(877, 5);
            this.buttonRules.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRules.Name = "buttonRules";
            this.buttonRules.Size = new System.Drawing.Size(126, 21);
            this.buttonRules.TabIndex = 9;
            this.buttonRules.Text = "Правила";
            this.buttonRules.UseVisualStyleBackColor = false;
            this.buttonRules.Click += new System.EventHandler(this.ButtonRules_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(134)))), ((int)(((byte)(97)))));
            this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAbout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAbout.Location = new System.Drawing.Point(877, 33);
            this.buttonAbout.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(126, 21);
            this.buttonAbout.TabIndex = 10;
            this.buttonAbout.Text = "Об игре";
            this.buttonAbout.UseVisualStyleBackColor = false;
            this.buttonAbout.Click += new System.EventHandler(this.ButtonAbout_Click);
            // 
            // pbBackground
            // 
            this.pbBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBackground.Image = global::Memory_Trainer.Properties.Resources.bg;
            this.pbBackground.Location = new System.Drawing.Point(0, 0);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(1012, 681);
            this.pbBackground.TabIndex = 5;
            this.pbBackground.TabStop = false;
            // 
            // FormThimbles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 681);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.buttonRules);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.pbBackground);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1028, 720);
            this.MinimumSize = new System.Drawing.Size(1028, 720);
            this.Name = "FormThimbles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Наперстки";
            this.Load += new System.EventHandler(this.FormThimbles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Timer timerShuffle;
        private System.Windows.Forms.Timer timerOneToTop;
        private System.Windows.Forms.Timer timerAllToTop;
        private System.Windows.Forms.PictureBox pbBackground;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonRules;
        private System.Windows.Forms.Button buttonAbout;
    }
}