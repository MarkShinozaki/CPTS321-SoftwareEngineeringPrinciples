using System.Windows.Forms;

namespace NotePadApplication
{
    partial class Form1
    {

        // <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// loads outputbox
        /// </summary>
        private System.Windows.Forms.TextBox outputBox;


        /// <summary>
        /// setsup menu strip
        /// </summary>
        private System.Windows.Forms.MenuStrip menutexture;


        /// <summary>
        /// load file button
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem file_Menu_Item;


        /// <summary>
        /// load menu strip
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem LoadFile_Menu;


        /// <summary>
        /// load 50
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem LoadFibonacci_Menu;


        /// <summary>
        /// load 100 
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem LoadFibonacci_first100;


        /// <summary>
        /// Save menu
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem saveTool_Menu;








        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows that Form Designer Generates


        private void InitializeComponent()
        {
            this.outputBox = new System.Windows.Forms.TextBox();
            this.menutexture = new System.Windows.Forms.MenuStrip();
            this.file_Menu_Item = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFile_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFibonacci_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFibonacci_first100 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTool_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.menutexture.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputBox
            // 
            this.outputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputBox.Location = new System.Drawing.Point(0, 33);
            this.outputBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputBox.Size = new System.Drawing.Size(602, 392);
            this.outputBox.TabIndex = 0;
            // 
            // menutexture
            // 
            this.menutexture.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menutexture.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menutexture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_Menu_Item});
            this.menutexture.Location = new System.Drawing.Point(0, 0);
            this.menutexture.Name = "menutexture";
            this.menutexture.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menutexture.Size = new System.Drawing.Size(602, 33);
            this.menutexture.TabIndex = 1;
            this.menutexture.Text = "menutexture";
            // 
            // file_Menu_Item
            // 
            this.file_Menu_Item.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFile_Menu,
            this.LoadFibonacci_Menu,
            this.LoadFibonacci_first100,
            this.saveTool_Menu});
            this.file_Menu_Item.Name = "file_Menu_Item";
            this.file_Menu_Item.Size = new System.Drawing.Size(54, 29);
            this.file_Menu_Item.Text = "File";
            // 
            // LoadFile_Menu
            // 
            this.LoadFile_Menu.Name = "LoadFile_Menu";
            this.LoadFile_Menu.Size = new System.Drawing.Size(395, 34);
            this.LoadFile_Menu.Text = "Load from file";
            this.LoadFile_Menu.Click += new System.EventHandler(this.loadFromFileTool);
            // 
            // LoadFibonacci_Menu
            // 
            this.LoadFibonacci_Menu.Name = "LoadFibonacci_Menu";
            this.LoadFibonacci_Menu.Size = new System.Drawing.Size(395, 34);
            this.LoadFibonacci_Menu.Text = "Loads Fibonacci numbers (first 50)...";
            this.LoadFibonacci_Menu.Click += new System.EventHandler(this.loadFibonacci50);
            // 
            // LoadFibonacci_first100
            // 
            this.LoadFibonacci_first100.Name = "LoadFibonacci_first100";
            this.LoadFibonacci_first100.Size = new System.Drawing.Size(395, 34);
            this.LoadFibonacci_first100.Text = "Loads Fibonacci numbers (first 100)...";
            this.LoadFibonacci_first100.Click += new System.EventHandler(this.loadFibonacci100);
            // 
            // saveTool_Menu
            // 
            this.saveTool_Menu.Name = "saveTool_Menu";
            this.saveTool_Menu.Size = new System.Drawing.Size(395, 34);
            this.saveTool_Menu.Text = "Save to file";
            this.saveTool_Menu.Click += new System.EventHandler(this.saveTool);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 425);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.menutexture);
            this.MainMenuStrip = this.menutexture;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Mark <3 - 11672355";
            this.menutexture.ResumeLayout(false);
            this.menutexture.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        











    }
}

