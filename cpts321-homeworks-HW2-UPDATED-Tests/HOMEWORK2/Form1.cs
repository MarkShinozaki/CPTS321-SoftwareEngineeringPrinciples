using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Status;


namespace HW2 // collection of classes
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            
            
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> RandomInts = new List<int>(); // instantiate the list to hold random numbers
            int Length = 10000;
            int Max = 20000;
            RunDistinctIntegers(RandomInts, Length, Max);

            // 1. HASH SET METHOD
            int ListHash = 0;
            ListHash = HashList(RandomInts);
            this.outputBox.AppendText("1. HashSet method: " + ListHash + " unique numbers" +
                            "\r\n Inserting every element into the list is n inserts, if a key already exists then its O(1) operation " +
                            "a bad hash is O(n) so when checking for keys we stick with O(1), getting the size of the hash can be O(1)  " +
                            "but we'll assume it isn't O(1), which means we have to do a count which is O(n), from O(n), from inserts and counting  " +
                            "the hash size = O(2n) which is just linear time or O(n) \r\n");


            // 2. O(1) STORAGE METHOD
            ListHash = HashStorage(RandomInts, Length);
            this.outputBox.AppendText("\n2. O(1) Storage method: " + ListHash + " unique Numbers\n");

            // 3. SORTED METHOD
            ListHash = Sorted(RandomInts, Length);
            this.outputBox.AppendText("\r\n3. Sorted method: " + ListHash + " unique Numbers\r\n");


        }

        // setting List 
        private static void RunDistinctIntegers(List<int> IntList, int Length, int Max)
        {
            // Random integers 
            Random Rand = new Random();
            int i = 0;
            int number = 0;

            while (i < Length)
            {
                number = Rand.Next(0, Max);
                IntList.Add(number);
                i++;
            }


        }


        private int HashList(List<int> IntList)
        {
            // 1. HASH SET METHOD
            Dictionary<string, int> map = new Dictionary<string, int>();
            foreach (int number in IntList)
            {
                if (!map.ContainsKey(number.ToString()))
                {
                    map.Add(number.ToString(), number);
                }
            }
            return map.Count;

        }



        private int HashStorage(List<int> IntList, int Length)
        {
            // 2. O(1) storage Method

            int count = 0;
            int i = 0, j = 0;
            while (i < Length)
            {
                count++;
                j = i + 1;
                while (j < Length)
                {
                    if (IntList[i] == IntList[j])
                    {
                        count--;
                        j = Length;
                    }
                    j++;
                }
                i++;
            }
            return count;


        }

        //[TestFixture]//
        //private int HashStorage(List<int> IntList, int Length)
        //{
        //    // 2. O(1) storage Method

        //    int count = 0;
        //    int i = 0, j = 0;
        //    while (i < Length)
        //    {
        //        count++;
        //        i = j + 1;
        //        while (j < Length)
        //        {
        //            if (IntList[i] == IntList[j])
        //            {
        //                count--;
        //                j = Length;
        //            }
        //            i++;
        //        }
        //        j++;
        //    }
        //    return count;
        //}



        private int Sorted(List<int> IntList, int Length)
        {
            // 3. Random sort

            int count = Length;
            IntList.Sort();
            int i = 0;
            while (i < Length - 1)
            {
                if (IntList[i] == IntList[i + 1])
                {
                    count--;
                }
                i++;
            }
            return count;


        }

        ////[TestFixture]//
        //private int Sorted(List<int> IntList, int Length)
        //{
        //    // 3. Random sort

        //    int count = Length;
        //    IntList.Sort();
        //    int i = 0;
        //    while (i < Length - 2)
        //    {
        //        if (IntList[i] == IntList[i + 2])
        //        {
        //            i--;
        //        }
        //        count++;
        //    }
        //    return i;


        //}


    }



}
   



