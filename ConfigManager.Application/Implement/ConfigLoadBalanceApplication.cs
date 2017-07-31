using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ConfigLoadBalanceApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：配置负载均衡信息业务逻辑
	/// 创建标识：template 2017-07-30 22:11:54
	/// </summary>
	public sealed class ConfigLoadBalanceApplication : IConfigLoadBalanceApplication
	{
		private readonly IConfigLoadBalanceRepository _configLoadBalanceRepository;
		private readonly IConfigLoadBalanceDomainService _configLoadBalanceDomainService;

		public ConfigLoadBalanceApplication(IConfigLoadBalanceRepository configLoadBalanceRepository, IConfigLoadBalanceDomainService configLoadBalanceDomainService)
		{
			_configLoadBalanceRepository= configLoadBalanceRepository;
			_configLoadBalanceDomainService =configLoadBalanceDomainService; 
		}
	}
}
