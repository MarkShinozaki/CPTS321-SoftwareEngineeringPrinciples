// Mark Shinozaki 
// 11672355

namespace HW4_Spreadsheet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using HW4_Cell;

    /// <summary>
    /// Spread sheet class.
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// Private data members.
        /// </summary>
        private readonly SheetCell[,] myCells;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="myRow">Define the number of rows.</param>
        /// <param name="myColumn">Define the number of columns.</param>
        public Spreadsheet(int myRow, int myColumn)
        {
            this.RowCount = myRow;
            this.myCells = new SheetCell[myRow, myColumn];

            for (int row = 0; row < myRow; row++)
            {
                for (int column = 0; column < myColumn; column++)
                {
                    this.myCells[row, column] = new SheetCell(row, column);

                    this.myCells[row, column].PropertyChanged += this.ChangeCell;
                }
            }
        }

        /// <summary>
        /// For delegate information Delegates (C# Programming Guide)
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChange = (sender, e) => { };

        /// <summary>
        /// Gets define the row count.
        /// </summary>
        private int RowCount { get; }

        /// <summary>
        /// Converts the coordinates of the cell to a string and sets the name of the cell.
        /// </summary>
        /// <param name="myRow">The number of rows.</param>
        /// <param name="myColumn">The number of columns.</param>
        /// <returns>A string of the cell.</returns>
        public static string CordsToName(int myRow, int myColumn)
        {
            string myCell = ((char)(myColumn + 65)).ToString();
            return myCell + (myRow + 1);
        }

        /// <summary>
        /// Get a cell from the spreadsheet.
        /// </summary>
        /// <param name="myRow">The number of rows.</param>
        /// <param name="myColumn">The number of columns.</param>
        /// <returns>Output the entire table.</returns>
        public Cell GetCell(int myRow, int myColumn)
        {
            return this.myCells[myRow, myColumn];
        }

        /// <summary>
        ///  The event that is triggered by changing the cell.
        /// </summary>
        /// <param name="sender">The parameters of the cell.</param>
        /// <param name="e">The parameter is not used.</param>
        private void ChangeCell(object sender, PropertyChangedEventArgs e)
        {
            var cell = sender as SheetCell;

            if (double.TryParse(cell.Text, out double value))
            {
                cell.Text = value.ToString();
            }
            else if (cell.Text[0] == '=')
            {
                Cell tempcell = this.NameCell(cell.Text);
                cell.Text = tempcell.Text;
            }
            else
            {
                cell.Text = cell.Text;
            }

            this.CellPropertyChange(sender as SheetCell, new PropertyChangedEventArgs("Text"));
        }

        /// <summary>
        /// Converts a string name to a cell object.
        /// </summary>
        /// <param name="cellName">sString name.</param>
        /// <returns>Cell object.</returns>
        private SheetCell NameCell(string cellName)
        {
            if (!char.IsLetter(cellName[1]))
            {
                return null;
            }

            int col = char.ToUpper(cellName[1]) - 65;
            bool isInt = int.TryParse(cellName.Substring(2), out int row);
            if (!isInt || row > this.RowCount)
            {
                return null;
            }

            return this.myCells[row - 1, col];
        }
    }

    /// <summary>
    /// Implement inside the spreadsheet.
    /// </summary>
    public class SheetCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SheetCell"/> class.
        /// </summary>
        /// <param name="rowIndex">Define row index.</param>
        /// <param name="columnIndex">Define column index. </param>
        public SheetCell(int rowIndex, int columnIndex)
            : base(rowIndex, columnIndex)
        {
        }
    }
}
