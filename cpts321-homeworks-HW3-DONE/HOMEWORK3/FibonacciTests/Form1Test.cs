// Mark Shinozaki
// 11672355


namespace FibonacciTests
{
    using System.Diagnostics.CodeAnalysis;
    using NotePadApplication;
    using NUnit.Framework;

    
   /// <summary>
   /// will set up a class for the tests to run
   /// </summary>
    [TestFixture]
    public class Form1Tests
    {
        /// <summary>
        /// will set up a function for tests
        /// </summary>
        [Test]
        public void Form1Test()
        {
            Assert.IsNotEmpty(FibonacciTextReader.FindFibonacci(100).ToString());
        }
    }

}
