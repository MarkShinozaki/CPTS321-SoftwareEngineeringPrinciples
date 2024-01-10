using HW2;
using System.Collections.Generic;
using System.Linq;

namespace HW2.Tests
{
    
    [TestClass]
    public class Form1Tests
    {
        
        [TestMethod]
        public void RunDistinctIntegers_EmptyListMinimumCount_ShouldGenerateOneInteger()
        {
            var list = new List<int>();
            Form1.RunDistinctIntegers(list, 1, 100);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void RunDistinctIntegers_MaxIntegerValue_ShouldHandleMaxValue()
        {
            var list = new List<int>();
            Form1.RunDistinctIntegers(list, 10, int.MaxValue);
            Assert.AreEqual(10, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RunDistinctIntegers_NegativeCount_ShouldThrowArgumentException()
        {
            var list = new List<int>();
            Form1.RunDistinctIntegers(list, -5, 100);
        }

        [TestMethod]
        public void RunDistinctIntegers_ZeroCount_ShouldReturnEmptyList()
        {
            var list = new List<int>();
            Form1.RunDistinctIntegers(list, 0, 100);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RunDistinctIntegers_CountGreaterThanMaxValue_ShouldThrowArgumentException()
        {
            var list = new List<int>();
            Form1.RunDistinctIntegers(list, 15, 10);
        }

        [TestMethod]
        public void CountUsingHashSet_EmptyList_ShouldReturnZero()
        {
            var form = new Form1();
            var list = new List<int>();
            var distinctCount = form.HashSet(list);
            Assert.AreEqual(0, distinctCount);
        }

        [TestMethod]
        public void CountUsingHashSet_ListWithDuplicates_ShouldReturnCorrectCount()
        {
            var form = new Form1();
            var list = new List<int> { 1, 1, 2, 2, 3 };
            var distinctCount = form.HashSet(list);
            Assert.AreEqual(3, distinctCount);
        }

        [TestMethod]
        public void CountUsingHashSet_ListWithUniqueValues_ShouldReturnCorrectCount()
        {
            var form = new Form1();
            var list = new List<int> { 1, 2, 3, 4, 5, 6 };
            var distinctCount = form.HashSet(list);
            Assert.AreEqual(6, distinctCount);
        }

        // Tests for CountWithO1Storage
        [TestMethod]
        public void CountWithO1Storage_NormalCase_ShouldReturnCorrectDistinctCount()
        {
            var form = new Form1();
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var distinctCount = form.StorageMethod(list);
            Assert.AreEqual(5, distinctCount);
        }

        [TestMethod]
        public void CountWithO1Storage_EmptyList_ShouldReturnZero()
        {
            var form = new Form1();
            var list = new List<int>();
            var distinctCount = form.StorageMethod(list);
            Assert.AreEqual(0, distinctCount);
        }

        [TestMethod]
        public void CountWithO1Storage_ListWithDuplicates_ShouldReturnCorrectCount()
        {
            var form = new Form1();
            var list = new List<int> { 1, 1, 2, 2, 3 };
            var distinctCount = form.StorageMethod(list);
            Assert.AreEqual(3, distinctCount);
        }

        [TestMethod]
        public void CountWithO1Storage_ListWithUniqueValues_ShouldReturnCorrectCount()
        {
            var form = new Form1();
            var list = new List<int> { 1, 2, 3, 4, 5, 6 };
            var distinctCount = form.StorageMethod(list);
            Assert.AreEqual(6, distinctCount);
        }
    }

}
