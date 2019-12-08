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
        private int n;
        private int m;
        private int[][] pos;

        public FormMemoryMatrix()
        {
            InitializeComponent();
            FigureGrid = new DataGridView();
            FigureGrid.Parent = this;
            n = 5;
            m = (int)(n * n * 0.25);
            pos = new int[n][];
            FigureGrid.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                pos[i] = new int[n];
                var row = new DataGridViewRow();
                for (int j = 0; j < n; j++)
                {
                    pos[i][j] = 0;
                    var cell = new DataGridViewTextBoxCell();
                    row.Cells.Add(cell);
                }
                FigureGrid.Rows.Add(row);
            }  
        }
        
        private void FormMemoryMatrix_Load(object sender, EventArgs e)
        {
            FigureGrid.Width = 2 * this.Height / 3;
            FigureGrid.Height = 2 * this.Height / 3;
            FigureGrid.Top = this.Height / 2 - FigureGrid.Height / 2;
            FigureGrid.Left = this.Width / 2 - FigureGrid.Width / 2;
            FigureGrid.GridColor = Color.DarkGray;
            FigureGrid.BorderStyle = BorderStyle.Fixed3D;

            FigureGrid.RowHeadersVisible = false;
            FigureGrid.ColumnHeadersVisible = false;

            FigureGrid.ScrollBars = ScrollBars.None;
            FigureGrid.MultiSelect = false;
            FigureGrid.CellClick += onClick;

            RandomPosition();

            for (int i = 0; i < n; i++){
                FigureGrid.Rows[i].Height = FigureGrid.Height / n;
                FigureGrid.Columns[i].Width = FigureGrid.Width / n;
                for (int j = 0; j < n; j++)
                {
                    FigureGrid.Rows[i].Cells[j].Selected = false;
                    if (pos[i][j] == 1)
                        FigureGrid.Rows[i].Cells[j].Style.BackColor = Color.IndianRed;
                    else FigureGrid.Rows[i].Cells[j].Style.BackColor = Color.WhiteSmoke;
                }
            }
            FigureGrid.ReadOnly = true;
            FigureGrid.AllowUserToResizeRows = false;
            FigureGrid.AllowDrop = false;
            FigureGrid.AllowUserToAddRows = false;
            FigureGrid.AllowUserToDeleteRows = false;
            FigureGrid.AllowUserToOrderColumns = false;
            FigureGrid.AllowUserToResizeColumns = false;
            FigureGrid.AllowUserToResizeRows = false;
            FigureGrid.DefaultCellStyle.SelectionBackColor = Color.Transparent;

        }

        private void onClick(object sender, EventArgs e)
        {
            int i = (sender as DataGridView).CurrentCell.RowIndex;
            int j = (sender as DataGridView).CurrentCell.ColumnIndex;
            
            FigureGrid.Rows[i].Cells[j].Style.SelectionBackColor = Color.Transparent;
        }

        private void RandomPosition()
        {
            var r = new int[m];
            Random random = new Random();
            for (int i = 0; i < m; i++) {
                r[i] = random.Next(n * n);
                for (int j = 0; j < i; j++)
                    if (r[i] == r[j])
                    {
                        r[i] = random.Next(n * n);
                        i--;
                    }
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < m; k++) 
                        if (r[k] == i * n + j)
                            pos[i][j] = 1;
        }
    }
}
