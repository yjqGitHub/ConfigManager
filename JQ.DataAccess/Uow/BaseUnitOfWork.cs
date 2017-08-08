using JQ.DataAccess.DbClient;
using JQ.Utils;
using System;

namespace JQ.DataAccess.Uow
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：BaseUnitOfWork.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/14 14:43:27
    /// </summary>
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        private readonly IDataAccessFactory _dataAccessFactory;
        private readonly string _configName;
        private IDataAccess _dataAccess;

        public BaseUnitOfWork(IDataAccessFactory dataAccessFactory, string configName)
        {
            EnsureUtil.NotNullOrEmpty(configName, "configName");
            _dataAccessFactory = dataAccessFactory;
            _configName = configName;
        }

        /// <summary>
        /// 数据库访问接口
        /// </summary>
        protected IDataAccess DataAccess
        {
            get
            {
                return _dataAccess ?? (_dataAccess = _dataAccessFactory.GetDataAccess(_configName));
            }
        }

        /// <summary>
        /// 开始
        /// </summary>
        public virtual void Begin()
        {
            DataAccess.BeginTran();
        }

        /// <summary>
        /// 提交
        /// </summary>
        public virtual void Commit(bool isAutoRollback = false)
        {
            try
            {
                DataAccess.CommitTran();
            }
            catch (Exception ex)
            {
                if (isAutoRollback)
                {
                    Rollback();
                    LogUtil.Error(ex, memberName: "BaseUnitOfWork-Commit");
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 回滚
        /// </summary>
        public virtual void Rollback()
        {
            DataAccess.RollbackTran();
        }

        /// <summary>
        /// 执行事务,失败时自动回滚,有异常时回滚后抛出
        /// </summary>
        /// <param name="action"></param>
        public virtual bool ExecuteTran(Func<bool> action)
        {
            try
            {
                Begin();
                var isSuccess = action();
                if (isSuccess)
                {
                    Commit();
                }
                else
                {
                    Rollback();
                }
                return isSuccess;
            }
            catch
            {
                Rollback();
                throw;
            }
        }

        /// <summary>
        /// 执行事务，有异常时回滚后抛出
        /// </summary>
        /// <param name="action"></param>
        public virtual void ExecuteTran(Action action)
        {
            try
            {
                Begin();
                action();
                Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
        }
    }
}