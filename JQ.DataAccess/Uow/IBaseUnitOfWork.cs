﻿namespace JQ.DataAccess.Uow
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IBaseUnitOfWork.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：基础工作单元接口
    /// 创建标识：yjq 2017/7/14 14:33:43
    /// </summary>
    public interface IBaseUnitOfWork
    {
        /// <summary>
        /// 开始
        /// </summary>
        void Begin();

        /// <summary>
        /// 提交
        /// </summary>
        void Commit(bool isAutoRollback = false);

        /// <summary>
        /// 回滚
        /// </summary>
        void Rollback();
    }
}