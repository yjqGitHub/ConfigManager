using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ConfigApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：配置值信息业务逻辑
	/// 创建标识：template 2017-07-30 22:11:53
	/// </summary>
	public sealed class ConfigApplication : IConfigApplication
	{
		private readonly IConfigRepository _configRepository;
		private readonly IConfigDomainService _configDomainService;

		public ConfigApplication(IConfigRepository configRepository, IConfigDomainService configDomainService)
		{
			_configRepository= configRepository;
			_configDomainService =configDomainService; 
		}
	}
}
