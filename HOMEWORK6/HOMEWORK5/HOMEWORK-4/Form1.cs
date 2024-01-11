// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Mark Shinozaki
// 11672355

namespace Homework4
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using SpreadsheetEngine;

    /// <summary>
    /// Form1 class.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Spreadsheet of cells.
        /// </summary>
        private Spreadsheet spreadsheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            // initialize the form
            this.InitializeComponent();
            this.spreadsheet = new Spreadsheet(50, 26);
            this.InitializeRowsCols();
            this.spreadsheet.PropertyChanged += this.CellPropertyChanged;
        }

        /// <summary>
        /// Initializes the rows and columns of the data view.
        /// </summary>
        private void InitializeRowsCols()
        {
            this.ResetDataGridView();

            for (char columnLetter = 'A'; columnLetter <= 'Z'; columnLetter++)
            {
                this.dataGridView1.Columns.Add(columnLetter.ToString(), columnLetter.ToString());
            }

            for (int rowNumber = 1; rowNumber <= 50; rowNumber++)
            {
                /*DataGridViewRow newRow = new DataGridViewRow();
                newRow.HeaderCell.Value = rowNumber.ToString();*/
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[rowNumber - 1].HeaderCell.Value = rowNumber.ToString();
            }

            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                {
                    this.dataGridView1[i, j].Value = this.spreadsheet.GetCell(j, i).Value;
                }
            }
        }

        /// <summary>
        /// Resets any existing columns and rows from the form.
        /// </summary>
        private void ResetDataGridView()
        {
            this.dataGridView1.CancelEdit();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.DataSource = null;
        }

        /// <summary>
        /// Called whenever cell value is changed in spreadsheet.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Event argument.</param>
        private void DataGridView1_CellValueChanged(object sender, PropertyChangedEventArgs e)
        {
            var cell = sender as Cell;

            this.dataGridView1.Rows[cell.RowIndex].Cells[cell.Columnindex].Value = cell.Value;

            // this.spreadsheet.UpdateCell(cell.RowIndex, cell.ColumnIndex, cell.Value.ToString());
        }

        /// <summary>
        /// Called when cell property is changed.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Event argument.</param>
        private void CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell thisCell = (Cell)sender;

            int columnIndex = thisCell.Columnindex;
            int rowIndex = thisCell.RowIndex;

            this.dataGridView1[columnIndex, rowIndex].Value = thisCell.Value;
        }

        /// <summary>
        /// Called when demo button is clicked.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Event argument.</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            /*var rand = new Random();

            for (int rowNumber = 0; rowNumber < 50; rowNumber++)
            {
                this.dataGridView1[1, rowNumber].Value = $"This is cell B{rowNumber + 1}";
                this.dataGridView1[0, rowNumber].Value = this.dataGridView1[1, rowNumber].Value;

                int randomRow = rand.Next(0, 49);
                int randomCol = rand.Next(2, 25);
                this.dataGridView1[randomCol, randomRow].Value = "Go Cougs!";
            }*/

            this.spreadsheet.DemoProgram();
        }

        /// <summary>
        /// Called when a cell enters edit state.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Event argument.</param>
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.dataGridView1[e.ColumnIndex, e.RowIndex].Value = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).CellText;
        }

        /// <summary>
        /// Called when a cell exits edit state.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Event argument.</param>
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
            {
                this.spreadsheet.UpdateCell(e.RowIndex, e.ColumnIndex, this.dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
            }
            else
            {
                this.spreadsheet.UpdateCell(e.RowIndex, e.ColumnIndex, string.Empty);
            }

            this.dataGridView1[e.ColumnIndex, e.RowIndex].Value = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).Value;
        }
    }
}
