﻿using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ConfigManage.WebManage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BootStrapper.Install();
            ViewEngines.Engines.Clear();//清除原有引擎
            ViewEngines.Engines.Add(new RazorViewEngine());//加入Razor引擎
        }

        protected void Application_End(object sender, EventArgs e)
        {
            BootStrapper.UnInstall();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }
    }
}