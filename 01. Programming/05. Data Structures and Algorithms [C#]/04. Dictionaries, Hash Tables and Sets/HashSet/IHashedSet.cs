namespace HashSet
{
    using System;
    using System.Collections.Generic;

    public interface IHashedSet<T> where T : IComparable<T>
    {
        /// <summary>
        /// Defines add method to add new item to the HashSet
        /// </summary>
        /// <param name="item">Item to be added</param>
        /// <returns>Returs true if the adding is successful and false if it is not</returns>
        bool Add(T item);

        /// <summary>
        /// Defines Contains method to check if the HashSet contains the given item
        /// </summary>
        /// <param name="item">Item to be checked</param>
        /// <returns>Returs true if HashSet contains the item and and false if it is not</returns>
        bool Contains(T item);

        /// <summary>
        /// Defines Remove method for removing an element
        /// </summary>
        /// <param name="item">Item to be removed</param>
        /// <returns>Returs true if the removing is successful and false if it is not</returns>
        bool Remove(T item);

        /// <summary>
        /// Defines Clear method for cleaning the HashSet
        /// </summary>
        void Clear();

        /// <summary>
        /// Defines method for making Union with another HashSet
        /// </summary>
        /// <param name="other">HashSet which will be used for the union</param>
        void UnionWith(IEnumerable<T> other);

        /// <summary>
        /// Defines method for making Intersect with another HashSet
        /// </summary>
        /// <param name="other">HashSet which will be used for the union</param>
        void IntersectWith(IEnumerable<T> other);
    }
}
