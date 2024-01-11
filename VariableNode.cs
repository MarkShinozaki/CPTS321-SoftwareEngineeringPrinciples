// Mark Shinozaki
// 11672355

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// This is the Variable Node class.
    /// </summary>
    internal class VariableNode : Node
    {
        private readonly string variableName;
        private readonly double variableValue;

        public VariableNode(string name, double value = 0)
        {
            this.variableName = name;
            this.variableValue = value;
        }

        public override double Evaluate()
        {
            return this.variableValue;
        }
        
    }
}
