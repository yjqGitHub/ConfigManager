using ConfigManage.WebManage.Infrastructure;
using ConfigManage.WebManage.Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfigManage.WebManage.Controllers
{
    [Login]
    public class DeployEnvironmentController : Controller
    {
        // GET: DeployEnvironment
        public ActionResult Index()
        {
            return View();
        }
    }
}