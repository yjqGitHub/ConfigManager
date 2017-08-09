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
            return View(new EnvironmentEditModel());
        }

        /// <summary>
        /// 添加环境信息
        /// </summary>
        /// <param name="model">环境信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JQJsonResult> Add(EnvironmentEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return ResultUtil.Failed(ModelState.GetFirstErrorMsg());
            }
            var operateResult = await _environmentApplication.AddEnvironmentAsync(model, PublicUtil.GetCurrentAdminID());
            return operateResult.ToJsonResult();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || id.Value <= 0)
            {
                return View("~/Views/Shared/NotFind.cshtml");
            }
            var operateResult = await _environmentApplication.GetEnvironmentModelAsync(id.Value);
            if (operateResult.SuccessAndValueNotNull)
            {
                return View(operateResult.Value);
            }
            else
            {
                return View("~/Views/Shared/NotFind.cshtml");
            }
        }

        /// <summary>
        /// 修改环境信息
        /// </summary>
        /// <param name="model">环境信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JQJsonResult> Edit(EnvironmentEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return ResultUtil.Failed(ModelState.GetFirstErrorMsg());
            }
            var operateResult = await _environmentApplication.EditEnvironmentAsync(model, PublicUtil.GetCurrentAdminID());
            return operateResult.ToJsonResult();
        }

        /// <summary>
        /// 删除环境
        /// </summary>
        /// <param name="environmentID">环境ID</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JQJsonResult> Delete(int environmentID)
        {
            var operateResult = await _environmentApplication.DeleteEnvironmentAsync(environmentID, PublicUtil.GetCurrentAdminID());
            return operateResult.ToJsonResult();
        }
    }
}