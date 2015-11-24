namespace Sorting
{
    using System;
    using System.Collections.Generic;

    using Constants;

    /// <summary>
    /// Defines class implementing searching algorithms
    /// </summary>
    public static class SearchingAlgorithms
    {
        /// <summary>
        /// Define extended method for Linear Search algorithm
        /// </summary>
        /// <typeparam name="T">Type of collection elements</typeparam>
        /// <param name="collection">Collection in witch to search</param>
        /// <param name="item">Item to search</param>
        /// <see cref="http://www.codingeek.com/algorithms/linear-search-algorithm-and-its-implementation-example/"/>
        /// <returns>Returns integer -1, 0 or 1</returns>
        public static int LinearSearch<T>(this IList<T> collection, T item) where T : IComparable<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException(ExceptionMessage.CollectionCannotBeNullExceptionMessage);
            }

            for (int index = 0; index < collection.Count; index++)
            {
                if (collection[index].CompareTo(item) == 0)
                {
                    return index;
                }
            }

            return -1;
        }

        /// <summary>
        /// Define extended method for Binary Search algorithm
        /// </summary>
        /// <typeparam name="T">Type of collection elements</typeparam>
        /// <param name="collection">Collection in witch to search</param>
        /// <param name="item">Item to search</param>
        /// <see cref="https://en.wikipedia.org/wiki/Binary_search_algorithm"/>
        /// <seealso cref="https://bg.khanacademy.org/computing/computer-science/algorithms/binary-search/a/implementing-binary-search-of-an-array"/>
        /// <returns></returns>
        public static int BinarySearch<T>(this IList<T> collection, T item) where T : IComparable<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException(ExceptionMessage.CollectionCannotBeNullExceptionMessage);
            }

            int left = 0;
            int right = collection.Count - 1;
            int middle = 0;

            while (left <= right)
            {
                middle = GetMedian(left, right);

                if (collection[middle].CompareTo(item) < 0)
                {
                    left = middle + 1;
                }
                else if (collection[middle].CompareTo(item) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }

        /// <summary>
        /// Gets the median in collection
        /// </summary>
        /// <param name="startIndex">Start index</param>
        /// <param name="endIndex">End index</param>
        /// <returns></returns>
        private static int GetMedian(int startIndex, int endIndex)
        {
            return startIndex + ((endIndex - startIndex) >> 1);
        }
    }
}
