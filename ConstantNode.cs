//Mark Shinozaki
// 11672355

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the Constant node class. holds a double for the node value.
    /// </summary>
    internal class ConstantNode : Node
    {
        private readonly double variableValue;

        public ConstantNode(double value)
        {
            this.variableValue = value;
        }

        public double ConstantGetSet
        {
            get { return variableValue; }
        }

        public override double Evaluate()
        {

            return this.variableValue;
        }








    }
}
