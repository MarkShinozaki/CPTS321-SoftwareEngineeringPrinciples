// <copyright file="OperatorNode.cs" company="PlaceholderCompany">
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
    /// Abstract operator node for expression tree.
    /// </summary>
    internal abstract class OperatorNode : Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        /// <param name="c">Operator.</param>
        public OperatorNode(char c)
        {
            this.Operator = c;
            this.Left = this.Right = null;
        }

        /// <summary>
        /// Notes if operator is left or right associative.
        /// </summary>
        public enum Associative
        {
            /// <summary>
            /// Right associative.
            /// </summary>
            Right,

            /// <summary>
            /// Left associative.
            /// </summary>
            Left,
        }

        /// <summary>
        /// Gets precedence of operator.
        /// </summary>
        public abstract ushort Precedence { get; }

        /// <summary>
        /// Gets associativity of operator.
        /// </summary>
        public abstract Associative Associativity { get; }

        /// <summary>
        /// Gets or sets char of operator.
        /// </summary>
        public char Operator { get; set; }

        /// <summary>
        /// Gets or sets node to the left.
        /// </summary>
        public Node Left { get; set; }

        /// <summary>
        /// Gets or sets node to the right.
        /// </summary>
        public Node Right { get; set; }

        /// <summary>
        /// Abstract evaluate function. Each derived node will have its own functionality.
        /// </summary>
        /// <returns>Evaluated tree/sub-tree.</returns>
        public abstract override double Evaluate();
    }
}
