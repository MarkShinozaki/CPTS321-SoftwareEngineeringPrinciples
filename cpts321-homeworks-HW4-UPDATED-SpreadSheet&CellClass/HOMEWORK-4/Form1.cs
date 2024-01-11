// Mark Shinozaki 
// 11672355

namespace Homework4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using HW4_Cell;
    using HW4_Spreadsheet;

    /// <summary>
    /// Class declarations.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initialize the data in sheet.
        /// </summary>
        private readonly Spreadsheet mySheet = new Spreadsheet(50, 26);

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.mySheet.CellPropertyChange += this.Cell_attribute;
        }

        /// <summary>
        /// Demo for the spreadsheet.
        /// </summary>
        /// <param name="sender">The parameter is not used. </param>
        /// <param name="e">The parameter is not used. </param>
        public void PerformDemo(object sender, EventArgs e)
        {
            Random myRnd = new Random();

            for (int myNumber = 0; myNumber < 49; myNumber++)
            {
                this.mySheet.GetCell(myRnd.Next(0, 49), myRnd.Next(0, 25)).Text = "I love C#!";
            }

            for (int myNumber = 0; myNumber <= 49; myNumber++)
            {
                this.mySheet.GetCell(myNumber, 0).Text = $"THIS IS CELL A{myNumber + 1}";
            }

            for (int myNumber = 0; myNumber <= 49; myNumber++)
            {
                this.mySheet.GetCell(myNumber, 1).Text = $"THIS IS CELL B{myNumber + 1}";
            }
        }

        /// <summary>
        /// The event that is triggered when the form is created.
        /// </summary>
        /// <param name="sender">Cell value.</param>
        /// <param name="e"> Property change event. </param>
        private void Cell_attribute(object sender, PropertyChangedEventArgs e)
        {
            var myCell = sender as Cell;

            if (e.PropertyName == "Value")
            {
                this.dataGrid[myCell.MyColumn, myCell.MyRow].Value = myCell.Value;
            }
            else if (e.PropertyName == "Text")
            {
                this.dataGrid[myCell.MyColumn, myCell.MyRow].Value = myCell.Text;
            }
        }

        /// <summary>
        /// setup the columns,rows and resize the row headers.
        /// </summary>
        /// <param name="sender">The parameter is not used. </param>
        /// <param name="e">The parameter is not used. </param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGrid.ColumnCount = 26;
            char myChar;
            int myColumn = 0;
            for (myChar = 'A'; myChar <= 90; myChar++)
            {
                this.dataGrid.Columns[myColumn].Name = myChar.ToString();
                myColumn++;
            }

            for (int myRow = 1; myRow <= 50; myRow++)
            {
                this.dataGrid.Rows.Add();
                this.dataGrid.Rows[myRow - 1].HeaderCell.Value = myRow.ToString();
            }

            this.dataGrid.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        /// <summary>
        /// Start compiling the event and display the text at edit time.
        /// </summary>
        /// <param name="sender">The parameter is not used. </param>
        /// <param name="e">Cell cancels event parameters.</param>
        private void CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.dataGrid[e.ColumnIndex, e.RowIndex].Value = this.mySheet.GetCell(e.RowIndex, e.ColumnIndex).Text;
        }

        /// <summary>
        /// End edit event.
        /// </summary>
        /// <param name="sender">The parameter is not used. </param>
        /// <param name="e">Cell event parameters. </param>
        private void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // if expression then show value
            var myVal = this.dataGrid[e.ColumnIndex, e.RowIndex].Value;
            if (myVal != null)
            {
                Cell cell = this.mySheet.GetCell(e.RowIndex, e.ColumnIndex);
                cell.Text = myVal.ToString();
            }
        }

        /// <summary>
        /// Nonsense operation.
        /// </summary>
        /// <param name="sender">Load File parameter.</param>
        /// <param name="e">The parameter is not used. </param>
        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
