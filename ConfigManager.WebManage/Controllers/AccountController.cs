using ConfigManager.Application;
using ConfigManager.TransDto.TransModel;
using ConfigManager.WebManage.Infrastructure;
using JQ.Utils;
using JQ.Web;
using JQ.Web.Result;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConfigManager.WebManage.Controllers
{
    [NoNeedLogin]
    public class AccountController : Controller
    {
        private readonly IAdminApplication _adminApplication;

        public AccountController(IAdminApplication adminApplication)
        {
            _adminApplication = adminApplication;
        }

        /// <summary>
        /// 验证码的CookieKey
        /// </summary>
        private const string _VALIDATECODE_COOKIE_KEY = "ValidateCode";

        /// <summary>
        /// 验证码的加密盐值
        /// </summary>
        private const string _VALIDATECODE_SALT = "7758258";

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="model">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JQJsonResult> Login(LoginModel model)
        {
            if (!WebTool.CheckCode(model.Code, _VALIDATECODE_COOKIE_KEY, _VALIDATECODE_SALT))
            {
                return ResultUtil.Failed("请输入正确的验证码");
            }
            var operateResult = await _adminApplication.LoginAsync(model);
            if (operateResult.SuccessAndValueNotNull)
            {
                PublicUtil.SetCurrentAdmin(operateResult.Value.FID);
            }
            return operateResult.ToJsonResult();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FileResult ValidateCode()
        {
            ValidateCodeUtil coder = new ValidateCodeUtil();
            var codeInfo = coder.CreateImage(4, ValidateCodeType.Number);
            WebTool.SetCode(codeInfo.Item1, _VALIDATECODE_COOKIE_KEY, _VALIDATECODE_SALT);
            return File(codeInfo.Item2, @"image/Png");
        }
    }
}