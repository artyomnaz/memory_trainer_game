﻿namespace Memory_Trainer
{
    partial class FormLostWord
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
            this.timerIntro = new System.Windows.Forms.Timer(this.components);
            this.timerCreateBlock = new System.Windows.Forms.Timer(this.components);
            this.timerCountDown = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerIntro
            // 
            this.timerIntro.Enabled = true;
            this.timerIntro.Interval = 850;
            this.timerIntro.Tick += new System.EventHandler(this.TimerIntro_Tick);
            // 
            // timerCreateBlock
            // 
            this.timerCreateBlock.Interval = 1000;
            this.timerCreateBlock.Tick += new System.EventHandler(this.TimerCreateBlock_Tick);
            // 
            // timerCountDown
            // 
            this.timerCountDown.Interval = 1000;
            this.timerCountDown.Tick += new System.EventHandler(this.TimerCountDown_Tick);
            // 
            // FormLostWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1012, 681);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1028, 720);
            this.MinimumSize = new System.Drawing.Size(1028, 720);
            this.Name = "FormLostWord";
            this.Text = "Тренажер памяти";
            this.Load += new System.EventHandler(this.FormLostWord_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerIntro;
        private System.Windows.Forms.Timer timerCreateBlock;
        private System.Windows.Forms.Timer timerCountDown;
    }
}