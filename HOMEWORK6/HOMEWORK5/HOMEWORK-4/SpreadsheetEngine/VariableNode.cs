// <copyright file="VariableNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Mark Shinozaki
// 11672355

namespace ExpressionLib
{
    using SpreadsheetEngine;
    using System.Collections.Generic;

    /// <summary>
    /// Node for variables in the expression.
    /// </summary>
    internal class VariableNode : Node
    {
        /// <summary>
        /// Name of variable.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Dictionary from ExpressionTree. Reference is held so that if variable is updated, the value can adapt.
        /// </summary>
        private Dictionary<string, double> variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name">Name of variable.</param>
        /// <param name="variables">Reference to dictionary in ExpressionTree.</param>
        public VariableNode(string name, ref Dictionary<string, double> variables)
        {
            this.name = name;
            this.variables = variables;
        }

        /// <summary>
        /// Evaluates tree (in this case returns the value of the variable in the dictionary).
        /// </summary>
        /// <returns>Value of node.</returns>
        public override double Evaluate()
        {
            double value = 0.0;

            if (this.variables.ContainsKey(this.name))
            {
                value = this.variables[this.name];
            }

            return value;
        }
    }
}
