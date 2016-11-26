using AndrewD.RecordLabel.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace AndrewD.RecordLabel.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            System.Data.Entity.Database.SetInitializer(new Data.EF.Configuration.DropAndSeedOnChanges<ReleaseContext>());
            //System.Data.Entity.Database.SetInitializer(new Data.EF.Configuration.DropAndSeedAlways<ReleaseContext>());
        }
    }
}