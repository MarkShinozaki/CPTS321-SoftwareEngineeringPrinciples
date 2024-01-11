// Mark Shinozaki 
// 11672355



namespace HW4_Cell
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using HW4_Spreadsheet;

    /// <summary>
    /// Cell class.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Row index of a cell.
        /// </summary>
        private int rowIndex;

        /// <summary>
        /// Column index of a cell.
        /// </summary>
        private int columnIndex;

        /// <summary>
        /// The text of a cell.
        /// </summary>
        private string text;

        /// <summary>
        /// The Cell Data value.
        /// </summary>
        private string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="rowIndex">Get row index to my row. </param>
        /// <param name="columnIndex">Get column index to my column.</param>
        public Cell(int rowIndex, int columnIndex)
        {
            this.MyRow = rowIndex;
            this.MyColumn = columnIndex;
        }

        /// <summary>
        /// Events for property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the row value then return to row index.
        /// </summary>
        public int MyRow
        {
            get
            {
                return this.rowIndex;
            }

            set
            {
                this.rowIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the column value then return to column index.
        /// </summary>
        public int MyColumn
        {
            get
            {
                return this.columnIndex;
            }

            set
            {
                this.columnIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the text, if value is not text,property change the value.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (value != this.text)
                {
                    this.text = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }

        /// <summary>
        ///  Gets or sets value, then just return it.
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
            }
        }
    }
}
