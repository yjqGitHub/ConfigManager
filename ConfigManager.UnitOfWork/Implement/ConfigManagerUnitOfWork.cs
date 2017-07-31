using ConfigManager.Constant.Constants;
using JQ.DataAccess;
using JQ.DataAccess.Uow;

namespace ConfigManager.UnitOfWork.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ConfigManagerUnitOfWork.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/30 21:42:51
    /// </summary>
    public sealed class ConfigManagerUnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        public ConfigManagerUnitOfWork(IDataAccessFactory dataAccessFactory) : base(dataAccessFactory, ConfigurationConstant.CONNECTION_NAME_CONFIGMANAGER)
        {
        }
    }
}