namespace OccurrencesOfWordsInText
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Utilities.FileUtilities;

    public class StartUp
    {        
        private const string Path = "../../Inputs/words.txt";
        private static readonly char[] SplitOptions = new char[] { ' ', '!', '?', '.', ',', '/', '\\', '(', ')', '-', '–' };

        public static void Main()
        {
            var fileContent = FileUtility.GetFileTextContent(Path);
            var extractedWords = ExtractWords(fileContent);
            var occurrences = FindElementsOccurrences(extractedWords);

            foreach (var element in occurrences)
            {
                Console.WriteLine("{0} - {1}", element.Key, element.Value);
            }
        }
        
        /// <summary>
        /// Extract all words from the text using Split() method
        /// </summary>
        /// <param name="text">The text to be splitted</param>
        /// <returns>Returns string array - the words</returns>
        public static string[] ExtractWords(string text)
        {
            var splittedText = text.Split(SplitOptions, StringSplitOptions.RemoveEmptyEntries);
            return splittedText;
        }

        /// <summary>
        /// Finds elements occurrences using dictionary implementation
        /// </summary>
        /// <param name="collection">Collection containing all words</param>
        /// <returns>Dictionary with all occurrences sorted by number of the occurrences</returns>
        public static IDictionary<string, int> FindElementsOccurrences(IList<string> collection)
        {
            var dictionary = new Dictionary<string, int>();

            for (int i = 0; i < collection.Count; i++)
            {
                var key = collection[i].ToLower();

                if (!dictionary.ContainsKey(key))
                {
                    dictionary[key] = 1;
                }
                else
                {
                    dictionary[key]++;
                }
            }

            var sortedElements = dictionary
                .OrderBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            return sortedElements;
        }
    }
}
