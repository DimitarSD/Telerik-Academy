namespace DynamicLinkedList
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A new shiny queue implementation
    /// </summary>
    /// <typeparam name="T">The type of elements to store in the queue</typeparam>
    public class Queue<T>
    {
        private readonly LinkedList<T> elements;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Queue()
        {
            this.elements = new LinkedList<T>();
        }

        /// <summary>
        /// The number of elements in the queue
        /// </summary>
        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        /// <summary>
        /// Removes all objects from the collection.
        /// </summary>
        public void Clear()
        {
            this.elements.Clear();
        }

        /// <summary>
        /// Adds an element to the back of the queue
        /// </summary>
        /// <param name="item">The element to add</param>
        public void Enqueue(T item)
        {
            this.elements.AddLast(item);
        }

        /// <summary>
        /// Gets the first element in the queue WITHOUT removing it
        /// </summary>
        /// <returns>The top first from the queue</returns>
        public T Peek()
        {
            if (this.elements.Count == 0)
            {
                throw new ArgumentException("The queue is empty!");
            }

            return this.elements.First.Value;
        }

        /// <summary>
        /// Removes the first element from the queue
        /// </summary>
        /// <returns>The first element from the queue</returns>
        public T Dequeue()
        {
            T itemToGet = this.Peek();
            this.elements.RemoveFirst();

            return itemToGet;
        }
    }
}
