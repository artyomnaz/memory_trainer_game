using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Trainer.Memory_matrix
{
    public partial class FormMemoryMatrix : Form
    {
        private DataGridView FigureGrid;
        private int Lives; 

        public FormMemoryMatrix()
        {
            InitializeComponent();
            FigureGrid = new DataGridView();
            FigureGrid.Parent = this;
        }

        private void FormMemoryMatrix_Load(object sender, EventArgs e)
        {
            FigureGrid.ColumnCount = 3;
            for (int i = 0; i < 3; i++)
            {
                var row = new DataGridViewRow();
                for (int j = 0; j < 3; j++)
                {
                    var cell = new DataGridViewTextBoxCell();
                    cell.Value = " ";
                    row.Cells.Add(cell);

                }
                FigureGrid.Rows.Add(row);
            }
    
            FigureGrid.Width = 530;
            FigureGrid.Height = 530;
            FigureGrid.Top = this.Height / 2 - FigureGrid.Height / 2;
            FigureGrid.Left = this.Width / 2 - FigureGrid.Width / 2;
            FigureGrid.GridColor = Color.MistyRose;
            FigureGrid.BorderStyle = BorderStyle.Fixed3D;

            FigureGrid.RowHeadersVisible = false;
            FigureGrid.ColumnHeadersVisible = false;

            for (int i = 0; i < FigureGrid.RowCount - 1; i++){
                FigureGrid.Rows[i].Height = FigureGrid.Width / 3 - 1;
                FigureGrid.Columns[i].Width = FigureGrid.Height / 3 - 1;
                for (int j = 0; j < FigureGrid.ColumnCount; j++)
                    FigureGrid.Rows[i].Cells[j].Selected = false;
            }

            FigureGrid.ReadOnly = true;
            FigureGrid.AllowUserToResizeRows = false;
            FigureGrid.AllowDrop = false;
            FigureGrid.AllowUserToAddRows = false;
            FigureGrid.AllowUserToDeleteRows = false;
            FigureGrid.AllowUserToOrderColumns = false;
            FigureGrid.AllowUserToResizeColumns = false;
            FigureGrid.AllowUserToResizeRows = false;
            //FigureGrid.Rows[0].Cells[0].Style.BackColor = Color.Green;

        }
    }
}
