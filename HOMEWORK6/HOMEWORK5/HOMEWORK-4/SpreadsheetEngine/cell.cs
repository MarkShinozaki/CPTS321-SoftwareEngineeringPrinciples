// <copyright file="cell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Mark Shinozaki
// 11672355

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using ExpressionLib;

    /// <summary>
    /// Cell class.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Text inside Cell.
        /// </summary>
        protected string cellText;

        /// <summary>
        /// The Cell Data value.
        /// </summary>
        protected string value;

        /// <summary>
        /// Row index of a cell.
        /// </summary>
        private readonly int rowIndex;

        /// <summary>
        /// Column index of a cell.
        /// </summary>
        private readonly int columnIndex;

        // Homework 8 - Update.

        /// <summary>
        /// Background color of cell.
        /// </summary>
        private uint bgColor;


        /// <summary>
        /// List of cells that reference this cell.
        /// </summary>
        private List<string> cellsThatReference = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="rowIndex">Get row index to my row. </param>
        /// <param name="columnIndex">Get column index to my column.</param>
        /// <param name="cellText">New Cell text.</param>
        public Cell(int rowIndex, int columnIndex, string cellText)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
            this.cellText = cellText;
            this.bgColor = 0xFFFFFFFF;
        }

        /// <summary>
        /// Events for property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Gets or Sets cellText.
        /// </summary>
        public string CellText
        {
            get
            {
                return this.cellText;
            }

            set
            {
                if (value != this.cellText)
                {
                    this.cellText = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("cellText"));
                }
            }
        }

        /// <summary>
        /// Gets or sets value.
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value != this.value)
                {
                    this.value = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("value"));
                }
            }
        }

        /// <summary>
        /// Gets or sets background color.
        /// </summary>
        public uint BGColor
        {
            get
            {
                return this.bgColor;
            }

            set
            {
                if (value != this.bgColor)
                {
                    this.bgColor = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("bgColor"));
                }
            }

        }




        /// <summary>
        /// Gets the column value then return to column index.
        /// </summary>
        public int Columnindex
        {
            get { return this.columnIndex; }
        }

        /// <summary>
        /// Gets the row value then return to row index.
        /// </summary>
        public int RowIndex
        {
            get { return this.rowIndex; }
        }

        /// <summary>
        /// Gets or sets list of cells that reference this cell.
        /// </summary>
        public List<string> CellsThatReference
        {
            get { return this.cellsThatReference; }
            set { this.cellsThatReference = value; }
        }
    }
}
