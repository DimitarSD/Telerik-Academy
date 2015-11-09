namespace StudentRecord
{
    using System;

    public class Student : IComparable<Student>
    {
        private const string InvalidNameNullExceptionMessage = "{0} name cannot be null.";
        private const string InvalidNameEmptyStringExceptionMessage = "{0} name cannot be an empty string.";
        private const string First = "First";
        private const string Last = "Last";

        private string firstName;
        private string lastName;

        /// <summary>
        /// Creates instance of Student class with initial first and last name
        /// </summary>
        /// <param name="firstName">Initial first name of the student</param>
        /// <param name="lastName">Initial last name of the student</param>
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Gets and sets the first name of the student
        /// </summary>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.ValidName(value, First);
                this.firstName = value;
            }
        }

        /// <summary>
        /// Gets and sets the last name of the student
        /// </summary>
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.ValidName(value, Last);
                this.lastName = value;
            }
        }

        /// <summary>
        /// Defines logix for comparing two students -> compare them by first by last name and them by first name
        /// </summary>
        /// <param name="other">Student to be compared</param>
        /// <returns>
        /// Returns -1 if the name of the first student is alphabetically before the name of the second
        /// Returns 0 if the name of the first student is equal the name of the second
        /// Returns 1 if the name of the first student is alphabetically after the name of the second
        /// </returns>
        public int CompareTo(Student other)
        {
            var compare = this.LastName.CompareTo(other.LastName);

            if (compare == 0)
            {
                compare = this.FirstName.CompareTo(other.FirstName);
            }

            return compare;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} {2}", this.GetType().Name, this.FirstName, this.LastName);
        }

        private void ValidName(string name, string typeOfName)
        {
            if (name == null)
            {
                string errorMessage = string.Format(InvalidNameNullExceptionMessage, typeOfName);
                throw new ArgumentNullException(errorMessage);
            }

            if (name == string.Empty)
            {
                string errorMessage = string.Format(InvalidNameEmptyStringExceptionMessage, typeOfName);
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
