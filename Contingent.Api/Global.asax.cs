using System;
using System.Web.Http;

namespace Contingent.Api
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(config =>
            {
                config.MapHttpAttributeRoutes();
                //config.Routes.MapHttpRoute("", "api/v1/{controller}/{id:int?}");
            });
        }
    }
}