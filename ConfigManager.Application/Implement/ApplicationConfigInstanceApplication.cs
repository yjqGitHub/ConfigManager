using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ApplicationConfigInstanceApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：当前应用配置信息业务逻辑
	/// 创建标识：template 2017-07-30 22:11:51
	/// </summary>
	public sealed class ApplicationConfigInstanceApplication : IApplicationConfigInstanceApplication
	{
		private readonly IApplicationConfigInstanceRepository _applicationConfigInstanceRepository;
		private readonly IApplicationConfigInstanceDomainService _applicationConfigInstanceDomainService;

		public ApplicationConfigInstanceApplication(IApplicationConfigInstanceRepository applicationConfigInstanceRepository, IApplicationConfigInstanceDomainService applicationConfigInstanceDomainService)
		{
			_applicationConfigInstanceRepository= applicationConfigInstanceRepository;
			_applicationConfigInstanceDomainService =applicationConfigInstanceDomainService; 
		}
	}
}
