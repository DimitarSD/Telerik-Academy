namespace Sorting
{
    using System;
    using System.Collections.Generic;

    using Constants;

    /// <summary>
    /// Define class for selection sort algorithm and its implementation
    /// </summary>
    /// <typeparam name="T">Type of the elements to be sorted</typeparam>
    /// <see cref="https://en.wikipedia.org/wiki/Selection_sort"/>
    /// <seealso cref="http://www.algolist.net/Algorithms/Sorting/Selection_sort"/>
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(ExceptionMessage.CollectionCannotBeNullExceptionMessage);
            }

            int swapIndex = 0;

            for (int i = 0; i < collection.Count - 1; i++)
            {
                swapIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[swapIndex].CompareTo(collection[j]) > 0)
                    {
                        swapIndex = j;
                    }
                }

                this.Swap(collection, i, swapIndex);
            }
        }

        private void Swap(IList<T> collection, int index, int swapIndex)
        {
            T swap = collection[index];
            collection[index] = collection[swapIndex];
            collection[swapIndex] = swap;
        }
    }
}
