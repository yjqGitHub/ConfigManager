using JQ.DataAccess;
using JQ.DataAccess.Repositories;
using ConfigManager.Domain;
using ConfigManager.Constant.Constants;
using ConfigManager.Repository.Constants;

namespace ConfigManager.Repository.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ConfigMapRepository.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：环境、项目公共配置组与配置关系数据访问类
	/// 创建标识：template 2017-07-30 22:11:55
	/// </summary>
	public sealed class ConfigMapRepository : BaseDataRepository<ConfigMapInfo>, IConfigMapRepository
	{
		public ConfigMapRepository(IDataAccessFactory dataAccessFactory): base(dataAccessFactory,RepositoryConstant.TABLE_NAME_CONFIGMAP, ConfigurationConstant.CONNECTION_NAME_CONFIGMANAGER)
		{
		}
	}
}
