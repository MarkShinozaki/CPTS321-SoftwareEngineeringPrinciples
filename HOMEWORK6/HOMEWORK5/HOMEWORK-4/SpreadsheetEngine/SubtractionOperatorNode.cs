// <copyright file="SubtractionOperatorNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Mark Shinozaki
// 11672355

namespace ExpressionLib
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class of Subtraction operator.
    /// </summary>
    internal class SubtractionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractionOperatorNode"/> class.
        /// Returns operator '-'.
        /// </summary>
        public SubtractionOperatorNode()
            : base('-')
        {
        }

        /// <summary>
        /// Gets precedence of operator in order of operations.
        /// </summary>
        public override ushort Precedence => 7;

        /// <summary>
        /// Gets associativity of operator.
        /// </summary>
        public override Associative Associativity => Associative.Left;

        /// <summary>
        /// Overridden Evaluate function.
        /// </summary>
        /// <returns> Left and Right node's evaluations. </returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() - this.Right.Evaluate();
        }
    }
}
