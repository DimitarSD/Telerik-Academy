namespace FindASetOfWords
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using FindASetOfWords.Trie;

    public class StartUp
    {
        private static readonly Stopwatch StopWatch = new Stopwatch();
        private static readonly Random RandomValue = new Random();

        public static void Main()
        {
            var trie = TrieFactory.GetTrie();

            var words = GenerateRandomWords(1000000);
            var uniqueWords = new HashSet<string>(words);

            AddWordsToTrie(words, trie);
            GetCountOfAllUniqueWords(uniqueWords, trie);
        }

        private static ICollection<string> GenerateRandomWords(int count)
        {
            Console.Write("Generation random words... ");
            StopWatch.Start();

            var words = new List<string>(count);

            for (int i = 0; i < count; i++)
            {
                words.Add(GetRandomWord());
            }

            StopWatch.Stop();
            Console.WriteLine("\rGeneration random words -> Total words: {0} | Elapsed time: {1}\n", words.Count, StopWatch.Elapsed);
            StopWatch.Reset();

            return words;
        }

        private static string GetRandomWord()
        {
            var newWord = new char[RandomValue.Next(3, 7)];

            for (int i = 0; i < newWord.Length; i++)
            {
                newWord[i] = (char)RandomValue.Next(97, 122);
            }

            return new string(newWord);
        }

        private static void AddWordsToTrie(ICollection<string> words, ITrie trie)
        {
            Console.Write("Adding words to trie... ");
            StopWatch.Start();

            foreach (var word in words)
            {
                trie.AddWord(word);
            }

            StopWatch.Stop();
            Console.WriteLine("\rAdding words to trie -> Elapsed time: {1}\n", words.Count, StopWatch.Elapsed);
            StopWatch.Reset();
        }

        private static void GetCountOfAllUniqueWords(ICollection<string> wordsForSearcing, ITrie trie)
        {
            Console.Write("Searching words... ");
            StopWatch.Start();

            foreach (var word in wordsForSearcing)
            {
                // return the number of words 
                trie.WordCount(word);    
            }

            StopWatch.Stop();
            Console.WriteLine("\rSearching words -> Unique words: {0} | Elapsed time: {1}\n", wordsForSearcing.Count, StopWatch.Elapsed);
            StopWatch.Reset();
        }
    }
}
