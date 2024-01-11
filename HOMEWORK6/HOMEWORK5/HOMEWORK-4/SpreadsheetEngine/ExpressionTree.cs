// <copyright file="ExpressionTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Mark Shinozaki
// 11672355

namespace ExpressionLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using SpreadsheetEngine;

    /// <summary>
    /// Expression tree class.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// Root of expression tree.
        /// </summary>
        private Node expressionTreeRoot;

        /// <summary>
        /// Dictionary to store variable names and corresponding values.
        /// </summary>
        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// List to store the variables that are referenced by this expression tree.
        /// </summary>
        private List<string> referencedCells = new List<string>();

        /// <summary>
        /// Expression as given by user.
        /// </summary>
        private string prefixExpression;

        /// <summary>
        /// Expression converted to postfix.
        /// </summary>
        private string postfixExpression;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">Expression to store in class.</param>
        public ExpressionTree(string expression)
        {
            this.prefixExpression = expression;
            this.postfixExpression = this.ConvertToPostfix();
            this.BuildTree();
        }

        /// <summary>
        /// Gets postfixExpression.
        /// </summary>
        public string PostfixExpression
        {
            get { return this.postfixExpression; }
        }

        /// <summary>
        /// Gets or sets variables dictionary.
        /// </summary>
        public Dictionary<string, double> Variables
        {
            get
            {
                return this.variables;
            }

            set
            {
                this.variables = value;
                this.BuildTree();
            }
        }

        /// <summary>
        /// Gets list of cells this cell references.
        /// </summary>
        public List<string> ReferencedCells
        {
            get { return this.referencedCells; }
        }

        /// <summary>
        /// Sets variable in the expression tree.
        /// </summary>
        /// <param name="variableName">Name of variable.</param>
        /// <param name="variableValue">Value of variable.</param>
        public void SetVariable(string variableName, double variableValue)
        {
            this.variables[variableName] = variableValue;
            this.BuildTree();
        }

        /// <summary>
        /// Evaluate the expression.
        /// </summary>
        /// <returns>The value of the expression.</returns>
        public double Evaluate()
        {
            return this.expressionTreeRoot.Evaluate();
        }

        /// <summary>
        /// Converts given expression into postfix.
        /// </summary>
        /// <returns>Postfix expression.</returns>
        private string ConvertToPostfix()
        {
            string delimiterChars = @"([*()\^\/]|(?<!E)[\+\-])";
            List<char> operatorChars = new List<char> { '+', '-', '*', '/' };
            string[] tokens = Regex.Split(this.prefixExpression, delimiterChars);
            tokens = tokens.Where(token => !string.IsNullOrEmpty(token)).ToArray();

            Stack<char> operatorStack = new Stack<char>();
            string postfixString = string.Empty;

            foreach (string tok in tokens)
            {
                if (int.TryParse(tok, out _))
                {
                    // integer found
                    if (postfixString != string.Empty)
                    {
                        postfixString += ' ';
                    }

                    postfixString += tok;
                    continue;
                }
                else if (tok[0] == '(')
                {
                    // left parenthesis found
                    operatorStack.Push(char.Parse(tok));
                }
                else if (tok[0] == ')')
                {
                    // right parenthesis found
                    char popped = '\0';
                    while (operatorStack.Count > 0 && (popped = operatorStack.Pop()) != '(')
                    {
                        if (postfixString != string.Empty)
                        {
                            postfixString += ' ';
                        }

                        postfixString += popped;
                    }
                }
                else if (tok.Length > 1)
                {
                    // variable found
                    if (postfixString != string.Empty)
                    {
                        postfixString += ' ';
                    }

                    // add variable to dictionary
                    if (!this.variables.ContainsKey(tok))
                    {
                        this.variables.Add(tok, 0);
                    }

                    postfixString += tok;
                }
                else
                {
                    if (operatorChars.Contains(char.Parse(tok)))
                    {
                        // operator found

                        // current operator
                        OperatorNode thisNode = Factory.CreateOperatorNode(tok[0]);

                        while (operatorStack.Count > 0 && operatorChars.Contains(operatorStack.Peek()))
                        {
                            // operator on stack
                            OperatorNode stackNode = Factory.CreateOperatorNode(operatorStack.Peek());

                            if (stackNode.Precedence <= thisNode.Precedence)
                            {
                                if (postfixString != string.Empty)
                                {
                                    postfixString += ' ';
                                }

                                postfixString += operatorStack.Pop();
                            }
                            else
                            {
                                break;
                            }
                        }

                        operatorStack.Push(char.Parse(tok));
                    }
                    else
                    {
                        // one letter variable found
                        if (postfixString != string.Empty)
                        {
                            postfixString += ' ';
                        }

                        // add variable to dictionary
                        if (!this.variables.ContainsKey(tok))
                        {
                            this.variables.Add(tok, 0);
                        }

                        postfixString += tok;
                    }
                }
            }

            // add remaining operators to string
            foreach (char c in operatorStack)
            {
                postfixString += ' ';
                postfixString += c;
            }

            return postfixString;
        }

        /// <summary>
        /// Creates expression tree in proper order.
        /// </summary>
        private void BuildTree()
        {
            this.referencedCells.Clear();

            try
            {
                Node newNode;
                Stack<Node> stack = new Stack<Node>();

                foreach (string token in this.postfixExpression.Split(' '))
                {
                    if (double.TryParse(token, out _))
                    {
                        // integer found
                        newNode = new ConstantNode(double.Parse(token));
                    }
                    else if (this.variables.ContainsKey(token))
                    {
                        // variable found
                        newNode = new VariableNode(token, ref this.variables);
                        this.referencedCells.Add(token);
                    }
                    else
                    {
                        // operator found
                        newNode = Factory.CreateOperatorNode(token[0]);
                        ((OperatorNode)newNode).Right = stack.Pop();
                        ((OperatorNode)newNode).Left = stack.Pop();
                    }

                    stack.Push(newNode);
                }

                this.expressionTreeRoot = (Node)stack.Pop();
            }
            catch
            {
                throw new Exception("Cell not found. Please try again using a valid cell entry.");
            }
        }

        /*/// <summary>
        /// Removes empty strings from list.
        /// </summary>
        /// <param name="tokenList">Old list.</param>
        /// <returns>Cleaned list.</returns>
        private string[] CleanTokens(string[] tokenList)
        {
            string[] newTokens = [];

            foreach (string tok in tokenList)
            {
                if (tok != string.Empty)
                {
                    newTokens
                }
            }
        }*/
    }
}
