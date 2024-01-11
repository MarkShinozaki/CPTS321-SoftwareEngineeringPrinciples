
namespace Homework4
{
    using SpreadsheetEngine;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the Tree demo class.
    /// </summary>
    static class TreeDemo
    {
        /// <summary>
        /// This is the main function of the console application.
        /// </summary>
        public static void Main(string[] args)
        {
            string menuOption = string.Empty;
            string currentExpression = string.Empty;
            bool quitSelected = false;

            Console.WriteLine("Enter an expression: ");
            currentExpression = Console.ReadLine();
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree(currentExpression);

            do
            {
                PrintMenu(currentExpression);
                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        Console.WriteLine("Enter an expression: ");
                        currentExpression = Console.ReadLine();
                        tree = new SpreadsheetEngine.ExpressionTree(currentExpression);
                        break;
                    case "2":
                        Console.Write("Enter variable name: ");
                        string varName = Console.ReadLine();
                        Console.Write("Enter variable value: ");
                        string varValue = Console.ReadLine();
                        tree.SetVariable(varName, double.Parse(varValue));
                        break;
                    case "3":
                        Console.WriteLine($"{tree.Evaluate()}");
                        break;
                    case "4":
                        quitSelected = true;
                        break;
                    default:
                        break;
                }
            }
            while (quitSelected == false);
        }

        /// <summary>
        /// Prints menu of options.
        /// </summary>
        /// <param name="currentExpression">Expression in tree.</param>
        public static void PrintMenu(string currentExpression)
        {
            Console.WriteLine($"\nMenu (current expression - {currentExpression})");
            Console.WriteLine("\t1 - Enter a new expression");
            Console.WriteLine("\t2 - Set a variable value");
            Console.WriteLine("\t3 - Evaluate tree");
            Console.WriteLine("\t4 - Quit");
        }

    }
}
