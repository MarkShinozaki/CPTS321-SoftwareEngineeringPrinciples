// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Mark Shinozaki
// 11672355

namespace ExpressionLib
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Factory of OperatorNodes. Creates correct type of operator node.
    /// </summary>
    internal class Factory
    {
        /// <summary>
        /// Dictionary of operators and corresponding class.
        /// </summary>
        private static Dictionary<char, Type> operators = new Dictionary<char, Type>
        {
            { '+', typeof(AdditionOperatorNode) },
            { '-', typeof(SubtractionOperatorNode) },
            { '*', typeof(MultiplicationOperatorNode) },
            { '/', typeof(DivisionOperatorNode) },
        };

        /// <summary>
        /// Checks if char is an operator, then returns corresponding node.
        /// </summary>
        /// <param name="c">Char of operator.</param>
        /// <returns>Node corresponding to given operator.</returns>
        public static OperatorNode CreateOperatorNode(char c)
        {
            if (operators.ContainsKey(c))
            {
                // creates object based on type in dictionary above
                object operatorNodeObject = System.Activator.CreateInstance(operators[c]);

                if (operatorNodeObject is OperatorNode node)
                {
                    return node;
                }
            }

            return null;
        }
    }
}
