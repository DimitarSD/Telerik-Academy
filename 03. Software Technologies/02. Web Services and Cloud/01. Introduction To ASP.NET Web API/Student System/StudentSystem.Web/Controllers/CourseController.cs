namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Web.Models;

    public class CourseController : BaseController
    {
        public CourseController(IStudentSystemData dataToUse)
            : base(dataToUse)
        {
        }

        public CourseController()
            : base(new StudentsSystemData())
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Courses.All().Select(CourseDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }

            return this.Ok(this.Data.Courses.All().Where(c => c.Id.ToString() == id).Select(CourseDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] CourseDataModel courseModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var course = CourseDataModel.FromModelToData(courseModel);
            this.Data.Courses.Add(course);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), course);
        }

        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody] CourseDataModel courseModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var course = this.Data.Courses.SearchFor(c => c.Id.ToString() == id).FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Invalid id");
            }

            course.Description = string.IsNullOrEmpty(courseModel.Description) ? course.Description : courseModel.Description;
            course.Name = string.IsNullOrEmpty(courseModel.Name) ? course.Name : courseModel.Name;

            this.Data.Courses.Update(course);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            if (id == null)
            {
                return this.BadRequest("Invalid id");
            }

            var course = this.Data.Courses.SearchFor(c => c.Id.ToString() == id).FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Invalid id");
            }

            this.Data.Courses.Delete(course);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}