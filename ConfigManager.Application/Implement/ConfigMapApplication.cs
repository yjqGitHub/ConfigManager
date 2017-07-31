using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ConfigMapApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：环境、项目公共配置组与配置关系业务逻辑
	/// 创建标识：template 2017-07-30 22:11:55
	/// </summary>
	public sealed class ConfigMapApplication : IConfigMapApplication
	{
		private readonly IConfigMapRepository _configMapRepository;
		private readonly IConfigMapDomainService _configMapDomainService;

		public ConfigMapApplication(IConfigMapRepository configMapRepository, IConfigMapDomainService configMapDomainService)
		{
			_configMapRepository= configMapRepository;
			_configMapDomainService =configMapDomainService; 
		}
	}
}
