// <copyright file="AdditionOperatorNode.cs" company="PlaceholderCompany">
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
    /// Addition Node.
    /// </summary>
    internal class AdditionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionOperatorNode"/> class.
        /// Returns operator '+'.
        /// </summary>
        public AdditionOperatorNode()
            : base('+')
        {
        }

        /// <summary>
        /// Gets initializes a new instance of the <see cref="AdditionOperatorNode"/> class.
        /// Returns operator '+'.
        /// </summary>
        public override ushort Precedence => 7;

        /// <summary>
        /// Gets associativity of operator.
        /// </summary>
        public override Associative Associativity => Associative.Left;

        /// <summary>
        /// Evaluates value of tree by adding the results of the left and right subtrees.
        /// </summary>
        /// <returns>Value of tree.</returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() + this.Right.Evaluate();
        }
    }
}
