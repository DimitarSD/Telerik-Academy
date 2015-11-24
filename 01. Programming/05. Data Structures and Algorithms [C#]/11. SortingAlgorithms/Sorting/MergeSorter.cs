namespace Sorting
{
    using System;
    using System.Collections.Generic;

    using Constants;

    /// <summary>
    /// Define class for merge sort algorithm and its implementation
    /// </summary>
    /// <typeparam name="T">Type of the elements to be sorted</typeparam>
    /// <see cref="https://en.wikipedia.org/wiki/Merge_sort"/>
    /// <seealso cref="https://www.youtube.com/watch?v=TzeBrDU-JaY"/>
    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private T[] collectionKeeper;

        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(ExceptionMessage.CollectionCannotBeNullExceptionMessage);
            }

            this.collectionKeeper = new T[collection.Count];
            this.Partitioning(collection, 0, collection.Count - 1);
        }

        private void Partitioning(IList<T> collection, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            int middleIndex = (leftIndex + rightIndex) / 2;

            this.Partitioning(collection, leftIndex, middleIndex);
            this.Partitioning(collection, middleIndex + 1, rightIndex);

            this.Merge(collection, leftIndex, middleIndex, rightIndex);
        }
                
        private void Merge(IList<T> collection, int leftIndex, int middleIndex, int rightIndex)
        {
            int keeperPointer = leftIndex; // used for collectionKeeper
            int leftPointer = leftIndex, rightPointer = middleIndex + 1;

            while (leftPointer <= middleIndex && rightPointer <= rightIndex)
            {
                if (collection[leftPointer].CompareTo(collection[rightPointer]) < 0)
                {
                    this.collectionKeeper[keeperPointer++] = collection[leftPointer++];
                }
                else
                {
                    this.collectionKeeper[keeperPointer++] = collection[rightPointer++];
                }
            }

            while (leftPointer <= middleIndex)
            {
                this.collectionKeeper[keeperPointer++] = collection[leftPointer++];
            }

            while (rightPointer <= rightIndex)
            {
                this.collectionKeeper[keeperPointer++] = collection[rightPointer++];
            }

            for (int index = leftIndex; index <= rightIndex; index++)
            {
                collection[index] = this.collectionKeeper[index];
            }
        }
    }
}
