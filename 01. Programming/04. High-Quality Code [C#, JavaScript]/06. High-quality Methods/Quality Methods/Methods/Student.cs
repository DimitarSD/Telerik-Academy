namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        /// <summary>
        /// Gets two students and check if the one is older that other
        /// </summary>
        /// <param name="studentToCompare">Student to compare with</param>
        /// <returns>Return a boolean value</returns>
        public bool IsOlderThan(Student studentToCompare)
        {
            string firstStudentBornDate = this.OtherInfo.Substring(this.OtherInfo.Length - 10);
            DateTime firstDate = DateTime.Parse(firstStudentBornDate);

            string secondStudentBornDate = studentToCompare.OtherInfo.Substring(studentToCompare.OtherInfo.Length - 10);
            DateTime secondDate = DateTime.Parse(secondStudentBornDate);

            return firstDate < secondDate;
        }
    }
}
