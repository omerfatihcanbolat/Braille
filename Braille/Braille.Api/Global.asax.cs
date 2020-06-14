using Braille.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Braille.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Database.SetInitializer<ApplicationContext>(new DropCreateDatabaseIfModelChanges<ApplicationContext>());


            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
