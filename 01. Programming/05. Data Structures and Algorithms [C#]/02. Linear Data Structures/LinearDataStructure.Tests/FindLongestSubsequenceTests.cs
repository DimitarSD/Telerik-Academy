namespace LinearDataStructure.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using FindLongestSubsequence;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindLongestSubsequenceTests
    {
        [TestMethod]
        public void ShouldReturnLastLongestSubsequence()
        {
            var collection = new List<int>() { 4, 5, 5, 5, 9, 6, 1, 3, 3, 3, 3, 3, 3, 3, 3 };
            var longestSubsequence = StartUp.FindTheLongestSubsequenceOfEqualNumbers(collection).ToList();
            var expectedLongestSubsequence = new List<int>() { 3, 3, 3, 3, 3, 3, 3, 3 };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }

        [TestMethod]
        public void ShouldReturnFirstLongestSubsequence()
        {
            var collection = new List<int>() { 4, 5, 5, 5, 9, 9, 6, 1, 3, 7, 8, 8, 9 };
            var longestSubsequence = StartUp.FindTheLongestSubsequenceOfEqualNumbers(collection).ToList();
            var expectedLongestSubsequence = new List<int>() { 5, 5, 5 };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }

        [TestMethod]
        public void ShouldReturnMiddleLongestSubsequence()
        {
            var collection = new List<int>() { 4, 5, 5, 5, 9, 9, 9, 9, 9, 9, 6, 1, 3, 7, 8, 8, 9 };
            var longestSubsequence = StartUp.FindTheLongestSubsequenceOfEqualNumbers(collection).ToList();
            var expectedLongestSubsequence = new List<int>() { 9, 9, 9, 9, 9, 9 };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }

        [TestMethod]
        public void ShouldReturnLongestSubsequenceAtTheBeginning()
        {
            var collection = new List<int>() { 1, 1, 1, 1, 2, 2, 3, 3, 3 };
            var longestSubsequence = StartUp.FindTheLongestSubsequenceOfEqualNumbers(collection).ToList();
            var expectedLongestSubsequence = new List<int>() { 1, 1, 1, 1 };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }

        [TestMethod]
        public void ShouldReturnOnlyOneSubsequenceAtTheEnd()
        {
            var collection = new List<int>() { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
            var longestSubsequence = StartUp.FindTheLongestSubsequenceOfEqualNumbers(collection).ToList();
            var expectedLongestSubsequence = new List<int>() { 4, 4, 4, 4 };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }

        [TestMethod]
        public void ShouldReturnOnlyOneSubsequenceAtTheMiddle()
        {
            var collection = new List<int>() { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4 };
            var longestSubsequence = StartUp.FindTheLongestSubsequenceOfEqualNumbers(collection).ToList();
            var expectedLongestSubsequence = new List<int>() { 3, 3, 3, 3 };

            CollectionAssert.AreEqual(expectedLongestSubsequence, longestSubsequence);
        }
    }
}
