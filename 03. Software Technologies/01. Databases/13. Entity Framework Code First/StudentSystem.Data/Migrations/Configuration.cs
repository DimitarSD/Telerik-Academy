using StudentSystem.Models;

namespace StudentSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<StudentsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "StudentSystem.Data.StudentsDbContext";
        }

        protected override void Seed(StudentsDbContext context)
        {

            context.Students.AddOrUpdate(
                s => s.Name,
                new Student
            {
                Name = "Ivaylo Kenov",
                FacultyNumber = 232455271
            });

            context.Courses.AddOrUpdate(
                c => c.Name,
                new Course
            {
                Name = "Data Structures and Algorithms",
                Description = "Da si ebe maikata"
            });
        }
    }
}
