// <copyright file="Spreadsheet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Mark Shinozaki
// 11672355

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using ExpressionLib;

    /// <summary>
    /// Spread sheet class.
    /// </summary>
    public class Spreadsheet : INotifyPropertyChanged
    {
        /// <summary>
        /// Number of rows.
        /// </summary>
        private int rows;

        /// <summary>
        /// Number of columns.
        /// </summary>
        private int columns;

        /// <summary>
        /// 2D array of SpreadsheetCells.
        /// </summary>
        private SpreadsheetCell[,] spreadsheetCells;

        /// <summary>
        /// Stack to hold undos.
        /// </summary>
        private Stack<UndoNode> undoStack;

        /// <summary>
        /// Stack to hold redos.
        /// </summary>
        private Stack<UndoNode> redoStack;

        /// <summary>
        /// Dictionary of cell values.
        /// </summary>
        private Dictionary<string, double> cellValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of columns.</param>
        public Spreadsheet(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.cellValues = new Dictionary<string, double>();
            this.undoStack = new Stack<UndoNode>();
            this.redoStack = new Stack<UndoNode>();
            this.InitializeSpreadsheetCells(rows, columns);
        }

        /// <summary>
        /// Public event called when cell is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Gets column count.
        /// </summary>
        public int ColumnCount
        {
            get { return this.columns; }
        }

        /// <summary>
        /// Gets row count.
        /// </summary>
        public int RowCount
        {
            get { return this.rows; }
        }

        /// <summary>
        /// Invoke the property changed event.
        /// </summary>
        /// <param name="sender">Sender of property.</param>
        /// <param name="e">Name of property.</param>
        public void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var cell = sender as SpreadsheetCell;
            if (e.PropertyName == "cellText")
            {
                /*if (cell.CellText[0] == '=')
                {
                    // cell.Value = cell.EvaluateText(cell.CellText);
                }
                else
                {
                    cell.Value = cell.CellText;
                }*/

                this.EvaluateCell(cell.RowIndex, cell.Columnindex, cell.CellText);

                this.PropertyChanged?.Invoke(sender, e);
            }
            else if (e.PropertyName == "value")
            {
                this.UpdateReferences(cell);

                this.PropertyChanged?.Invoke(sender, e);
            }
            else if (e.PropertyName == "bgColor")
            {
                this.PropertyChanged?.Invoke(sender, e);
            }
        }

        /// <summary>
        /// Ran when button is pressed.
        /// </summary>
        public void DemoProgram()
        {
            for (int i = 0; i < 50; i++)
            {
                this.spreadsheetCells[i, 1].CellText = $"This is cell {this.GetCellName(i, 1)}";
            }
        }

        /// <summary>
        /// Given a row and column index, returns the corresponding cell if found.
        /// </summary>
        /// <param name="rowIndex">Row index.</param>
        /// <param name="columnIndex">Column index.</param>
        /// <returns>The requested cell.</returns>
        public SpreadsheetCell GetCell(int rowIndex, int columnIndex)
        {
            if (this.spreadsheetCells[rowIndex, columnIndex] != null)
            {
                return this.spreadsheetCells[rowIndex, columnIndex];
            }

            return null;
        }

        /// <summary>
        /// Given a cell name, returns the corresponding cell if found.
        /// </summary>
        /// <param name="cellName">Name of cell.</param>
        /// <returns>The requested cell.</returns>
        public SpreadsheetCell GetCell(string cellName)
        {
            char letter = cellName[0];

            if ((letter >= 'A' && letter <= 'Z') && int.TryParse(cellName.Substring(1), out int number))
            {
                return this.spreadsheetCells[number - 1, (int)letter - 'A'];
            }

            return null;
        }

        /// <summary>
        /// Updates value of specified cell if found.
        /// </summary>
        /// <param name="rowIndex">Row index.</param>
        /// <param name="columnIndex">Column index.</param>
        /// <param name="value">Value of cell.</param>
        public void UpdateCell(int rowIndex, int columnIndex, string value)
        {
            if (this.spreadsheetCells[rowIndex, columnIndex] != null)
            {
                this.spreadsheetCells[rowIndex, columnIndex].CellText = value;
            }
        }

        /// <summary>
        /// Populate cell list in spreadsheet with the cell that references them.
        /// </summary>
        /// <param name="cellThatReferences">Cell with references.</param>
        /// <param name="references">Cells the cell refers to.</param>
        public void PopulateReferences(SpreadsheetCell cellThatReferences, List<string> references)
        {
            for (int refCell = 0; refCell < references.Count; refCell++)
            {
                if (this.GetCell(references[refCell]) != null && !this.GetCell(references[refCell]).CellsThatReference.Contains(this.GetCellName(cellThatReferences.RowIndex, cellThatReferences.Columnindex)))
                {
                    this.GetCell(references[refCell]).CellsThatReference.Add(this.GetCellName(cellThatReferences.RowIndex, cellThatReferences.Columnindex));
                }
            }
        }

        /// <summary>
        /// Updates cells that reference changed cell.
        /// </summary>
        /// <param name="cellWithReferences">Cell who's references need to be updated.</param>
        public void UpdateReferences(SpreadsheetCell cellWithReferences)
        {
            for (int refCell = 0; refCell < cellWithReferences.CellsThatReference.Count; refCell++)
            {
                SpreadsheetCell cell = this.GetCell(cellWithReferences.CellsThatReference[refCell]);
                this.EvaluateCell(cell.RowIndex, cell.Columnindex, cell.CellText);
            }
        }

        /// <summary>
        /// Get cell name of a given cell.
        /// </summary>
        /// <param name="rowIndex">Row index.</param>
        /// <param name="columnIndex">Column index.</param>
        /// <returns>Name of cell.</returns>
        public string GetCellName(int rowIndex, int columnIndex)
        {
            char columnName = (char)(columnIndex + 'A');
            return $"{columnName}" + $"{rowIndex + 1}";
        }

        /// <summary>
        /// Evaluate contents of cell and updates value.
        /// </summary>
        /// <param name="rowIndex">Row index.</param>
        /// <param name="columnIndex">Column index.</param>
        /// <param name="cellText">Cell text.</param>
        public void EvaluateCell(int rowIndex, int columnIndex, string cellText)
        {
            List<string> references = new List<string>();

            if (cellText == string.Empty)
            {
                this.cellValues[this.GetCellName(rowIndex, columnIndex)] = 0;
                this.GetCell(rowIndex, columnIndex).Value = cellText;
            }
            else if (cellText[0] == '=')
            {
                if (cellText.Length == 1)
                {
                    return;
                }

                cellText = cellText.Substring(1);
                ExpressionTree expTree = new ExpressionTree(cellText);
                expTree.Variables = this.cellValues;
                this.GetCell(rowIndex, columnIndex).Value = expTree.Evaluate().ToString();
                this.cellValues[this.GetCellName(rowIndex, columnIndex)] = expTree.Evaluate();
                references = expTree.ReferencedCells;
            }
            else
            {
                bool isNum = double.TryParse(cellText, out double num);

                if (isNum)
                {
                    this.cellValues[this.GetCellName(rowIndex, columnIndex)] = num;
                }
                else
                {
                    ExpressionTree expTree = new ExpressionTree(cellText);
                    expTree.Variables = this.cellValues;
                    this.GetCell(rowIndex, columnIndex).Value = expTree.Evaluate().ToString();
                    this.cellValues[this.GetCellName(rowIndex, columnIndex)] = expTree.Evaluate();
                    references = expTree.ReferencedCells;
                }

                this.GetCell(rowIndex, columnIndex).Value = cellText;
            }

            this.PopulateReferences(this.GetCell(rowIndex, columnIndex), references);
        }

        /// <summary>
        /// Get details of pending undo.
        /// </summary>
        /// <returns>Details of pending undo.</returns>
        public string PeekUndoChangeDetails()
        {
            if (this.undoStack.Count > 0)
            {
                return this.undoStack.Peek().ChangeDetails;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get details of pending redo.
        /// </summary>
        /// <returns>Details of pending redo.</returns>
        public string PeekRedoChangeDetails()
        {
            if (this.redoStack.Count > 0)
            {
                return this.redoStack.Peek().ChangeDetails;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets size of undo stack.
        /// </summary>
        /// <returns>Size of undo stack.</returns>
        public int GetUndoStackSize()
        {
            return this.undoStack.Count;
        }

        /// <summary>
        /// Gets size of redo stack.
        /// </summary>
        /// <returns>Size of redo stack.</returns>
        public int GetRedoStackSize()
        {
            return this.redoStack.Count;
        }

        /// <summary>
        /// Adds new undo redo object to undo stack.
        /// </summary>
        /// <param name="undoRedoCell">Cell in undo redo object.</param>
        /// <param name="changeDetails">Details of changes to undo.</param>
        public void AddUndo(SpreadsheetCell undoRedoCell, string changeDetails)
        {
            this.undoStack.Push(new UndoNode(undoRedoCell, changeDetails));
        }

        /// <summary>
        /// Adds new undo redo object to redo stack.
        /// </summary>
        /// <param name="undoRedo">Undo redo object.</param>
        public void AddRedo(UndoNode undoRedo)
        {
            this.redoStack.Push(undoRedo);
        }

        /// <summary>
        /// Executes undo and pushes undo redo object onto redo stack.
        /// </summary>
        public void ExecuteUndo()
        {
            if (this.undoStack.Count > 0)
            {
                var undoRedoObj = this.undoStack.Pop();
                int rowIndex = undoRedoObj.OldCell.RowIndex;
                int colIndex = undoRedoObj.OldCell.Columnindex;

                SpreadsheetCell cell = this.GetCell(rowIndex, colIndex).DeepCopy();

                this.GetCell(rowIndex, colIndex).CellText = undoRedoObj.OldCell.CellText;
                this.GetCell(rowIndex, colIndex).Value = undoRedoObj.OldCell.Value;
                this.GetCell(rowIndex, colIndex).BGColor = undoRedoObj.OldCell.BGColor;
                this.GetCell(rowIndex, colIndex).CellsThatReference = undoRedoObj.OldCell.CellsThatReference;

                this.AddRedo(new UndoNode(cell, undoRedoObj.ChangeDetails));
            }
        }

        /// <summary>
        /// Executes redo.
        /// </summary>
        public void ExecuteRedo()
        {
            if (this.redoStack.Count > 0)
            {
                var undoRedoObj = this.redoStack.Pop();
                int rowIndex = undoRedoObj.OldCell.RowIndex;
                int colIndex = undoRedoObj.OldCell.Columnindex;

                this.GetCell(rowIndex, colIndex).CellText = undoRedoObj.OldCell.CellText;
                this.GetCell(rowIndex, colIndex).Value = undoRedoObj.OldCell.Value;
                this.GetCell(rowIndex, colIndex).BGColor = undoRedoObj.OldCell.BGColor;
                this.GetCell(rowIndex, colIndex).CellsThatReference = undoRedoObj.OldCell.CellsThatReference;
            }
        }

        /// <summary>
        /// Initializes 2D array of SpreadsheetCells.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of columns.</param>
        private void InitializeSpreadsheetCells(int rows, int columns)
        {
            this.spreadsheetCells = new SpreadsheetCell[rows, columns];
            char columnName = 'A';

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                columnName = 'A';
                for (int columnIndex = 0; columnIndex < columns; columnIndex++, columnName++)
                {
                    this.spreadsheetCells[rowIndex, columnIndex] = new SpreadsheetCell(rowIndex, columnIndex, string.Empty);
                    this.cellValues[this.GetCellName(rowIndex, columnIndex)] = 0;
                    this.spreadsheetCells[rowIndex, columnIndex].PropertyChanged += this.NotifyPropertyChanged;
                    if (columnName >= 'Z')
                    {
                        break;
                    }
                }
            }
        }
    }
}
