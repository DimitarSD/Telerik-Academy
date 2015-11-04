namespace AbstractDataStructures.Tests
{
    using System.Collections.Generic;

    using ExtractElementsOddTimes;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExtractElementsOddTimesTests
    {
        private const string CSharp = "C#";
        private const string SQL = "SQL";
        private static readonly string[] Languages = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

        [TestMethod]
        public void ShouldReturnCorrectAnswer()
        {
            var elementsToTest = Languages;
            var expectedDictionary = new Dictionary<string, int>();
            expectedDictionary.Add(CSharp, 1);
            expectedDictionary.Add(SQL, 3);

            var resultDictionary = StartUp.ExtractElementsOccurrencingOddTimes(elementsToTest);

            Assert.AreEqual(expectedDictionary[CSharp], resultDictionary[CSharp]);
            Assert.AreEqual(expectedDictionary[SQL], resultDictionary[SQL]);
        }

        [TestMethod]
        public void ShouldReturnCorrectAnswerWhenEmptyArrayIsPassed()
        {
            var elementsToTest = new string[] { };
            var expectedDictionary = new Dictionary<string, int>();

            var resultDictionary = StartUp.ExtractElementsOccurrencingOddTimes(elementsToTest);

            Assert.AreEqual(expectedDictionary.Count, resultDictionary.Count);
        }
    }
}
