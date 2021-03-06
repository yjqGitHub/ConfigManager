﻿using JQ.DataAccess;
using JQ.DataAccess.Repositories;
using ConfigManager.Domain;
using ConfigManager.Constant.Constants;
using ConfigManager.Repository.Constants;

namespace ConfigManager.Repository.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：AdminDetailRepository.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：管理员详细信息数据访问类
	/// 创建标识：template 2017-07-31 11:57:45
	/// </summary>
	public sealed class AdminDetailRepository : BaseDataRepository<AdminDetailInfo>, IAdminDetailRepository
	{
		public AdminDetailRepository(IDataAccessFactory dataAccessFactory): base(dataAccessFactory,RepositoryConstant.TABLE_NAME_ADMINDETAIL, ConfigurationConstant.CONNECTION_NAME_CONFIGMANAGER)
		{
		}
	}
}
