// <copyright file="UndoNode.cs" company="PlaceholderCompany">
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
    /// Undo/Redo object to be used in undo and redo stacks.
    /// </summary>
    public class UndoNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UndoNode"/> class.
        /// </summary>
        /// <param name="undoRedoCell">Cell before changes.</param>
        /// <param name="changeDetails">Details of change.</param>
        public UndoNode(SpreadsheetCell undoRedoCell, string changeDetails)
        {
            this.OldCell = undoRedoCell;
            this.ChangeDetails = changeDetails;
        }

        /// <summary>
        /// Gets or sets copy of old cell.
        /// </summary>
        public SpreadsheetCell OldCell { get; set; }

        /// <summary>
        /// Gets or sets details of the changes made.
        /// </summary>
        public string ChangeDetails { get; set; }
    }
}
