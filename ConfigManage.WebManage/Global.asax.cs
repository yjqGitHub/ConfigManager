using System;
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
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootStrapper.Install();
            ViewEngines.Engines.Clear();//清除原有引擎
            ViewEngines.Engines.Add(new RazorViewEngine());//加入Razor引擎
        }

        protected void Application_End(object sender, EventArgs e)
        {
            BootStrapper.UnInstall();
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            //每次请求时第一个出发的事件，这个方法第一个执行
            var aa = Request;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }
    }
}