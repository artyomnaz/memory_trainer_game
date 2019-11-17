namespace Memory_Trainer.Quad_Shulte
{
    partial class FormQuadShulte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuadShulte));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimeLabel = new System.Windows.Forms.Label();
            this.Errorlabel = new System.Windows.Forms.Label();
            this.NewGamebutton = new System.Windows.Forms.Button();
            this.Downloadbutton = new System.Windows.Forms.Button();
            this.Rulebutton = new System.Windows.Forms.Button();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.Savebutton = new System.Windows.Forms.Button();
            this.Infobutton = new System.Windows.Forms.Button();
            this.CountLabel = new System.Windows.Forms.Label();
            this.Infolabel = new System.Windows.Forms.Label();
            this.Inflabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(239, 92);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(7);
            this.dataGridView1.MaximumSize = new System.Drawing.Size(540, 525);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(540, 525);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 3;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(540, 525);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Magneto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeLabel.Location = new System.Drawing.Point(12, 101);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(218, 24);
            this.TimeLabel.TabIndex = 1;
            this.TimeLabel.Text = "Длительность  игры:";
            // 
            // Errorlabel
            // 
            this.Errorlabel.AutoSize = true;
            this.Errorlabel.Font = new System.Drawing.Font("Magneto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Errorlabel.Location = new System.Drawing.Point(12, 260);
            this.Errorlabel.Name = "Errorlabel";
            this.Errorlabel.Size = new System.Drawing.Size(214, 24);
            this.Errorlabel.TabIndex = 2;
            this.Errorlabel.Text = "Количество ошибок:";
            // 
            // NewGamebutton
            // 
            this.NewGamebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NewGamebutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewGamebutton.Font = new System.Drawing.Font("Magneto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewGamebutton.Location = new System.Drawing.Point(809, 101);
            this.NewGamebutton.Name = "NewGamebutton";
            this.NewGamebutton.Size = new System.Drawing.Size(179, 61);
            this.NewGamebutton.TabIndex = 3;
            this.NewGamebutton.Text = "Новая игра";
            this.NewGamebutton.UseVisualStyleBackColor = false;
            // 
            // Downloadbutton
            // 
            this.Downloadbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Downloadbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Downloadbutton.Font = new System.Drawing.Font("Magneto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Downloadbutton.Location = new System.Drawing.Point(809, 209);
            this.Downloadbutton.Name = "Downloadbutton";
            this.Downloadbutton.Size = new System.Drawing.Size(179, 61);
            this.Downloadbutton.TabIndex = 4;
            this.Downloadbutton.Text = "Загрузить игру";
            this.Downloadbutton.UseVisualStyleBackColor = false;
            // 
            // Rulebutton
            // 
            this.Rulebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Rulebutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rulebutton.Font = new System.Drawing.Font("Magneto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rulebutton.Location = new System.Drawing.Point(809, 317);
            this.Rulebutton.Name = "Rulebutton";
            this.Rulebutton.Size = new System.Drawing.Size(179, 61);
            this.Rulebutton.TabIndex = 5;
            this.Rulebutton.Text = "Правила игры";
            this.Rulebutton.UseVisualStyleBackColor = false;
            this.Rulebutton.Click += new System.EventHandler(this.button3_Click);
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Magneto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimerLabel.Location = new System.Drawing.Point(97, 150);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(39, 24);
            this.TimerLabel.TabIndex = 6;
            this.TimerLabel.Text = "0:0";
            // 
            // Savebutton
            // 
            this.Savebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Savebutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Savebutton.Font = new System.Drawing.Font("Magneto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savebutton.Location = new System.Drawing.Point(809, 537);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(179, 61);
            this.Savebutton.TabIndex = 7;
            this.Savebutton.Text = "Сохранить игру";
            this.Savebutton.UseVisualStyleBackColor = false;
            // 
            // Infobutton
            // 
            this.Infobutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Infobutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Infobutton.Font = new System.Drawing.Font("Magneto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Infobutton.Location = new System.Drawing.Point(809, 428);
            this.Infobutton.Name = "Infobutton";
            this.Infobutton.Size = new System.Drawing.Size(179, 61);
            this.Infobutton.TabIndex = 8;
            this.Infobutton.Text = "Информация об игре";
            this.Infobutton.UseVisualStyleBackColor = false;
            this.Infobutton.Click += new System.EventHandler(this.button5_Click);
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Font = new System.Drawing.Font("Magneto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountLabel.Location = new System.Drawing.Point(106, 301);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(0, 24);
            this.CountLabel.TabIndex = 9;
            // 
            // Infolabel
            // 
            this.Infolabel.AutoSize = true;
            this.Infolabel.Font = new System.Drawing.Font("Magneto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Infolabel.Location = new System.Drawing.Point(374, 34);
            this.Infolabel.Name = "Infolabel";
            this.Infolabel.Size = new System.Drawing.Size(167, 24);
            this.Infolabel.TabIndex = 10;
            this.Infolabel.Text = "Текущее число:";
            // 
            // Inflabel
            // 
            this.Inflabel.AutoSize = true;
            this.Inflabel.Font = new System.Drawing.Font("Magneto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Inflabel.Location = new System.Drawing.Point(570, 34);
            this.Inflabel.Name = "Inflabel";
            this.Inflabel.Size = new System.Drawing.Size(21, 24);
            this.Inflabel.TabIndex = 11;
            this.Inflabel.Text = "1";
            // 
            // FormQuadShulte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1012, 681);
            this.Controls.Add(this.Inflabel);
            this.Controls.Add(this.Infolabel);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.Infobutton);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.Rulebutton);
            this.Controls.Add(this.Downloadbutton);
            this.Controls.Add(this.NewGamebutton);
            this.Controls.Add(this.Errorlabel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1028, 720);
            this.MinimumSize = new System.Drawing.Size(1028, 720);
            this.Name = "FormQuadShulte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Квадрат Шульте";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormQuadShulte_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label Errorlabel;
        private System.Windows.Forms.Button NewGamebutton;
        private System.Windows.Forms.Button Downloadbutton;
        private System.Windows.Forms.Button Rulebutton;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.Button Infobutton;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label Infolabel;
        private System.Windows.Forms.Label Inflabel;
    }
}