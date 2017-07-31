using ConfigManager.Constant.Constants;
using ConfigManager.Domain;
using ConfigManager.Repository.Constants;
using JQ.DataAccess;
using JQ.DataAccess.Repositories;

namespace ConfigManager.Repository.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AdminOperateLogRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员操作记录数据访问类
    /// 创建标识：template 2017-07-31 11:57:45
    /// </summary>
    public sealed class AdminOperateLogRepository : BaseDataRepository<AdminOperateLogInfo>, IAdminOperateLogRepository
    {
        public AdminOperateLogRepository(IDataAccessFactory dataAccessFactory) : base(dataAccessFactory, RepositoryConstant.TABLE_NAME_ADMINOPERATELOG, ConfigurationConstant.CONNECTION_NAME_CONFIGMANAGER)
        {
        }
    }
}