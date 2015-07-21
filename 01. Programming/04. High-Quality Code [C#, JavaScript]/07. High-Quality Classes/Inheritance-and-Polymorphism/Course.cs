namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private const string NameNullValueExceptionMessage = "Name cannot be null";
        private const string NameEmptyStringValueExceptionMessage = "Name cannot be an empty string";
        private const string TeacherNameNullValueExceptionMessage = "Teacher name cannot be null";
        private const string TeacherNameEmptyStringExceptionMessage = "Teacher name cannot be an empty string";
        private const string InvalidStudentName = "Student name cannot be null or empty string";

        private string name;
        private string teacherName;
        private ICollection<string> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<string>();
        }

        public Course(string name, string teacherName) 
            : this(name)
        {
            this.TeacherName = teacherName;
        }

        public Course(string name, string teacherName, ICollection<string> students)
            : this(name, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(NameNullValueExceptionMessage);
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException(NameEmptyStringValueExceptionMessage);
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(TeacherNameNullValueExceptionMessage);
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException(TeacherNameEmptyStringExceptionMessage);
                }

                this.teacherName = value;
            }
        }

        public ICollection<string> Students
        {
            get
            {
                return new List<string>(this.students);
            }

            private set
            {
                this.students = new List<string>(value);
            }
        }

        public void Add(params string[] students)
        {
            foreach (var student in students)
            {
                if (string.IsNullOrEmpty(student))
                {
                    throw new ArgumentException(InvalidStudentName);
                }

                this.students.Add(student);
            }
        }

        public override string ToString()
        {
            StringBuilder courseAsString = new StringBuilder();

            courseAsString.AppendFormat("{0} {{ Name = {1}", this.GetType().Name, this.Name);
            courseAsString.AppendFormat("; Students = {0}", this.GetStudentsAsString());
            courseAsString.Append(" }");

            return courseAsString.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
