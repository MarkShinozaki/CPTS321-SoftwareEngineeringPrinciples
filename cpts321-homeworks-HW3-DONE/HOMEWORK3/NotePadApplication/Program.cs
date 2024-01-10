// Mark Shinozaki
// 11672355

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace NotePadApplication
{
    internal static class Program
    {
        /// <summary>
        /// Starting of the APP
        /// </summary>
       

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
