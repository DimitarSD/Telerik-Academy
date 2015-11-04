namespace AbstractDataStructures.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OccurrencesOfElement;

    [TestClass]
    public class OccurrencesOfElementTests
    {
        [TestMethod]
        public void ShouldReturnCorrectAnswer()
        {
            var numbersToTest = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            var expectedDictionary = new Dictionary<double, int>();
            expectedDictionary.Add(3, 4);
            expectedDictionary.Add(4, 3);
            expectedDictionary.Add(-2.5, 2);

            var resultDictionary = StartUp.CountNumberOfOccurrences(numbersToTest);

            Assert.AreEqual(expectedDictionary[3], resultDictionary[3]);
            Assert.AreEqual(expectedDictionary[4], resultDictionary[4]);
            Assert.AreEqual(expectedDictionary[-2.5], resultDictionary[-2.5]);
        }

        [TestMethod]
        public void ShouldReturnCorrectAnswerWhenEmptyArrayIsPassed()
        {
            var numbersToTest = new double[] { };
            var expectedDictionary = new Dictionary<double, int>();

            var resultDictionary = StartUp.CountNumberOfOccurrences(numbersToTest);

            Assert.AreEqual(expectedDictionary.Count, resultDictionary.Count);
        }
        
        [TestMethod]
        public void ShouldReturnCorrectAnswerWhenArrayWithOneValueIsPassed()
        {
            var numbersToTest = new double[] { 3 };
            var expectedDictionary = new Dictionary<double, int>();
            expectedDictionary.Add(3, 1);

            var resultDictionary = StartUp.CountNumberOfOccurrences(numbersToTest);

            Assert.AreEqual(expectedDictionary[3], resultDictionary[3]);
        }
    }
}
