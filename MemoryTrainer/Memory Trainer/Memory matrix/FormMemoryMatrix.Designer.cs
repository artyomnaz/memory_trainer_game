﻿namespace Memory_Trainer.Memory_matrix
{
    partial class FormMemoryMatrix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMemoryMatrix));
            this.SuspendLayout();
            // 
            // FormMemoryMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1012, 681);
            this.MaximumSize = new System.Drawing.Size(1028, 720);
            this.MinimumSize = new System.Drawing.Size(1028, 720);
            this.Name = "FormMemoryMatrix";
            this.Text = "Матрицы памяти";
            this.Load += new System.EventHandler(this.FormMemoryMatrix_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}