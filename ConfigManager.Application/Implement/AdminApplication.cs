using ConfigManager.Repository;
using ConfigManager.DomainService;
using System.Threading.Tasks;
using ConfigManager.TransDto.TransModel;
using JQ.Result.Operate;
using ConfigManager.TransDto.TransDto;
using JQ.Utils;
using ConfigManager.Constant.EnumCollection;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：AdminApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：管理员信息业务逻辑
	/// 创建标识：template 2017-07-30 22:11:49
	/// </summary>
	public sealed class AdminApplication : IAdminApplication
	{
		private readonly IAdminRepository _adminRepository;
		private readonly IAdminDomainService _adminDomainService;

		public AdminApplication(IAdminRepository adminRepository, IAdminDomainService adminDomainService)
		{
			_adminRepository= adminRepository;
			_adminDomainService =adminDomainService; 
		}

        /// <summary>
        /// 异步登录
        /// </summary>
        /// <param name="model">登录用户信息</param>
        /// <returns>操作结果</returns>
        public async Task<OperateResult<AdminDto>> LoginAsync(LoginModel model)
        {
            EnsureUtil.NotNull(model, "登录信息");
            var adminInfo = await _adminDomainService.LoginAsync(model.UserName, model.Pwd, WebSitePort.WebManage);
            return OperateUtil.Success(adminInfo);
        }

    }
}
