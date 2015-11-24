namespace Sorting
{
    using System;
    using System.Collections.Generic;

    using Constants;

    public static class ShuffleAlgorithms
    {
        private static Random randomIndex = new Random();

        /// <summary>
        /// Shuffle the collection using Fisher-Yates Shuffle Algorithm with time complexity O(n).
        /// </summary>
        /// <typeparam name="T">Collection element type.</typeparam>
        /// <param name="collection">Collection to shuffle.</param>
        public static void Shuffle<T>(this IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(ExceptionMessage.CollectionCannotBeNullExceptionMessage);
            }

            for (int i = collection.Count; i > 1; i--)
            {
                int index = randomIndex.Next(i);
                Swap<T>(collection, index, i);
            }
        }

        private static void Swap<T>(IList<T> collection, int index, int i)
        {
            T oldValue = collection[index];
            collection[index] = collection[i - 1];
            collection[i - 1] = oldValue;
        }
    }
}
