using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：AdminDetailApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：管理员详细信息业务逻辑
	/// 创建标识：template 2017-07-31 11:57:45
	/// </summary>
	public sealed class AdminDetailApplication : IAdminDetailApplication
	{
		private readonly IAdminDetailRepository _adminDetailRepository;
		private readonly IAdminDetailDomainService _adminDetailDomainService;

		public AdminDetailApplication(IAdminDetailRepository adminDetailRepository, IAdminDetailDomainService adminDetailDomainService)
		{
			_adminDetailRepository= adminDetailRepository;
			_adminDetailDomainService =adminDetailDomainService; 
		}
	}
}
