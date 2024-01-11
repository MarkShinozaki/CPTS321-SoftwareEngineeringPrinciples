

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    internal class SubtractionOperatorNode : OperatorNode
    {
        public SubtractionOperatorNode()
            : base('-')
        {

        }

        public override ushort Precedence { get; } = 1;

        public override double Evaluate()
        {
            return this.Left.Evaluate() - this.Right.Evaluate();
        }



    }
}
