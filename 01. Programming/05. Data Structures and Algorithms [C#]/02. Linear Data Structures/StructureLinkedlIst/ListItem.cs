namespace StructureLinkedlIst
{
    /// <summary>
    /// Define class for creating the LinkedList items
    /// </summary>
    /// <typeparam name="T">Type of variable</typeparam>
    public class ListItem<T>
    {
        private T value;
        private ListItem<T> nextItem;

        public ListItem(T data)
        {
            this.Value = data;
        }

        /// <summary>
        /// Gets and Sets the value of the LinkedList
        /// </summary>
        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        /// <summary>
        /// Gets and Sets the next item in the LinkedList
        /// </summary>
        public ListItem<T> NextItem
        {
            get
            {
                return this.nextItem;
            }

            set
            {
                this.nextItem = value;
            }
        }
    }
}
