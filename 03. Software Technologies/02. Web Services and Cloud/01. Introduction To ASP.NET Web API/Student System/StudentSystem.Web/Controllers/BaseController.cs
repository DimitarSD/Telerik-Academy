namespace StudentSystem.Web.Controllers
{
    using System.Web.Http;

    using StudentSystem.Data;

    public class BaseController : ApiController
    {
        private IStudentSystemData data;

        public BaseController(IStudentSystemData dataToUse)
        {
            this.data = dataToUse;
        }

        public IStudentSystemData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}