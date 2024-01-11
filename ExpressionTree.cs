// Mark Shinozaki
// 11672355

namespace SpreadsheetEngine
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ExpressionTree Class 
    /// </summary>
    public class ExpressionTree
    {
        private Node root;

        public ExpressionTree(string expression)
        {
            this.InfixExpression = expression;
            this.Variables = new Dictionary<string, double>();
            this.root = this.BuildTree(this.InfixExpression);
        }

        public string InfixExpression { get; set; }

        public string PostfixExpression { get; set; }

        public Dictionary<string, double> Variables { get; set; }

        public int Precedence(char c1)
        {
            if (c1 == '^')
            {
                return 2;
            }
            else if (c1 == '*' || c1 == '/')
            {
                return 1;
            }
            else if (c1 == '+' || c1 == '-')
            {
                return 0;
            }
            else
            {
                return -1;
            }

        }


        public void SetVariable(string variableName, double variableValue)
        {
            this.Variables.Add(variableName, variableValue);
        }

        public double Evaluate()
        {
            return this.root.Evaluate();
        }

        private List<string> PostfixExpressionConverter(string infixexpression)
        {
            List<string> postfixexpression = new List<string>();
            Stack<char> postfixstack = new Stack<char>();
            for (int i = 0; i < infixexpression.Length; i++)
            {
                char c = infixexpression[i];

                // case of c being )
                if (c == ')')
                {
                    char stacktop = postfixstack.Pop();
                    while (postfixstack.Count > 0 && stacktop != '(')
                    {
                        postfixexpression.Add(stacktop.ToString());
                        stacktop = postfixstack.Pop();
                    }
                }

                // case of c being (
                else if (c == '(')
                {
                    postfixstack.Push(c);
                }

                // case of c being operator
                else if (this.IsOperator(c))
                {
                    OperatorNode cNode;
                    ushort stacktopprec;
                    do
                    {
                        stacktopprec = 0;
                        cNode = Factory.newOperatorNode(c);
                        if (postfixstack.Count > 0)
                        {
                            if (this.IsParenthesis(postfixstack.Peek()))
                            {
                                stacktopprec = 0;
                            }
                            else
                            {
                                OperatorNode postfixstacknode = Factory.newOperatorNode(postfixstack.Peek());
                                stacktopprec = postfixstacknode.Precedence;
                            }

                            if (postfixstack.Count > 0 && cNode.Precedence <= stacktopprec)
                            {
                                postfixexpression.Add(postfixstack.Pop().ToString());
                            }
                        }
                    }
                    while (postfixstack.Count > 0 && cNode.Precedence <= stacktopprec);
                    postfixstack.Push(c);
                }

                // case of c being operand
                else
                {
                    string operand = string.Empty;
                    while (!this.IsOperator(c) && !this.IsParenthesis(c) && i < infixexpression.Length)
                    {
                        operand += c;
                        i++;
                        if (i < infixexpression.Length)
                        {
                            c = infixexpression[i];
                        }
                    }

                    postfixexpression.Add(operand);
                    i--;
                }
            }

            // pop all remaing elements from stack
            while (postfixstack.Count > 0)
            {
                postfixexpression.Add(postfixstack.Pop().ToString());
            }

            return postfixexpression;
        }

        private Node BuildTree(string infixstring)
        {
            // to avoid any pop empty stack errors
            if (infixstring.Length != 0)
            {
                Stack<Node> expressionTreeStack = new Stack<Node>();
                List<string> poststring = this.PostfixExpressionConverter(infixstring);
                Console.WriteLine("\n");

                foreach (var symbol in poststring)
                {
                    double number = 0.0;
                    if (double.TryParse(symbol, out number))
                    {
                        expressionTreeStack.Push(new ConstantNode(number));
                    }
                    else if (this.IsOperator(symbol[0]) || this.IsParenthesis(symbol[0]))
                    {
                        OperatorNode newOPNode = Factory.newOperatorNode(symbol[0]);
                        newOPNode.Left = expressionTreeStack.Pop();
                        newOPNode.Right = expressionTreeStack.Pop();
                        expressionTreeStack.Push(newOPNode);
                    }
                    else
                    {
                        this.Variables.Add(symbol, 0);
                        expressionTreeStack.Push(new VariableNode(symbol, this.Variables[symbol]));

                    }
                }

                return expressionTreeStack.Pop();
            }

            return null;
        }

        /// <summary>
        /// simple bool function to check if char c is a valid operator we're looking for in expressiontree.
        /// </summary>
        /// <param name="c">char c from postfix expression which could be operator or not.</param>
        /// <returns>true if c is valid operator, false if not.</returns>
        private bool IsOperator(char c)
        {
            if (c == '+' || c == '-' || c == '/' || c == '*' || c == '^')
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Simple bool function to check of char c is a parenthesis.
        /// </summary>
        /// <param name="c">char c from postfix expression which could be parenthesis or not.</param>
        /// <returns>true if c is a parenthesis, false if not.</returns>
        private bool IsParenthesis(char c)
        {
            if (c == '(' || c == ')')
            {
                return true;
            }

            return false;
        }


    }




}
