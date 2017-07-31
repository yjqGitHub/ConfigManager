using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：PubConfigGroupApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：公共配置组信息业务逻辑
	/// 创建标识：template 2017-07-30 22:11:57
	/// </summary>
	public sealed class PubConfigGroupApplication : IPubConfigGroupApplication
	{
		private readonly IPubConfigGroupRepository _pubConfigGroupRepository;
		private readonly IPubConfigGroupDomainService _pubConfigGroupDomainService;

		public PubConfigGroupApplication(IPubConfigGroupRepository pubConfigGroupRepository, IPubConfigGroupDomainService pubConfigGroupDomainService)
		{
			_pubConfigGroupRepository= pubConfigGroupRepository;
			_pubConfigGroupDomainService =pubConfigGroupDomainService; 
		}
	}
}
