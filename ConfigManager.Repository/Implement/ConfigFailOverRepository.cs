using JQ.DataAccess;
using JQ.DataAccess.Repositories;
using ConfigManager.Domain;
using ConfigManager.Constant.Constants;
using ConfigManager.Repository.Constants;

namespace ConfigManager.Repository.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ConfigFailOverRepository.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：配置故障转移信息数据访问类
	/// 创建标识：template 2017-07-30 22:11:53
	/// </summary>
	public sealed class ConfigFailOverRepository : BaseDataRepository<ConfigFailOverInfo>, IConfigFailOverRepository
	{
		public ConfigFailOverRepository(IDataAccessFactory dataAccessFactory): base(dataAccessFactory,RepositoryConstant.TABLE_NAME_CONFIGFAILOVER, ConfigurationConstant.CONNECTION_NAME_CONFIGMANAGER)
		{
		}
	}
}
