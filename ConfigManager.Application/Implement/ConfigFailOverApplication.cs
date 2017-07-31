﻿using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ConfigFailOverApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：配置故障转移信息业务逻辑
	/// 创建标识：template 2017-07-30 22:11:53
	/// </summary>
	public sealed class ConfigFailOverApplication : IConfigFailOverApplication
	{
		private readonly IConfigFailOverRepository _configFailOverRepository;
		private readonly IConfigFailOverDomainService _configFailOverDomainService;

		public ConfigFailOverApplication(IConfigFailOverRepository configFailOverRepository, IConfigFailOverDomainService configFailOverDomainService)
		{
			_configFailOverRepository= configFailOverRepository;
			_configFailOverDomainService =configFailOverDomainService; 
		}
	}
}
