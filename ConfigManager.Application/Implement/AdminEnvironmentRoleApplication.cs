using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：AdminEnviromentRoleApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：管理员对应环境权限信息业务逻辑
	/// 创建标识：template 2017-07-30 22:11:50
	/// </summary>
	public sealed class AdminEnvironmentRoleApplication : IAdminEnvironmentRoleApplication
	{
		private readonly IAdminEnvironmentRoleRepository _adminEnviromentRoleRepository;
		private readonly IAdminEnvironmentRoleDomainService _adminEnviromentRoleDomainService;

		public AdminEnvironmentRoleApplication(IAdminEnvironmentRoleRepository adminEnviromentRoleRepository, IAdminEnvironmentRoleDomainService adminEnviromentRoleDomainService)
		{
			_adminEnviromentRoleRepository= adminEnviromentRoleRepository;
			_adminEnviromentRoleDomainService =adminEnviromentRoleDomainService; 
		}
	}
}
