using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ConfigOperateLogApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：配置操作记录业务逻辑
	/// 创建标识：template 2017-07-30 22:11:56
	/// </summary>
	public sealed class ConfigOperateLogApplication : IConfigOperateLogApplication
	{
		private readonly IConfigOperateLogRepository _configOperateLogRepository;
		private readonly IConfigOperateLogDomainService _configOperateLogDomainService;

		public ConfigOperateLogApplication(IConfigOperateLogRepository configOperateLogRepository, IConfigOperateLogDomainService configOperateLogDomainService)
		{
			_configOperateLogRepository= configOperateLogRepository;
			_configOperateLogDomainService =configOperateLogDomainService; 
		}
	}
}
