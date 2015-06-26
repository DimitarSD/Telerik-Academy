﻿namespace FirstBeforeLast
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Problem 3. First before last
    // Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
    // Use LINQ query operators.
       
    // Problem 4. Age range
    // Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
       
    // Problem 5. Order students
    // Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students 
    // by first name and last name in descending order.
    // Rewrite the same with LINQ.
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private List<Student> collection;

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.collection = new List<Student>();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("The name must start with upper character");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("The name must start with upper character");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be a number bigger than 0");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public static IEnumerable<Student> FirstNameBeforeLast(IEnumerable<Student> student)
        {
            var result =
                from st in student
                where st.FirstName.CompareTo(st.LastName) < 0
                select st; 

            return result;
        }
    }
}
