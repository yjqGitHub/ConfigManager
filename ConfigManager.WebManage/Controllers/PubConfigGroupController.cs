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
    public class PubConfigGroupController : Controller
    {
        private readonly IPubConfigGroupApplication _pubConfigGroupApplication;
        private readonly IEnvironmentApplication _environmentApplication;

        public PubConfigGroupController(IEnvironmentApplication environmentApplication, IPubConfigGroupApplication pubConfigGroupApplication)
        {
            _pubConfigGroupApplication = pubConfigGroupApplication;
            _environmentApplication = environmentApplication;
        }

        /// <summary>
        /// 加载组列表
        /// </summary>
        /// <param name="queryWhereDto">查询条件</param>
        /// <returns></returns>
        public async Task<ActionResult> Index(ConfigGroupQueryWhereDto queryWhereDto)
        {
            var operateResult = await _pubConfigGroupApplication.LoadConfigGroupListAsync(queryWhereDto);
            ViewBag.QueryWhereDto = queryWhereDto;
            ViewBag.EnvironmentID = queryWhereDto?.EnvironmentID;
            return View(operateResult.Value);
        }

        #region 添加

        /// <summary>
        /// 公共配置组添加页面
        /// </summary>
        /// <param name="environmentID">环境ID</param>
        /// <returns>公共配置组添加页面</returns>
        public async Task<ActionResult> Add(int? environmentID)
        {
            if (environmentID == null || environmentID.Value <= 0)
            {
                return View("~/Views/Shared/NotFind.cshtml");
            }
            var operateResult = await _environmentApplication.GetEnvironmentInfoAsync(environmentID.Value);
            if (operateResult.SuccessAndValueNotNull)
            {
                return View(PubConfigGroupEditModel.Create(environmentID.Value, operateResult.Value.FName, operateResult.Value.FCode));
            }
            else
            {
                return View("~/Views/Shared/NotFind.cshtml");
            }
        }

        /// <summary>
        /// 添加配置组信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JQJsonResult> Add(PubConfigGroupEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return ResultUtil.Failed(ModelState.GetFirstErrorMsg());
            }
            var operateResult = await _pubConfigGroupApplication.AddConfigGroupAsync(model, PublicUtil.GetCurrentAdminID());
            return operateResult.ToJsonResult();
        }

        #endregion 添加

        #region 编辑

        /// <summary>
        /// 编辑配置组信息
        /// </summary>
        /// <param name="id">配置组ID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || id.Value <= 0)
            {
                return View("~/Views/Shared/NotFind.cshtml");
            }
            var operateResult = await _pubConfigGroupApplication.GetConfigGroupEditModelAsync(id.Value);
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
        /// 修改配置组信息
        /// </summary>
        /// <param name="model">配置组信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JQJsonResult> Edit(PubConfigGroupEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return ResultUtil.Failed(ModelState.GetFirstErrorMsg());
            }
            var operateResult = await _pubConfigGroupApplication.EditConfigGroupAsync(model, PublicUtil.GetCurrentAdminID());
            return operateResult.ToJsonResult();
        }

        #endregion 编辑
    }
}