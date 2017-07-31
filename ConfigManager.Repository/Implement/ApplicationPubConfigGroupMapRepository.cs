using JQ.DataAccess;
using JQ.DataAccess.Repositories;
using ConfigManager.Domain;
using ConfigManager.Constant.Constants;
using ConfigManager.Repository.Constants;

namespace ConfigManager.Repository.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ApplicationPubConfigGroupMapRepository.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：应用程序与公共配置关系数据访问类
	/// 创建标识：template 2017-07-30 22:11:52
	/// </summary>
	public sealed class ApplicationPubConfigGroupMapRepository : BaseDataRepository<ApplicationPubConfigGroupMapInfo>, IApplicationPubConfigGroupMapRepository
	{
		public ApplicationPubConfigGroupMapRepository(IDataAccessFactory dataAccessFactory): base(dataAccessFactory,RepositoryConstant.TABLE_NAME_APPLICATIONPUBCONFIGGROUPMAP, ConfigurationConstant.CONNECTION_NAME_CONFIGMANAGER)
		{
		}
	}
}
