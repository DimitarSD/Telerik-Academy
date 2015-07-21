namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class CoursesExamples
    {
        public static void Main()
        {
            string firstCourseName = "JS DOM and UI";
            string firstCourseLector = "Doncho Minkov";
            var firstCourseStudents = new List<string>() { "Peter", "Maria" };
            string firstCourseLabName = "Enterprise";

            LocalCourse localCourse = new LocalCourse(firstCourseName, firstCourseLector, firstCourseStudents, firstCourseLabName);
            Console.WriteLine(localCourse);
            localCourse.Add("Milena");
            localCourse.Add("Todor");
            Console.WriteLine(localCourse);

            string secondCourseName = "DSA";
            string secondCourseLector = "Nikolay Kostov";
            var secondCourseStudents = new List<string>() { "Thomas", "Ani", "Steve" };
            string secondCourseTownName = "Sofia";

            OffsiteCourse offsiteCourse = new OffsiteCourse(secondCourseName, secondCourseLector, secondCourseStudents, secondCourseTownName);
            Console.WriteLine(offsiteCourse);
        }
    }
}
