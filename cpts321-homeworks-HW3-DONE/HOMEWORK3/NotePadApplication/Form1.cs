using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

// Mark Shinozaki 
// 11672355


namespace NotePadApplication
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private static OpenFileDialog openFileDialog = new OpenFileDialog();
        
        /// <summary>
        /// 
        /// </summary>
        private static SaveFileDialog saveFileDialog = new SaveFileDialog();
      
        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outputBox_TextChanged(object sender, EventArgs e)
        {
        }


        // this class loads text and writes it to the TextBox

        private void LoadText(TextReader sr)
        {
            // This class loads the text and writes it to the output box 
            this.outputBox.Text = sr.ReadToEnd();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // if the user clicks on the "Load from file" option
        private void loadFromFileTool(object sender, EventArgs e) 
        {
            openFileDialog.Filter = "Text Files | *.txt";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Title = "Open File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader outfile = new StreamReader(openFileDialog.FileName))
                {
                    
                    this.LoadText(outfile);
                }
            }
                




        }






        // if the user clicks on the "Save to file" option
        private void saveTool(object sender, EventArgs e) // saveToolStripMenuItem_Click
        {
            // instantiate with saving class
            SaveFileDialog saveFileDialogBox = new SaveFileDialog();

            saveFileDialogBox.Filter = "Text Files | *.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Title = "Save File";
            
            saveFileDialogBox.RestoreDirectory = true;

            // when the user presses ok 
            if (saveFileDialogBox.ShowDialog() == DialogResult.OK)
            {
                // opens the specified file name 
                using (StreamWriter outfile = new StreamWriter(saveFileDialogBox.FileName))
                {
                    // writes to the file
                    outfile.Write(this.outputBox.Text);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // This class is for the Load Fibonacci number (first 50) optiion
        private void loadFibonacci100(object sender, EventArgs e) 
        {
            
            // FibonacciTextReader instantiated as an boject with 50 lines 
            FibonacciTextReader NewFib = new FibonacciTextReader(100);

            // load text
            this.LoadText(NewFib);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // This class is for the Load Fibonacci number (first 100) optiion
        private void loadFibonacci50(object sender, EventArgs e) 
        {
            // FibonacciTextReader instantiated as an boject with 100 lines 
            FibonacciTextReader NewFib = new FibonacciTextReader(50);

            // load text
            this.LoadText(NewFib);
        }

        




    }

    

       



    



}




















