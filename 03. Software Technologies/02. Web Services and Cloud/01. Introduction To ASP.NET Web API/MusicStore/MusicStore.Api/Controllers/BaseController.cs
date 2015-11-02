namespace MusicStore.Api.Controllers
{
    using System.Web.Http;

    using Data.Contracts;

    public class BaseController : ApiController
    {
        private IMusicStoreData data;

        public BaseController(IMusicStoreData data)
        {
            this.data = data;
        }

        public IMusicStoreData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}