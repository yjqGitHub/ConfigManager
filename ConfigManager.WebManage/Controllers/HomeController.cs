using ConfigManager.Application;
using ConfigManager.WebManage.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConfigManager.WebManage.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnvironmentApplication _environmentApplication;

        public HomeController(IEnvironmentApplication environmentApplication)
        {
            _environmentApplication = environmentApplication;
        }
        public async Task<ActionResult> Index()
        {
            var operateResult = await _environmentApplication.LoadEnvironmentListAsync();
            ViewBag.EnvironmentList = operateResult.Value;
            return View();
        }
    }
}