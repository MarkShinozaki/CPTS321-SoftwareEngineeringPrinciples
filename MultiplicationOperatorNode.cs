// Mark Shinozaki
// 11672355

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    internal class MultiplicationOperatorNode : OperatorNode
    {
        public MultiplicationOperatorNode()
            : base('*')
        {
        }

        /// <summary>
        /// Gets Overridden Precdence function.
        /// </summary>
        /// <returns>ushort of * operator precednce </returns>
        public override ushort Precedence { get; } = 2;

        public override double Evaluate()
        {
            return this.Left.Evaluate() * this.Right.Evaluate();
        }

    }
}
