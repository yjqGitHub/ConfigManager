using JQ.DataAccess.DbClient;
using System;

namespace JQ.DataAccess
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IDataAccessFactory.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IDataAccessFactory接口
    /// 创建标识：yjq 2017/7/13 15:56:04
    /// </summary>
    public interface IDataAccessFactory : IDisposable
    {
        /// <summary>
        /// 获取一个数据操作类
        /// </summary>
        /// <param name="name">配置文件名字</param>
        /// <param name="isWriter">是否为写连接，不是则为读连接，默认为写连接</param>
        /// <returns>数据操作</returns>
        IDataAccess GetDataAccess(string configName, bool isWriter = true);
    }
}