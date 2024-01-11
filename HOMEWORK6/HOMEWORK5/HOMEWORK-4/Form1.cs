// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Mark Shinozaki
// 11672355

namespace Homework4
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
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
        /// Old value of cell clicked.
        /// </summary>
        private string oldValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            // initialize the form
            this.InitializeComponent();
            this.spreadsheet = new Spreadsheet(50, 26);
            this.oldValue = string.Empty;
            this.InitializeRowsCols();
            this.spreadsheet.PropertyChanged += this.CellPropertyChanged;
            this.undoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Enabled = false;
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
                    this.dataGridView1[i, j].Style.BackColor = Color.FromArgb(unchecked((int)this.spreadsheet.GetCell(j, i).BGColor));
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

            if (e.PropertyName == "bgColor")
            {
                this.dataGridView1[columnIndex, rowIndex].Style.BackColor = Color.FromArgb(unchecked((int)this.spreadsheet.GetCell(rowIndex, columnIndex).BGColor));
            }
            else
            {
                this.dataGridView1[columnIndex, rowIndex].Value = thisCell.Value;
            }
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
            this.oldValue = (string)this.dataGridView1[e.ColumnIndex, e.RowIndex].Value;
        }

        /// <summary>
        /// Called when a cell exits edit state.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Event argument.</param>
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((string)this.dataGridView1[e.ColumnIndex, e.RowIndex].Value != this.oldValue)
            {
                SpreadsheetCell cell = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).DeepCopy();
                this.spreadsheet.AddUndo(cell, "text change");

                this.undoToolStripMenuItem.Enabled = true;
                this.undoToolStripMenuItem.Text = "Undo " + this.spreadsheet.PeekUndoChangeDetails();

                if (this.dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    this.spreadsheet.UpdateCell(e.RowIndex, e.ColumnIndex, this.dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
                }
                else
                {
                    this.spreadsheet.UpdateCell(e.RowIndex, e.ColumnIndex, string.Empty);
                }
            }

            this.dataGridView1[e.ColumnIndex, e.RowIndex].Value = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex).Value;
        }

        private void ChangeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = true;
            colorDialog.Color = this.dataGridView1.SelectedCells[0].Style.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < this.dataGridView1.SelectedCells.Count; i++)
                {
                    // this.dataGridView1.SelectedCells[i].Style.BackColor = colorDialog.Color;

                    int rowIndex = this.dataGridView1.SelectedCells[i].RowIndex;
                    int columnIndex = this.dataGridView1.SelectedCells[i].ColumnIndex;

                    SpreadsheetCell cell = this.spreadsheet.GetCell(rowIndex, columnIndex).DeepCopy();
                    this.spreadsheet.AddUndo(cell, "change background color");

                    this.undoToolStripMenuItem.Enabled = true;
                    this.undoToolStripMenuItem.Text = "Undo " + this.spreadsheet.PeekUndoChangeDetails();

                    this.spreadsheet.GetCell(rowIndex, columnIndex).BGColor =
                        (uint)((colorDialog.Color.A << 24) | (colorDialog.Color.R << 16) | (colorDialog.Color.G << 8) | (colorDialog.Color.B << 0));
                }
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.spreadsheet.GetUndoStackSize() > 0)
            {
                this.spreadsheet.ExecuteUndo();
                this.redoToolStripMenuItem.Enabled = true;
                this.redoToolStripMenuItem.Text = "Redo " + this.spreadsheet.PeekRedoChangeDetails();
            }

            if (this.spreadsheet.GetUndoStackSize() == 0)
            {
                this.undoToolStripMenuItem.Enabled = false;
                this.undoToolStripMenuItem.Text = "Undo";
            }
            else
            {
                this.undoToolStripMenuItem.Enabled = true;
                this.undoToolStripMenuItem.Text = "Undo " + this.spreadsheet.PeekUndoChangeDetails();
            }
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.spreadsheet.ExecuteRedo();

            if (this.spreadsheet.GetRedoStackSize() == 0)
            {
                this.redoToolStripMenuItem.Enabled = false;
                this.redoToolStripMenuItem.Text = "Redo";
            }
            else
            {
                this.redoToolStripMenuItem.Enabled = true;
                this.redoToolStripMenuItem.Text = "Redo " + this.spreadsheet.PeekRedoChangeDetails();
            }
        }
    }

}