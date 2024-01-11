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
    /// This is the factory class. used to create operation nodes.
    /// </summary>
    internal class Factory
    {
        public static OperatorNode newOperatorNode(char c)
        {
            switch (c)
            {
                case '/':
                    return new DivisionOperatorNode();
                case '*':
                    return new MultiplicationOperatorNode();
                case '+':
                    return new AdditionOperatorNode();
                case '-':
                    return new SubtractionOperatorNode();

            }

            return null;

        }
    }
}
