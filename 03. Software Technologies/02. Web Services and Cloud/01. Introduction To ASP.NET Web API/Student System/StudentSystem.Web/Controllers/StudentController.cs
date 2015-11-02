namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    
    using Models;
    using StudentSystem.Data;

    public class StudentController : BaseController
    {
        public StudentController(IStudentSystemData dataToUse) 
            : base(dataToUse)
        {
        }

        public StudentController() 
            : base(new StudentsSystemData())
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Students.All().Select(StudentDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            if (id == null)
            {
                return this.BadRequest("Invalid id");
            }

            return this.Ok(this.Data.Students
                .All()
                .Where(s => s.StudentIdentification.ToString() == id)
                .Select(StudentDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] StudentDataModel studentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var student = StudentDataModel.FromModelToData(studentModel);
            this.Data.Students.Add(student);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), student);
        }

        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody] StudentDataModel studentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var student = this.Data.Students.SearchFor(s => s.StudentIdentification.ToString() == id).FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest("Invalid id");
            }

            student.AdditionalInformation.Email = 
                string.IsNullOrEmpty(studentModel.Email) ? student.AdditionalInformation.Email : studentModel.Email;

            student.AdditionalInformation.Address = 
                string.IsNullOrEmpty(studentModel.Address) ? student.AdditionalInformation.Address : studentModel.Address;

            this.Data.Students.Update(student);
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

            var student = this.Data.Students.SearchFor(s => s.StudentIdentification.ToString() == id).FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest("Invalid id");
            }

            this.Data.Students.Delete(student);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}