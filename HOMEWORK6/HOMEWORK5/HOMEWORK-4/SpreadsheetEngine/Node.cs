// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Mark Shinozaki
// 11672355

namespace ExpressionLib
{
    using System;

    /// <summary>
    /// This is the node class.
    /// </summary>
    /// <summary>
    /// Abstract Expression Tree node.
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Abstract Evaluate function, used in derived nodes.
        /// </summary>
        /// <returns>Value of node.</returns>
        public abstract double Evaluate();
    }
}
