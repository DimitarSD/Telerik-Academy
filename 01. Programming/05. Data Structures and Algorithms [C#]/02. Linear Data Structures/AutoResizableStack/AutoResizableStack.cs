namespace AutoResizableStack
{
    using System;

    public class AutoResizableStack<T>
    {
        private const string RemovingElementFromEmptyStackExceptionMessage = "You can't remove an element from an empty stack";
        private const string PeekElementFromEmptyStackExceptionMessage = "Cannot peek an element from empty stack";

        private static readonly int StackInitialCapacity = 1;

        private T[] stackArray;
        private int stackCounter;
        private int index;

        /// <summary>
        /// Creates a new instance of the AutoResizableStack class
        /// </summary>
        public AutoResizableStack()
        {
            this.stackArray = new T[StackInitialCapacity];
            this.stackCounter = StackInitialCapacity;
            this.index = 0;
        }

        /// <summary>
        /// Gets the count of the AutoResizableStack
        /// </summary>
        public int Count
        {
            get
            {
                return this.index;
            }
        }

        /// <summary>
        /// Gets the capacity of the AutoResizableStack
        /// </summary>
        public int Capacity
        {
            get
            {
                return this.stackCounter;
            }
        }

        /// <summary>
        /// Add a value to the auto-resizable stack
        /// </summary>
        /// <param name="value">Gets an value of type T</param>
        public void Push(T value)
        {
            if (this.Count == this.stackCounter)
            {
                this.stackCounter *= 2;

                var doubleSizedArray = new T[this.stackCounter];

                Array.Copy(this.stackArray, doubleSizedArray, this.index);

                this.stackArray = doubleSizedArray;
            }

            this.stackArray[this.index] = value;
            this.index++;
        }

        /// <summary>
        /// Removes an element from the auto-resizable stack
        /// </summary>
        public void Pop()
        {
            if (this.stackArray.Length == 1)
            {
                throw new ArgumentException(RemovingElementFromEmptyStackExceptionMessage);
            }

            // Creating new array with capacity equal to "this.stackCounter"
            var newArray = new T[this.stackCounter];

            // Copying the old array in the new one.
            // As last argument we pass the number of elements to copy 
            Array.Copy(this.stackArray, newArray, this.index - 1);

            // Sets the old array to link to the reference of the new one
            this.stackArray = newArray;
            this.index--;
        }

        /// <summary>
        /// Returns the last element in the auto-resizable stack
        /// </summary>
        /// <returns>Returns variable of type T</returns>
        public T Peek()
        {
            if (this.index == 0)
            {
                throw new ArgumentException(PeekElementFromEmptyStackExceptionMessage);
            }

            return this.stackArray[this.index - 1];
        }
    }
}
