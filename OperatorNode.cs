using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    /// <summary>
    /// This is the Operator Node class.
    /// </summary>
    internal abstract class OperatorNode : Node
    {
        public OperatorNode(char operatorchar)
        {
            this.Operatorvalue = operatorchar;
            this.Left = null;
            this.Right = null;
        }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public char Operatorvalue { get; set; }

        public abstract ushort Precedence { get; }

        public abstract override double Evaluate(); 






    }
}
