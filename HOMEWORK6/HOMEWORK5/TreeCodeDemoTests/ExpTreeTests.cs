// Mark Shinozaki
// 11672355

namespace TreeCodeDemoTests
{
    using SpreadsheetEngine;
    
    using NUnit.Framework;

  /// <summary>
    /// Class with tests for ExpressionTree.
    /// </summary>
    [TestFixture]
    public class TestExpressionTree
    {
        /// <summary>
        /// Testing evaluate with constants.
        /// </summary>
        [Test]
        public void TestEvaluateWithConstants()
        {
           
            SpreadsheetEngine.ExpressionTree expressionTree = new SpreadsheetEngine.ExpressionTree("4-3-2");
            Assert.AreEqual(-1.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Testing evaluate with variables.
        /// </summary>
        [Test]
        public void TestEvaluateWithVariables()
        {
            
            SpreadsheetEngine.ExpressionTree expressionTree = new SpreadsheetEngine.ExpressionTree("Hello+World");

            expressionTree.SetVariable("Hello", 42);
            expressionTree.SetVariable("World", 20);

            Assert.AreEqual(62.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Testing evaluate with variables and constants.
        /// </summary>
        [Test]
        public void TestEvaluateWithConstantsAndVariables()
        {
            
            SpreadsheetEngine.ExpressionTree expressionTree = new SpreadsheetEngine.ExpressionTree("12+Hello+World");

            expressionTree.SetVariable("Hello", 42);
            expressionTree.SetVariable("World", 20);

            Assert.AreEqual(74.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Testing if the postfix conversion is created correctly with parentheses added.
        /// </summary>
        [Test]
        public void TestConvertToPostfixWithParentheses()
        {
            SpreadsheetEngine.ExpressionTree expressionTree = new SpreadsheetEngine.ExpressionTree("3*(4+5*6)+7");

            Assert.AreEqual("3 4 5 6 * + * 7 +", expressionTree.PostfixExpression);
        }

        /// <summary>
        /// Testing evaluate with parentheses.
        /// </summary>
        [Test]
        public void TestEvaluateWithParentheses()
        {
            SpreadsheetEngine.ExpressionTree expressionTree = new SpreadsheetEngine.ExpressionTree("3*(4+5*6)+7");

            Assert.AreEqual(109.0, expressionTree.Evaluate());
        }

        /// <summary>
        /// Testing if postfix conversion is created correctly.
        /// </summary>
        [Test]
        public void TestConvertToPostfix()
        {
           
            SpreadsheetEngine.ExpressionTree expressionTree = new SpreadsheetEngine.ExpressionTree("100-24-8");

            Assert.AreEqual("100 24 - 8 -", expressionTree.PostfixExpression);
        }


        /// <summary>
        /// Testing if postfix conversion is created correctly.
        /// </summary>
        [Test]
        public void TestVariblesInputs()
        {
            
            SpreadsheetEngine.ExpressionTree expressionTree = new SpreadsheetEngine.ExpressionTree("A1+A2");

            expressionTree.SetVariable("A1", 1);
            expressionTree.SetVariable("A2", 1);
            


            Assert.AreEqual(2.0, expressionTree.Evaluate());
        }













    }

}