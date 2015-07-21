namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private const string InvalidLabNameExceptionMessage = "Lab name cannot be null or empty string";

        private string lab;

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidLabNameExceptionMessage);
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder localCourseAsString = new StringBuilder(base.ToString());

            localCourseAsString.AppendLine("Lab = " + this.Lab);

            return localCourseAsString.ToString();
        }
    }
}
