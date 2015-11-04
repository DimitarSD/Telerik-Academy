namespace HashTable
{
    public interface IHashTable<TKey, TValue>
    {
        /// <summary>
        /// Define a property Count to gets the number of elements in the HashTable
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Define an indexator to gets and sets values
        /// </summary>
        /// <param name="key">Search value by key</param>
        /// <returns>Returns the value which corresponds to the key</returns>
        TValue this[TKey key] { get; set; }

        /// <summary>
        /// Add a key-value pair to the HashTable
        /// </summary>
        /// <param name="key">Key to be used for index</param>
        /// <param name="value">Value to be set in the hash table</param>
        void Add(TKey key, TValue value);

        /// <summary>
        /// Gets a value by given key
        /// </summary>
        /// <param name="key">Key wich will be used for searching</param>
        /// <returns>Returns the founded value</returns>
        TValue GetValue(TKey key);

        /// <summary>
        /// Remove a value by given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Returns true if the removing is successful, and false if is not</returns>
        bool Remove(TKey key);

        /// <summary>
        /// Clear the HashTable
        /// </summary>
        void Clear();
    }
}
