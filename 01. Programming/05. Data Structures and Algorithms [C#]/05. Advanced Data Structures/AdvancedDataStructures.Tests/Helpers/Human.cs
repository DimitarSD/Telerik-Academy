namespace AdvancedDataStructures.Tests.Helpers
{
    using System;

    internal class Human : IComparable
    {
        /// <summary>
        /// Creates an instance of Human class with initial name and age
        /// </summary>
        /// <param name="name">Name of the human</param>
        /// <param name="age">Age of the human</param>
        public Human(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        /// <summary>
        /// Gets and sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets the age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Define logic to compare two human -> compare them by age
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>
        /// Returns -1 if the age of first human is smaller than age of the second.
        /// Returns 0 if the age of first human is equal to the second.
        /// Returns 1 if the age of first human is larger than the age of the second.
        /// </returns>
        public int CompareTo(object obj)
        {
            var other = obj as Human;

            if (ReferenceEquals(other, null))
            {
                return -1;
            }

            var comparisonByAge = this.Age.CompareTo(other.Age);
            return comparisonByAge;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}", this.Name, this.Age);
        }
    }
}
