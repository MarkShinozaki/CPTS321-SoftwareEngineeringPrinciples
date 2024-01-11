// <copyright file="MultiplicationOperatorNode.cs" company="PlaceholderCompany">
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
    ///  Mulitplication Node class.
    /// </summary>
    internal class MultiplicationOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplicationOperatorNode"/> class.
        /// Returns operator '*'.
        /// </summary>
        public MultiplicationOperatorNode()
            : base('*')
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
        /// overriden Evaluate function.
        /// </summary>
        /// <returns> left and right node's evaluations. </returns>
        public override double Evaluate()
        {
            return this.Left.Evaluate() * this.Right.Evaluate();
        }
    }
}