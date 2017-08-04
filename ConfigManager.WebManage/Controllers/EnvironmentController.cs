using ConfigManager.Application;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConfigManager.WebManage.Controllers
{
    public class EnvironmentController : Controller
    {
        private readonly IEnvironmentApplication _environmentApplication;

        public EnvironmentController(IEnvironmentApplication environmentApplication)
        {
            _environmentApplication = environmentApplication;
        }

        public async Task<ActionResult> Index()
        {
            var operateResult = await _environmentApplication.LoadEnvironmentListAsync();
            return View(operateResult.Value);
        }

        /// <summary>
        /// 添加环境信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
    }
}