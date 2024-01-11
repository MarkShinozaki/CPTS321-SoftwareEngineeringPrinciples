// test
namespace NUnit.TestsHW4
{
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;

    /// <summary>
    /// Test cases, five in all.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        /// <summary>
        /// I don't know what I need to test.
        /// </summary>
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }
    }
}
