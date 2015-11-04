namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private const string KeyNotFoundExceptionMessage = "The given key was not present in the hash table.";
        private const int DefaultCapacity = 16;
        private const float DefaultLoadFactory = 0.75f;
        private readonly int initialCapacity;

        private IList<KeyValuePair<TKey, TValue>>[] table;

        /// <summary>
        /// Create an instance of HashTable class with default capacity
        /// </summary>
        public HashTable()
            : this(DefaultCapacity)
        {
        }

        /// <summary>
        /// Creates an instance of HashTable class with given capacity. And empty array of key-value pairs lists 
        /// </summary>
        /// <param name="capacity">Initial capacity</param>
        public HashTable(int capacity)
        {
            this.initialCapacity = capacity;
            this.table = new IList<KeyValuePair<TKey, TValue>>[capacity];
        }

        /// <summary>
        /// Gets the number of elements in the HashTable
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets collection of all available keys in the HashTable
        /// </summary>
        public ICollection<TKey> Keys
        {
            get
            {
                var keys = this.GetKeys();
                return keys;
            }
        }

        /// <summary>
        /// Gets the value by given key from the HashTable
        /// </summary>
        /// <param name="key">Search value by key</param>
        /// <returns>Returns the value which corresponds to the key</returns>
        public TValue this[TKey key]
        {
            get
            {
                return this.GetValue(key);
            }

            set
            {
                this.Add(key, value);
            }
        }

        /// <summary>
        /// Add a new key-value pair in the HashTable
        /// </summary>
        /// <param name="key">Key to be used for index</param>
        /// <param name="value">Value to be set in the hash table</param>
        public void Add(TKey key, TValue value)
        {
            var chain = this.FindChain(key, true);

            for (int i = 0; i < chain.Count; i++)
            {
                if (chain[i].Key.Equals(key))
                {
                    chain[i] = new KeyValuePair<TKey, TValue>(key, value);
                    return;
                }
            }

            chain.Add(new KeyValuePair<TKey, TValue>(key, value));
            this.Count++;
            this.Expand();
        }

        /// <summary>
        /// Check in a HashTable contain given key
        /// </summary>
        /// <param name="key">Key to be searched</param>
        /// <returns>True ot false</returns>
        public bool ContainsKey(TKey key)
        {
            var chain = this.FindChain(key, false);

            if (chain != null)
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    if (chain[i].Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Gets a value from the HashTable by given key
        /// </summary>
        /// <param name="key">Key to use for the search</param>
        /// <returns>Return the founded value </returns>
        public TValue GetValue(TKey key)
        {
            var chain = this.FindChain(key, false);

            if (chain != null)
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    if (chain[i].Key.Equals(key))
                    {
                        return chain[i].Value;
                    }
                }
            }

            throw new KeyNotFoundException(KeyNotFoundExceptionMessage);
        }

        /// <summary>
        /// Remove an element from the HashTable by given key
        /// </summary>
        /// <param name="key">Key to use for the removing</param>
        /// <returns>Returns true if the removing is successful, and false if is not</returns>
        public bool Remove(TKey key)
        {
            var chain = this.FindChain(key, false);

            if (chain != null)
            {
                for (int index = 0; index < chain.Count; index++)
                {
                    if (chain[index].Key.Equals(key))
                    {
                        chain.RemoveAt(index);
                        this.Count--;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Clear the HashTable
        /// </summary>
        public void Clear()
        {
            if (this.table != null)
            {
                this.table = new IList<KeyValuePair<TKey, TValue>>[this.initialCapacity];
            }

            this.Count = 0;
        }

        /// <summary>
        /// Implement the GetEnumerator() method making the hash table to support iterating over its elements with foreach loop
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var chain in this.table)
            {
                if (chain != null)
                {
                    foreach (var keyValuePair in chain)
                    {
                        yield return keyValuePair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Gets all available keys in the HashTable
        /// </summary>
        /// <returns></returns>
        private List<TKey> GetKeys()
        {
            var keys = new List<TKey>();

            for (int i = 0; i < this.table.Length; i++)
            {
                if (this.table[i] != null)
                {
                    for (int j = 0; j < this.table[i].Count; j++)
                    {
                        if (this.table[i][j].Key != null)
                        {
                            keys.Add(this.table[i][j].Key);
                        }
                    }
                }
            }

            return keys;
        }

        /// <summary>
        /// Search for chain in the HashTable in specified position and creates it if it is missing
        /// </summary>
        /// <param name="key">The key corresponding to the position of searching</param>
        /// <param name="createIfMissing">Take a boolean variable is it necessary to create chain ot not</param>
        /// <returns>Returns an array of lists of key-value pairs which corresponds to given key position</returns>
        private IList<KeyValuePair<TKey, TValue>> FindChain(TKey key, bool createIfMissing)
        {
            var hash = key.GetHashCode() & int.MaxValue;
            var index = hash % this.table.Length;

            if (this.table[index] == null && createIfMissing)
            {
                this.table[index] = new List<KeyValuePair<TKey, TValue>>();
            }

            return this.table[index];
        }

        /// <summary>
        /// Resize the HashTable when load runs over 75%
        /// </summary>
        private void Expand()
        {
            var maxLength = (int)(this.table.Length * DefaultLoadFactory);

            if (this.Count >= maxLength)
            {
                int newCapacity = this.table.Length * 2;

                IList<KeyValuePair<TKey, TValue>>[] oldTable = this.table;
                this.table = new List<KeyValuePair<TKey, TValue>>[newCapacity];

                foreach (var oldChain in oldTable)
                {
                    if (oldChain != null)
                    {
                        foreach (var keyValuePair in oldChain)
                        {
                            var chain = this.FindChain(keyValuePair.Key, true);
                            chain.Add(keyValuePair);
                        }
                    }
                }
            }
        }
    }
}
