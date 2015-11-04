namespace AbstractDataStructures.Tests
{
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OccurrencesOfWordsInText;
    using Utilities.FileUtilities;

    [TestClass]
    public class OccurrencesOfWordsInTextTests
    {
        private const string InvalidPath = "invalid path";
        private const string TextContent = "This is the TEXT. Text, text, text - THIS TEXT! Is this the text?";
        private const string FilePath = "../../Inputs/words.txt";
        private static readonly string[] WordsCollection = new string[] { "This", "is", "the", "TEXT", "Text", "text", "text", "THIS", "TEXT", "Is", "this", "the", "text" };

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetFileTextContentShouldThrowFileNotFoundExceptionWhenInvalidPathIsPassed()
        {
            FileUtility.GetFileTextContent(InvalidPath);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetFileTextContentShouldThrowFileNotFoundExceptionWhenEmptyStringPathIsPassed()
        {
            FileUtility.GetFileTextContent(string.Empty);
        }

        [TestMethod]
        public void GetFileTextContentShouldReturnTextContentWhenValidPathIsPassed()
        {
            string expectedTextContent = TextContent;
            string textContent = FileUtility.GetFileTextContent(FilePath);
        
            Assert.AreEqual(expectedTextContent, textContent);
        }

        [TestMethod]
        public void ExtractWordsShouldReturnCorrectAnswerWhenValidTextIsPassed()
        {
            var expectedResult = WordsCollection;

            string text = TextContent;
            var splittedText = StartUp.ExtractWords(text);

            for (int index = 0; index < expectedResult.Length; index++)
            {
                Assert.AreEqual(expectedResult[index], splittedText[index]);
            }
        }

        [TestMethod]
        public void FindElementsOccurrencesShouldReturnCorrectAnswer()
        {
            var expectedDictionary = new Dictionary<string, int>();
            expectedDictionary.Add("is", 2);
            expectedDictionary.Add("the", 2);
            expectedDictionary.Add("this", 3);
            expectedDictionary.Add("text", 6);

            var collectionToBeTested = WordsCollection;
            var resultDictionary = StartUp.FindElementsOccurrences(collectionToBeTested);

            Assert.AreEqual(expectedDictionary["is"], resultDictionary["is"]);
            Assert.AreEqual(expectedDictionary["the"], resultDictionary["the"]);
            Assert.AreEqual(expectedDictionary["this"], resultDictionary["this"]);
            Assert.AreEqual(expectedDictionary["text"], resultDictionary["text"]);
        }
    }
}
