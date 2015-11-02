namespace StudentSystem.Web.Models
{
    using System;
    using StudentSystem.Models;

    public class CourseDataModel
    {
        public static Func<Course, CourseDataModel> FromDataToModel
        {
            get
            {
                return c => new CourseDataModel
                {
                    Name = c.Name,
                    Description = c.Description
                };
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public static Course FromModelToData(CourseDataModel model)
        {
            return new Course
            {
                Name = model.Name,
                Description = model.Description
            };
        }
    }
}