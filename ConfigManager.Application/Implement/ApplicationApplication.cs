using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ApplicationApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：应用程序信息业务逻辑
	/// 创建标识：template 2017-07-30 22:11:50
	/// </summary>
	public sealed class ApplicationApplication : IApplicationApplication
	{
		private readonly IApplicationRepository _applicationRepository;
		private readonly IApplicationDomainService _applicationDomainService;

		public ApplicationApplication(IApplicationRepository applicationRepository, IApplicationDomainService applicationDomainService)
		{
			_applicationRepository= applicationRepository;
			_applicationDomainService =applicationDomainService; 
		}
	}
}
