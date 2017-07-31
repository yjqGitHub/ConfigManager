using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：AdminOperateLogApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：管理员操作记录业务逻辑
	/// 创建标识：template 2017-07-31 11:57:46
	/// </summary>
	public sealed class AdminOperateLogApplication : IAdminOperateLogApplication
	{
		private readonly IAdminOperateLogRepository _adminOperateLogRepository;
		private readonly IAdminOperateLogDomainService _adminOperateLogDomainService;

		public AdminOperateLogApplication(IAdminOperateLogRepository adminOperateLogRepository, IAdminOperateLogDomainService adminOperateLogDomainService)
		{
			_adminOperateLogRepository= adminOperateLogRepository;
			_adminOperateLogDomainService =adminOperateLogDomainService; 
		}
	}
}
