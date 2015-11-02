namespace StudentSystem.Web.Models
{
    using System;

    using StudentSystem.Models;

    public class TestDataModel
    {
        public static Func<Test, TestDataModel> FromDataToModel
        {
            get
            {
                return t => new TestDataModel
                {
                    Course = t.Course.Name
                };
            }
        }

        public string Course { get; set; }

        public static Test FromModelToData(Course testModel)
        {
            return new Test()
            {
                Course = testModel
            };
        }
    }
}