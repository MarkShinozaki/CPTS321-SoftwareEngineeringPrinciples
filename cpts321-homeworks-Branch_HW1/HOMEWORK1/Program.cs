// Mark Shinozaki 
// 011672355
using System;



// 1. Get a list of integer numbers from the user on A SINGLE LINE
// - The numbers will be in the range [0,100]
// - The numbers will be separated by spaces
// - You may assume that the user enters a correctly formatted input string that meets these requriments 
// - you may use Console.ReadLine or a similar method to get unput from the user

// 2. Add all the numbers to a binary search tree (you must implement your own BST) in the order
//    they were entered 
// - Dont allow duplicated 
// - use the split function on the entered string for easy parsing (split on the space character)

// 3. Display the numbers in sorted order(smallest first, largest last)
// - Traverse the tree in order to produce this output    

// 4. Display the following statistics about the tree 
// - number of items(note that this will be less than or equak to the number of items entered by the user,
//   since duplicates won't be added to the tree). Write a function that determines this from your BST, NOT
//   the array returned from the split. In other words, you must have a Count function in your BST implementation
//   (you are not allowed to use any existing implementaion for that).
// - Number of levels in the tree. A tree with no nodes at all has 0 levels. A tree with a single node has 1 level.
//   A tree with 2 nodes has 2 levels. A tree with three nodes could have 2 or 3 levels. You should know why this is//   from your advanced data structures prerequisite course.
// - Theoretical minimum number of levels that the tree could have given the number of nodes it contains

      

namespace hw1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

  
    public class Program
    {
        
        static void Main(string[] args)
        {
            
            IntBinaryTree tree = new IntBinaryTree();

         
            Console.WriteLine("Enter a collection of numbers in the range [0, 100], seperated by spaces: ");
            int[] userInput = GetLine();

            
            foreach (int i in userInput)
            {
                tree.insert(i);
            }

            
            tree.display();
            Console.WriteLine();


            Console.WriteLine("Tree statistics:");
           
            int treeCount = tree.Count();
            Console.WriteLine("\tNumber of nodes: " + treeCount);

           
            int height = tree.height(tree.root);
            Console.WriteLine("\tnumber of levels: " + height);


            Console.WriteLine("\tminimum number of levels that a tree with " + treeCount + " nodes could have is " + Math.Floor(Math.Log(treeCount, 2) + 1));

            Console.WriteLine("DONE");
        }

       
        static int[] GetLine()
        {
            string rawInput = Console.ReadLine();
            string[] tokens = rawInput.Split();
            int[] inputIntegerList = Array.ConvertAll(tokens, int.Parse);
            return inputIntegerList;
        }
    }


    class IntNode
    {
        private int number;
        public IntNode rightLeaf;
        public IntNode leftLeaf;

        public IntNode(int value)
        {
            number = value;
            rightLeaf = null;
            leftLeaf = null;
        }

       
        public void insertData(ref IntNode node, int data)
        {
            if (node == null)
            {
                node = new IntNode(data);
                

            }
            else if (node.number < data)
            {
                insertData(ref node.rightLeaf, data);
            }

            else if (node.number > data)
            {
                insertData(ref node.leftLeaf, data);
            }
        }

    
        public void display(IntNode n)
        {
            if (n == null)
                return;

            display(n.leftLeaf);
            Console.Write(" " + n.number);
            display(n.rightLeaf);
        }

    }


    class IntBinaryTree
    {
        public IntNode root;
        private int count;

        public IntBinaryTree()
        {
            root = null;
            count = 0;
        }

       
        public bool isEmpty()
        {
            return root == null;
        }

      
        public void insert(int d)
        {
            
            if (isEmpty())
            {
                count = 0;
                root = new IntNode(d);
                //count = 0;
            }

            else
            {

                root.insertData(ref root, d);
                count++;
                
            }

            
        }

       
        public int height(IntNode node)
        {
            var result = 0;

            if (node != null)
            {
                result = Math.Max(height(node.leftLeaf), height(node.rightLeaf)) + 1;
                
            }

            return result;
        }

        
        public void display()
        {
            if (!isEmpty())
                root.display(root);
        }

       
        public int Count()
        {
            return count - 1;
        }
    }
}