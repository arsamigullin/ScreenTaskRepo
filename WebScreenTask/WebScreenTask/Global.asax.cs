using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WCFTaskScreen;
using WebScreenTask;

namespace WebScreenTask
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ChannelFactory<IScreenShotable> myChannelFactory = new ChannelFactory<IScreenShotable>(new BasicHttpBinding(), new EndpointAddress("http://localhost:8000/WCFTaskScreen"));
            GlobalData.WCFClient = myChannelFactory.CreateChannel();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
    }
}
