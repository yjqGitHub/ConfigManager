using ConfigManage.WebManage.Infrastructure;
using ConfigManage.WebManage.Infrastructure.Filters;
using ConfigManager.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConfigManage.WebManage.Controllers
{
    public class DeployEnvironmentController : Controller
    {
        private readonly IEnvironmentApplication _environmentApplication;
        public DeployEnvironmentController(IEnvironmentApplication environmentApplication)
        {
            _environmentApplication = environmentApplication;
        }

        public async Task<ActionResult> Index()
        {
            var operateResult = await _environmentApplication.LoadEnvironmentListAsync();
            return View(operateResult.Value);
        }
    }
}