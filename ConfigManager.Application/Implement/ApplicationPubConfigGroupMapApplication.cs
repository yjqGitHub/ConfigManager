using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ApplicationPubConfigGroupMapApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：应用程序与公共配置关系业务逻辑
	/// 创建标识：template 2017-07-30 22:11:52
	/// </summary>
	public sealed class ApplicationPubConfigGroupMapApplication : IApplicationPubConfigGroupMapApplication
	{
		private readonly IApplicationPubConfigGroupMapRepository _applicationPubConfigGroupMapRepository;
		private readonly IApplicationPubConfigGroupMapDomainService _applicationPubConfigGroupMapDomainService;

		public ApplicationPubConfigGroupMapApplication(IApplicationPubConfigGroupMapRepository applicationPubConfigGroupMapRepository, IApplicationPubConfigGroupMapDomainService applicationPubConfigGroupMapDomainService)
		{
			_applicationPubConfigGroupMapRepository= applicationPubConfigGroupMapRepository;
			_applicationPubConfigGroupMapDomainService =applicationPubConfigGroupMapDomainService; 
		}
	}
}
