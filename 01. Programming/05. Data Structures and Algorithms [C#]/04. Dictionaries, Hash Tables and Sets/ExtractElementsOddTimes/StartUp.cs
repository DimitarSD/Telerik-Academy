namespace ExtractElementsOddTimes
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const string PrintResultFormatMessage = "{0} -> {1} times";

        public static void Main()
        {
            var stringElements = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var extractedElements = ExtractElementsOccurrencingOddTimes(stringElements);

            foreach (var element in extractedElements)
            {
                Console.WriteLine(PrintResultFormatMessage, element.Key, element.Value);
            }
        }

        public static Dictionary<string, int> ExtractElementsOccurrencingOddTimes(string[] elements)
        {
            var dictionaryOfStringElements = new Dictionary<string, int>();

            for (int i = 0; i < elements.Length; i++)
            {
                var key = elements[i];

                if (!dictionaryOfStringElements.ContainsKey(key))
                {
                    dictionaryOfStringElements[key] = 1;
                }
                else
                {
                    dictionaryOfStringElements[key]++;
                }
            }
            
            var extractedElements = new Dictionary<string, int>();

            foreach (var stringElement in dictionaryOfStringElements)
            {
                if (stringElement.Value % 2 != 0)
                {
                    extractedElements.Add(stringElement.Key, stringElement.Value);
                }
            }

            return extractedElements;
        }
    }
}
