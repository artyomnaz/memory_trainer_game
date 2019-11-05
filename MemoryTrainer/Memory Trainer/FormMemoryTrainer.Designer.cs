namespace Memory_Trainer
{
    partial class FormMemoryTrainer
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMemoryTrainer));
            this.buttonFindAPair = new System.Windows.Forms.Button();
            this.buttonQuadShulte = new System.Windows.Forms.Button();
            this.buttonLostWord = new System.Windows.Forms.Button();
            this.buttonMemoryMatrix = new System.Windows.Forms.Button();
            this.buttonThimbles = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFindAPair
            // 
            this.buttonFindAPair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(32)))));
            this.buttonFindAPair.FlatAppearance.BorderSize = 2;
            this.buttonFindAPair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFindAPair.Location = new System.Drawing.Point(198, 64);
            this.buttonFindAPair.Name = "buttonFindAPair";
            this.buttonFindAPair.Size = new System.Drawing.Size(175, 142);
            this.buttonFindAPair.TabIndex = 0;
            this.buttonFindAPair.Text = "Найди пару";
            this.buttonFindAPair.UseVisualStyleBackColor = true;
            this.buttonFindAPair.Click += new System.EventHandler(this.buttonFindAPair_Click);
            // 
            // buttonQuadShulte
            // 
            this.buttonQuadShulte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(122)))), ((int)(((byte)(125)))));
            this.buttonQuadShulte.FlatAppearance.BorderSize = 2;
            this.buttonQuadShulte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuadShulte.Location = new System.Drawing.Point(422, 183);
            this.buttonQuadShulte.Name = "buttonQuadShulte";
            this.buttonQuadShulte.Size = new System.Drawing.Size(175, 142);
            this.buttonQuadShulte.TabIndex = 1;
            this.buttonQuadShulte.Text = "Квадрат Шульте";
            this.buttonQuadShulte.UseVisualStyleBackColor = true;
            this.buttonQuadShulte.Click += new System.EventHandler(this.buttonQuadShulte_Click);
            // 
            // buttonLostWord
            // 
            this.buttonLostWord.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(68)))));
            this.buttonLostWord.FlatAppearance.BorderSize = 2;
            this.buttonLostWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLostWord.Location = new System.Drawing.Point(653, 64);
            this.buttonLostWord.Name = "buttonLostWord";
            this.buttonLostWord.Size = new System.Drawing.Size(175, 142);
            this.buttonLostWord.TabIndex = 2;
            this.buttonLostWord.Text = "Потерянное слово";
            this.buttonLostWord.UseVisualStyleBackColor = true;
            this.buttonLostWord.Click += new System.EventHandler(this.buttonLostWord_Click);
            // 
            // buttonMemoryMatrix
            // 
            this.buttonMemoryMatrix.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(167)))), ((int)(((byte)(78)))));
            this.buttonMemoryMatrix.FlatAppearance.BorderSize = 2;
            this.buttonMemoryMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemoryMatrix.Location = new System.Drawing.Point(198, 309);
            this.buttonMemoryMatrix.Name = "buttonMemoryMatrix";
            this.buttonMemoryMatrix.Size = new System.Drawing.Size(175, 142);
            this.buttonMemoryMatrix.TabIndex = 3;
            this.buttonMemoryMatrix.Text = "Матрицы памяти";
            this.buttonMemoryMatrix.UseVisualStyleBackColor = true;
            this.buttonMemoryMatrix.Click += new System.EventHandler(this.buttonMemoryMatrix_Click);
            // 
            // buttonThimbles
            // 
            this.buttonThimbles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(30)))), ((int)(((byte)(138)))));
            this.buttonThimbles.FlatAppearance.BorderSize = 2;
            this.buttonThimbles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonThimbles.Location = new System.Drawing.Point(653, 309);
            this.buttonThimbles.Name = "buttonThimbles";
            this.buttonThimbles.Size = new System.Drawing.Size(175, 142);
            this.buttonThimbles.TabIndex = 4;
            this.buttonThimbles.Text = "Наперстки";
            this.buttonThimbles.UseVisualStyleBackColor = true;
            this.buttonThimbles.Click += new System.EventHandler(this.buttonThimbles_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(412, 473);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 196);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FormMemoryTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1012, 681);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonThimbles);
            this.Controls.Add(this.buttonMemoryMatrix);
            this.Controls.Add(this.buttonLostWord);
            this.Controls.Add(this.buttonQuadShulte);
            this.Controls.Add(this.buttonFindAPair);
            this.Name = "FormMemoryTrainer";
            this.Text = "Тренажер памяти";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFindAPair;
        private System.Windows.Forms.Button buttonQuadShulte;
        private System.Windows.Forms.Button buttonLostWord;
        private System.Windows.Forms.Button buttonMemoryMatrix;
        private System.Windows.Forms.Button buttonThimbles;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

