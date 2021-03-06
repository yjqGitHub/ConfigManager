﻿using JQ.DataAccess.Repositories;
using ConfigManager.Domain;

namespace ConfigManager.Repository
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：IApplicationConfigInstanceRepository.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：当前应用配置信息数据访问接口
	/// 创建标识：template 2017-07-30 22:11:50
	/// </summary>
	public interface IApplicationConfigInstanceRepository : IBaseDataRepository<ApplicationConfigInstanceInfo>
	{
	}
}
