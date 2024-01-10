using System;
using System.Collections.Generic;
using System.Linq;


using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Numerics;


namespace FibonacciTests
{
    using NUnit.Framework;
    using NotePadApplication;

    [TestFixture]
    public class FibonacciTests
    {
        /// <summary>
        /// testing the FindFibonacci function
        /// </summary>
        [Test]
        public void FibonacciTest()
        {
            Assert.IsNotEmpty(FibonacciTextReader.FindFibonacci(455).ToString());
        }


        /// <summary>
        /// testing the FindFibonacci function
        /// </summary>
        [Test]
        public void FindFibonacciTest()
        {
            Assert.IsNotEmpty(FibonacciTextReader.FindFibonacci(10).ToString());
        }

        /// <summary>
        /// testing the FindFibonacci with 0
        /// </summary>
        [Test]
        public void ZeroTest()
        {
            Assert.IsNotEmpty(FibonacciTextReader.FindFibonacci(0).ToString());
        }

    }

}
