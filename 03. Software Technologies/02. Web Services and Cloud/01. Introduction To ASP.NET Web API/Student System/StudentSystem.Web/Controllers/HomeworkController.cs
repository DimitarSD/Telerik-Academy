namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Models;
    using StudentSystem.Data;
    
    public class HomeworkController : BaseController
    {
        public HomeworkController(IStudentSystemData dataToUse) 
            : base(dataToUse)
        {
        }

        public HomeworkController()
            : base(new StudentsSystemData())
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Homework.All().Select(HomeworkDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            if (id == null)
            {
                return this.BadRequest("Invalid id");
            }

            return this.Ok(this.Data.Homework
                .All()
                .Where(h => h.Id.ToString() == id)
                .Select(HomeworkDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] HomeworkDataModel homeworkModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var homework = HomeworkDataModel.FromModelToData(homeworkModel);
            this.Data.Homework.Add(homework);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), homework);
        }

        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody] HomeworkDataModel homeworkModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var homework = this.Data.Homework.SearchFor(h => h.Id.ToString() == id).FirstOrDefault();

            if (homework == null)
            {
                return this.BadRequest("Invalid id");
            }

            homework.FileUrl =
                string.IsNullOrEmpty(homeworkModel.FileUrl) ? homework.FileUrl : homeworkModel.FileUrl;
            
            this.Data.Homework.Update(homework);
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

            var homework = this.Data.Homework.SearchFor(h => h.Id.ToString() == id).FirstOrDefault();

            if (homework == null)
            {
                return this.BadRequest("Invalid id");
            }

            this.Data.Homework.Delete(homework);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}