namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private const string InvalidTownNameExceptionMessage = "Town name cannot be null or empty string";

        private string town;

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidTownNameExceptionMessage);
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder offsiteCourseAsString = new StringBuilder(base.ToString());

            offsiteCourseAsString.AppendLine("Town = " + this.Town);

            return offsiteCourseAsString.ToString();
        }
    }
}
