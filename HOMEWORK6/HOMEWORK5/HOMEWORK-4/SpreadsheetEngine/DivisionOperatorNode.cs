// <copyright file="DivisionOperatorNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Mark Shinozaki
// 11672355

namespace ExpressionLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Node for Division Operator.
    /// </summary>
    internal class DivisionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionOperatorNode"/> class.
        /// Returns operator '/'.
        /// </summary>
        public DivisionOperatorNode()
            : base('/')
        {
        }

        /// <summary>
        /// Gets precedence of operator in order of operations.
        /// </summary>
        public override ushort Precedence => 6;

        /// <summary>
        /// Gets associativity of operator.
        /// </summary>
        public override Associative Associativity => Associative.Left;

        /// <summary>
        /// Evaluates value of tree by dividing value of the left subtree by the value of the right.
        /// </summary>
        /// <returns>Value of tree.</returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() / this.Right.Evaluate();
        }
    }
}
