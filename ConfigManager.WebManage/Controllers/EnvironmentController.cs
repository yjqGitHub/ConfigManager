using ConfigManager.Application;
using ConfigManager.TransDto.TransModel;
using ConfigManager.WebManage.Infrastructure;
using JQ.Web.Extensions;
using JQ.Web.Result;
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

        /// <summary>
        /// 添加环境信息
        /// </summary>
        /// <param name="model">环境信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JQJsonResult> Add(EnvironmentAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return ResultUtil.Failed(ModelState.GetFirstErrorMsg());
            }
            var operateResult = await _environmentApplication.AddEnvironmentAsync(model, PublicUtil.GetCurrentAdminID());
            return operateResult.ToJsonResult();
        }
    }
}