namespace MusicStore.Api
{
    using System.Web.Http;
    using System.Web;

    using App_Start;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
