// Mark Shinozaki
// 11672355

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace NotePadApplication
{

    /// <summary>
    /// Initalizes Fib Class
    /// </summary>
    public class FibonacciTextReader : TextReader
    {


        // Data Members 
        private int numLine = 0;
        private int currentLine = 0;


        /// <summary>
        /// Name: Fibonacci 
        /// Des: Initializes an instance of the <see cref="FibonacciTextReader"/> .
        /// </summary>
        /// <param name="numLines"> initializes Fibonacci with the number inputed</param>
        

        public FibonacciTextReader(int numLines)
        {
            this.numLine = numLines;
            this.currentLine = 1;
        }


        /// <summary>
        /// Name: FindFibonacci 
        /// Des: Find the Fibonacci of a BigInt
        /// </summary>
        /// <param name="number"></param> the BigInt num that you want to find the Fibonacci </param>
        /// <returns>returns first number </returns>
        public static BigInteger FindFibonacci(BigInteger number)
        {

            BigInteger first = 0, second = 1, i = 0, tempNumb = 0;

            while (i++ < number)
            {
                tempNumb = first;
                first = second;
                second = tempNumb + second;
            }

            return first;

        }




        /// <summary>
        /// Name: Readtoend
        /// Des: overrides the readtoend function so it can work with findfib
        /// </summary>
        /// <returns>returns fib</returns>
        public override string ReadToEnd()
        {
            StringBuilder result = new StringBuilder();

            for (int count = 1; count++ < this.numLine;)
            {
                //result.AppendLine(ReadLine());
                //increment currentLine

                if (this.currentLine <= this.numLine)
                {

                    //Converts CurrentLine to BigInt using constructor
                    //call find fib function to get fib but sub 1 due to line# starting at 1 but sequence starts at 0
                    result.Append("(" + this.currentLine.ToString() + ") - " + FindFibonacci(this.currentLine - 1).ToString() + Environment.NewLine);
                }
                else
                {
                    return null;
                }
               
                this.currentLine++;
            }

            return result.ToString();
        }















































    }

 }




