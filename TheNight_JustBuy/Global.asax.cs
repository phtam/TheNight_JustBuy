using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TheNight_JustBuy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application[Common.CommonConstants.TOTAL_VISITORS] = 0;
        }

        protected void Session_Start()
        {
            Application.Lock();
            Application[Common.CommonConstants.TOTAL_VISITORS] = (int)Application[Common.CommonConstants.TOTAL_VISITORS] + 1;
            Application.UnLock();
        }
    }
}
