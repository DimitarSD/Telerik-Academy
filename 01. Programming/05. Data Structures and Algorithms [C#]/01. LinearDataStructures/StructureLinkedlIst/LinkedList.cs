namespace StructureLinkedlIst
{
    using System;

    /// <summary>
    /// Define implementation of the LinkedList with methods - AddFirst, AddLast, Print
    /// </summary>
    /// <typeparam name="T">Type of variable</typeparam>
    public class LinkedList<T>
    {
        private ListItem<T> firstItem;
        private ListItem<T> lastItem;
        private ListItem<T> currentItem;

        /// <summary>
        /// Gets and Sets the first item
        /// </summary>
        public ListItem<T> FirstItem
        {
            get
            {
                return this.firstItem;
            }

            set
            {
                this.firstItem = value;
            }
        }

        /// <summary>
        /// Gets and Sets the last item
        /// </summary>
        public ListItem<T> LastItem
        {
            get
            {
                return this.lastItem;
            }

            set
            {
                this.lastItem = value;
            }
        }

        /// <summary>
        /// Returns the number of elements
        /// </summary>
        public int Count
        {
            get
            {
                return this.GetCount();
            }
        }

        /// <summary>
        /// Adding element of type T at the beggining of the LinkedList
        /// </summary>
        /// <param name="value">Gets a value of type T</param>
        public void AddFirst(T value)
        {
            if (this.FirstItem == null)
            {
                this.FirstItem = new ListItem<T>(value);
                this.LastItem = new ListItem<T>(value);
            }
            else
            {
                var item = new ListItem<T>(value);

                item.NextItem = this.FirstItem;
                this.FirstItem = item;
            }
        }

        /// <summary>
        /// Adding an element of type T at the end of the LinkedList
        /// </summary>
        /// <param name="value">Gets a value of type T</param>
        public void AddLast(T value)
        {
            if (this.LastItem == null)
            {
                this.FirstItem = new ListItem<T>(value);
                this.LastItem = new ListItem<T>(value);
            }
            else
            {
                var item = new ListItem<T>(value);

                this.currentItem = this.FirstItem;
                while (this.currentItem.NextItem != null)
                {
                    this.currentItem = this.currentItem.NextItem;
                }

                this.currentItem.NextItem = item;
            }
        }

        /// <summary>
        /// Prints all elements from the LinkedList
        /// </summary>
        public void Print()
        {
            this.currentItem = this.FirstItem;

            Console.WriteLine(this.currentItem.Value);
            while (this.currentItem.NextItem != null)
            {
                this.currentItem = this.currentItem.NextItem;
                Console.WriteLine(this.currentItem.Value);
            }
        }

        /// <summary>
        /// Counting the elements in the LinkedList
        /// </summary>
        /// <returns>Returns an integer - number of elements in the LinkedList</returns>
        private int GetCount()
        {
            if (this.FirstItem == null)
            {
                return 0;
            }

            this.currentItem = this.FirstItem;

            int elementCounter = 1;
            while (this.currentItem.NextItem != null)
            {
                elementCounter++;
                this.currentItem = this.currentItem.NextItem;
            }

            return elementCounter;
        }
    }
}
