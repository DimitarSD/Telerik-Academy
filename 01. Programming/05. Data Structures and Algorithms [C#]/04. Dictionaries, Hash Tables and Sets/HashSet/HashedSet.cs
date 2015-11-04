namespace HashSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using HashTable;

    public class HashedSet<T> : IHashedSet<T>, IEnumerable, IEnumerable<T> where T : IComparable<T>
    {
        private const string NullCollectionExceptionMessage = "Collection cannot be null.";
        private const string NullCollectionForUnionExceptionMessage = "Collection for union cannot be null.";
        private const string NullCollectionForIntersectExceptionMessage = "Collection for intersect cannot be null.";

        private readonly HashTable<T, bool> elements;

        /// <summary>
        /// Creates an instance of HashedSet class with empty HashTable
        /// </summary>
        public HashedSet()
        {
            this.elements = new HashTable<T, bool>();
        }

        /// <summary>
        /// Creates an instance of HashedSet class with given collection
        /// </summary>
        /// <param name="collection">Collection to be added</param>
        public HashedSet(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(NullCollectionExceptionMessage);
            }

            this.elements = new HashTable<T, bool>();

            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Gets the number of elements that are contained in a set.
        /// </summary>
        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        /// <summary>
        /// Gets a collection containing the keys in the set.
        /// </summary>
        public IEnumerable<T> Keys
        {
            get
            {
                var keys = new List<T>(this.elements.Keys);
                return keys;
            }
        }

        /// <summary>
        /// Adds the specified element to a set.
        /// </summary>
        /// <param name="item">The element to add to the set.</param>
        public bool Add(T item)
        {
            if (this.Contains(item))
            {
                return false;
            }

            this.elements.Add(item, true);

            return true;
        }

        /// <summary>
        /// Determines whether a set contains the specified element.
        /// </summary>
        /// <param name="item">The element to locate in the set.</param>
        public bool Contains(T item)
        {
            return this.elements.ContainsKey(item);
        }

        /// <summary>
        /// Removes the specified element from the set.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        public bool Remove(T item)
        {
            return this.elements.Remove(item);
        }

        /// <summary>
        /// Removes all elements from a set.
        /// </summary>
        public void Clear()
        {
            this.elements.Clear();
        }

        /// <summary>
        /// Modifies the current set to contain all elements that are present in itself,
        /// the specified collection, or both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(NullCollectionForUnionExceptionMessage);
            }

            foreach (var item in other)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Modifies the current set to contain only elements that are present in that set
        /// and in the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(NullCollectionForIntersectExceptionMessage);
            }

            var otherHashedSet = new HashedSet<T>(other);

            foreach (var item in this.Keys)
            {
                if (!otherHashedSet.Contains(item))
                {
                    this.Remove(item);
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a set.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.Keys)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
