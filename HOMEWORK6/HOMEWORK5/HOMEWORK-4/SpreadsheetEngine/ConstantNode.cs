// <copyright file="ConstantNode.cs" company="PlaceholderCompany">
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
    /// This is the Constant node class. holds a double for the node value.
    /// </summary>
    internal class ConstantNode : Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// </summary>
        /// <param name="value">Value of the new node.</param>
        public ConstantNode(double value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets value of node.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Evaluates tree (in this case returns the value of the node).
        /// </summary>
        /// <returns>Value of node.</returns>
        public override double Evaluate()
        {
            return this.Value;
        }
    }
}
