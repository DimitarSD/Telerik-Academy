namespace FindASetOfWords.Trie
{
    using System.Collections.Generic;

    /// <summary>
    /// Trie factory to create Trie instances.
    /// </summary>
    public static class TrieFactory
    {
        /// <summary>
        /// Get a new Trie instance.
        /// </summary>
        public static ITrie GetTrie()
        {
            var node = GetTrieNode(' ');
            return new Trie(node);
        }

        /// <summary>
        /// Get a new TrieNode instance.
        /// </summary>
        /// <param name="character">Character of the TrieNode.</param>
        internal static TrieNode GetTrieNode(char character)
        {
            return new TrieNode(character, new Dictionary<char, TrieNode>(), false, 0);
        }
    }
}
