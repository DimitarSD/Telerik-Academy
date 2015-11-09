namespace StudentRecord
{
    using System;

    public class Course : IComparable<Course>, IEquatable<Course>
    {
        private const string InvalidNameNullExcepionMessage = "Name cannot be null.";
        private const string InvalidNameEmptyStringExceptionMessage = "Name cannoe be an empty string.";

        private string name;

        /// <summary>
        /// Creates instance of Course class
        /// </summary>
        /// <param name="name">Initial course name</param>
        public Course(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets and sets name of the course
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(InvalidNameNullExcepionMessage);
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException(InvalidNameEmptyStringExceptionMessage);
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Defines logic for comparing two courses -> compare them by name
        /// </summary>
        /// <param name="other">Course to be compared</param>
        /// <returns>
        /// Returns -1 if the name of the first course is alphabetically before the name of the second
        /// Returns 0 if the name of the first course is equal the name of the second
        /// Returns 1 if the name of the first course is alphabetically after the name of the second
        /// </returns>
        public int CompareTo(Course other)
        {
            return string.Compare(this.Name, other.Name, true);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Course);
        }

        /// <summary>
        /// Defines logic for check if two course are equal
        /// </summary>
        /// <param name="other">Course to check</param>
        /// <returns>Boolean value</returns>
        public bool Equals(Course other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Compare(this.Name, other.Name, true) == 0;
        }

        public override int GetHashCode()
        {
            return !string.IsNullOrEmpty(this.Name) ? this.Name.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.GetType().Name, this.Name);
        }
    }
}
