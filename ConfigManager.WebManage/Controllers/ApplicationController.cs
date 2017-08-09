using ConfigManager.Application;
using ConfigManager.TransDto.QueryWhereDto;
using ConfigManager.TransDto.TransModel;
using ConfigManager.WebManage.Infrastructure;
using JQ.Web.Extensions;
using JQ.Web.Result;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConfigManager.WebManage.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IApplicationApplication _applicationApplication;
        private readonly IEnvironmentApplication _environmentApplication;

        public ApplicationController(IApplicationApplication applicationApplication, IEnvironmentApplication environmentApplication)
        {
            _applicationApplication = applicationApplication;
            _environmentApplication = environmentApplication;
        }

        /// <summary>
        /// 加载项目列表
        /// </summary>
        /// <param name="queryWhereDto">查询条件</param>
        /// <returns></returns>
        public async Task<ActionResult> Index(ApplicationQueryWhereDto queryWhereDto)
        {
            var operateResult = await _applicationApplication.LoadApplicationListAsync(queryWhereDto);
            ViewBag.QueryWhereDto = queryWhereDto;
            ViewBag.EnvironmentID = queryWhereDto?.EnvironmentID;
            return View(operateResult.Value);
        }

        #region 添加

        /// <summary>
        /// 应用添加页面
        /// </summary>
        /// <param name="environmentID">环境ID</param>
        /// <returns>应用添加页面</returns>
        public async Task<ActionResult> Add(int? environmentID)
        {
            if (environmentID == null || environmentID.Value <= 0)
            {
                return View("~/Views/Shared/NotFind.cshtml");
            }
            var operateResult = await _environmentApplication.GetEnvironmentInfoAsync(environmentID.Value);
            if (operateResult.SuccessAndValueNotNull)
            {
                return View(ApplicationEditModel.Create(environmentID.Value, operateResult.Value.FName, operateResult.Value.FCode));
            }
            else
            {
                return View("~/Views/Shared/NotFind.cshtml");
            }
        }

        /// <summary>
        /// 添加应用信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JQJsonResult> Add(ApplicationEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return ResultUtil.Failed(ModelState.GetFirstErrorMsg());
            }
            var operateResult = await _applicationApplication.AddApplicationAsync(model, PublicUtil.GetCurrentAdminID());
            return operateResult.ToJsonResult();
        }

        #endregion 添加

        #region 编辑

        /// <summary>
        /// 编辑应用信息
        /// </summary>
        /// <param name="id">应用ID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || id.Value <= 0)
            {
                return View("~/Views/Shared/NotFind.cshtml");
            }
            var operateResult = await _applicationApplication.GetApplicationModelAsync(id.Value);
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
        /// 修改应用信息
        /// </summary>
        /// <param name="model">应用信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JQJsonResult> Edit(ApplicationEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return ResultUtil.Failed(ModelState.GetFirstErrorMsg());
            }
            var operateResult = await _applicationApplication.EditApplicationAsync(model, PublicUtil.GetCurrentAdminID());
            return operateResult.ToJsonResult();
        }

        #endregion 编辑

        /// <summary>
        /// 删除应用
        /// </summary>
        /// <param name="environmentID">应用ID</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JQJsonResult> Delete(int applicationID)
        {
            var operateResult = await _applicationApplication.DeleteApplicationAsync(applicationID, PublicUtil.GetCurrentAdminID());
            return operateResult.ToJsonResult();
        }
    }
}