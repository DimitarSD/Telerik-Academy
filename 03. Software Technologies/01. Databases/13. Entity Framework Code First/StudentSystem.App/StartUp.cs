namespace StudentSystem.App
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data;
    using Models;
    using Data.Migrations;

    public class StartUp
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsDbContext, Configuration>());

            var db = new StudentsDbContext();

            var student = new Student
            {
                Name = "Nikolay Kostov",
                FacultyNumber = 232435231
            };

            db.Students.Add(student);
            db.SaveChanges();

            

            Console.WriteLine(db.Students.Count());

        }
    }
}
