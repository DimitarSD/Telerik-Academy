namespace LinkedList
{
    using System;

    public class LinkedList<T>
    {
        private ListItem<T> firstItem;
        private ListItem<T> lastItem;
        private ListItem<T> currentItem;
        
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

        public int Count
        {
            get
            {
                return this.GetCount();
            }
        }

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
                while(this.currentItem.NextItem != null)
                {
                    this.currentItem = this.currentItem.NextItem;
                }

                this.currentItem = item;
            }
        }

        public void Print()
        {
            this.currentItem = this.FirstItem;

            Console.WriteLine(this.currentItem.Value);
            while(this.currentItem.NextItem != null)
            {
                this.currentItem = this.currentItem.NextItem;
                Console.WriteLine(this.currentItem.Value);
            }
        }
    }
}
