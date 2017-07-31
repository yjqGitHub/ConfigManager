﻿using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：EnvironmentApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：环境信息业务逻辑
	/// 创建标识：template 2017-07-30 22:11:56
	/// </summary>
	public sealed class EnvironmentApplication : IEnvironmentApplication
	{
		private readonly IEnvironmentRepository _environmentRepository;
		private readonly IEnvironmentDomainService _environmentDomainService;

		public EnvironmentApplication(IEnvironmentRepository environmentRepository, IEnvironmentDomainService environmentDomainService)
		{
			_environmentRepository= environmentRepository;
			_environmentDomainService =environmentDomainService; 
		}
	}
}