// <copyright file="SpreadsheetCell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Mark Shinozaki
// 11672355

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Spreadsheet cell class. Made to use in 2D array in spreadsheet.
    /// </summary>
    public class SpreadsheetCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// Spreadsheet cell class. made to use in 2D array in spreadsheet.
        /// </summary>
        /// <param name="rowIndex">row index. </param>
        /// <param name="columnIndex"> column index.</param>
        /// <param name="text">cell text.</param>
        public SpreadsheetCell(int rowIndex, int columnIndex, string text)
            : base(rowIndex, columnIndex, text)
        {
        }

        /// <summary>
        /// Returns the corresponding cell if found.
        /// </summary>
        /// <param name="rowIndex">row index.</param>
        /// <param name="columnIndex">column index.</param>
        /// <returns> The requested cell. </returns>
        public SpreadsheetCell GetCell(int rowIndex, int columnIndex)
        {
            if (this.RowIndex == rowIndex && this.Columnindex == columnIndex)
            {
                return this;
            }

            return null;
        }

        /// <summary>
        /// Creates a deep copy of the current SpreadsheetCell instance.
        /// </summary>
        /// <returns>A new SpreadsheetCell instance that is a deep copy of the original cell.</returns>
        public SpreadsheetCell DeepCopy()
        {
            SpreadsheetCell cell = new SpreadsheetCell(this.RowIndex, this.Columnindex, this.cellText);
            cell.value = this.value;
            cell.CellsThatReference = this.CellsThatReference;
            cell.BGColor = this.BGColor;

            return cell;

        }
    }
}
