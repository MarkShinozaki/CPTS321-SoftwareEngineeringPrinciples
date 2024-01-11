using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    internal class AdditionOperatorNode : OperatorNode 
    {
        public AdditionOperatorNode()
            : base('+')
        {
        }

        public override ushort Precedence { get; } = 1;

        public override double Evaluate()
        {
            return this.Left.Evaluate() + this.Right.Evaluate();
        }
    }
}
