
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
    internal class TreeDemo
    {
        /// <summary>
        /// This is the main function of the console application.
        /// </summary>
        private static void Main()
        {
            int result = 0;
            int quit = 0;
            string variableName = null;
            string currentExpression = null;
            double declaredValue = 0.0;
            ExpressionTree demoTree = new ExpressionTree(null);
            while (quit == 0)
            {
                Console.WriteLine("menue current expression: {0}", currentExpression);
                Console.WriteLine("1. enter a new expression");
                Console.WriteLine("2. set a variable value");
                Console.WriteLine("3. Evalute Tree");
                Console.WriteLine("4. Quit");
                result = Convert.ToInt32(Console.ReadLine());
                if (result == 1)
                {
                    Console.WriteLine("enter the expression");
                    currentExpression = Console.ReadLine();
                    demoTree = new ExpressionTree(currentExpression);
                }
                else if (result == 2)
                {
                    Console.WriteLine("enter the variable");
                    variableName = Console.ReadLine();
                    Console.WriteLine("enter the value");
                    declaredValue = Convert.ToDouble(Console.ReadLine());
                    demoTree.SetVariable(variableName, declaredValue);
                }
                else if (result == 3)
                {
                    Console.WriteLine("result for Evaluation");
                    Console.WriteLine(demoTree.Evaluate());
                }
                else if (result == 4)
                {
                    quit = 1;
                }
            }
        }
    }
}
