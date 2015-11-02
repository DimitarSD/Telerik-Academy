namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Web.Models;

    public class TestController : BaseController
    {
        public TestController(IStudentSystemData dataToUse)
            : base(dataToUse)
        {
        }

        public TestController()
            : base(new StudentsSystemData())
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Tests.All().Select(TestDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            if (id == null)
            {
                return this.BadRequest("Invalid id");
            }

            return this.Ok(this.Data.Tests
                .All()
                .Where(t => t.Id.ToString() == id)
                .Select(TestDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Course testModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var test = TestDataModel.FromModelToData(testModel);
            this.Data.Tests.Add(test);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), test);
        }

        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody] Course testModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var test = this.Data.Tests.SearchFor(t => t.Id.ToString() == id).FirstOrDefault();

            if (test == null)
            {
                return this.BadRequest("Invalid id");
            }

            test.Course.Name =
                string.IsNullOrEmpty(testModel.Name) ? test.Course.Name : testModel.Name;

            this.Data.Tests.Update(test);
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

            var test = this.Data.Tests.SearchFor(t => t.Id.ToString() == id).FirstOrDefault();

            if (test == null)
            {
                return this.BadRequest("Invalid id");
            }

            this.Data.Tests.Delete(test);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}