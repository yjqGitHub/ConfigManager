using JQ.DataAccess.DbClient;
using JQ.Utils;
using NetMonitor.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JQ.DataAccess.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：SqlMonitorUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：sql监控帮助类
    /// 创建标识：yjq 2017/7/14 19:07:47
    /// </summary>
    internal static class SqlMonitorUtil
    {
        #region 监控消耗时间

        /// <summary>
        /// sql的日志记录器名字
        /// </summary>
        private const string _LOGGER_SQL = "JQ.Sql";

        /// <summary>
        /// 监控消耗时间
        /// </summary>
        /// <param name="action">执行方法</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="memberName">调用方法</param>
        public static void Monitor(Action action, string dbType = null, string memberName = null)
        {
            MonitorManage.GetSqlMonitor().Monitor(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    LogUtil.Error($"执行的sql方法:{memberName}", _LOGGER_SQL);
                    LogUtil.Error(ex);
                    throw;
                }
            }, memberName, memberName, dataBaseType: dbType, parameterList: null);
        }

        /// <summary>
        /// 监控消耗时间
        /// </summary>
        /// <param name="query">SqlQuery</param>
        /// <param name="action">执行方法</param>
        /// <param name="dbType">数据库类型</param>
        public static void Monitor(SqlQuery query, Action action, string dbType = null)
        {
            MonitorManage.GetSqlMonitor().Monitor(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    LogUtil.Error($"执行的sql语句:{query.CommandText}", _LOGGER_SQL);
                    LogUtil.Error(ex);
                    throw;
                }
            }, query?.CommandText, query?.CommandType.ToString(), dataBaseType: dbType, parameterList: query.ToMonitorParameterList());
        }

        /// <summary>
        /// 监控消耗时间
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="action">执行方法</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="memberName">调用方法</param>
        /// <returns>返回值</returns>
        public static T Monitor<T>(Func<T> action, string dbType = null, string memberName = null)
        {
            return MonitorManage.GetSqlMonitor().Monitor(() =>
             {
                 try
                 {
                     return action();
                 }
                 catch (Exception ex)
                 {
                     LogUtil.Error($"执行的sql方法:{memberName}", _LOGGER_SQL);
                     LogUtil.Error(ex);
                     throw;
                 }
             }, memberName, memberName, dataBaseType: dbType, parameterList: null);
        }

        /// <summary>
        /// 监控消耗时间
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="query">SqlQuery</param>
        /// <param name="action">执行方法</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns>返回值</returns>
        public static T Monitor<T>(SqlQuery query, Func<T> action, string dbType = null)
        {
            return MonitorManage.GetSqlMonitor().Monitor(() =>
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    LogUtil.Error($"执行的sql语句:{query.CommandText}", _LOGGER_SQL);
                    LogUtil.Error(ex);
                    throw;
                }
            }, query?.CommandText, query?.CommandType.ToString(), dataBaseType: dbType, parameterList: query.ToMonitorParameterList());
        }

        /// <summary>
        /// 监控消耗时间
        /// </summary>
        /// <param name="action">异步方法</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="memberName">调用方法</param>
        /// <returns>任务</returns>
        public async static Task MonitorAsync(Func<Task> action, string dbType = null, string memberName = null)
        {
            await MonitorManage.GetSqlMonitor().MonitorAsync(async () =>
           {
               try
               {
                   await action();
               }
               catch (Exception ex)
               {
                   LogUtil.Error($"执行的sql方法:{memberName}", _LOGGER_SQL);
                   LogUtil.Error(ex);
                   throw;
               }
           }, memberName, memberName, dataBaseType: dbType, parameterList: null);
        }

        /// <summary>
        /// 监控消耗时间
        /// </summary>
        /// <param name="query">SqlQuery</param>
        /// <param name="action">异步方法</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns>任务</returns>
        public async static Task MonitorAsync(SqlQuery query, Func<Task> action, string dbType = null)
        {
            await MonitorManage.GetSqlMonitor().MonitorAsync(async () =>
            {
                try
                {
                    await action();
                }
                catch (Exception ex)
                {
                    LogUtil.Error($"执行的sql语句:{query.CommandText}", _LOGGER_SQL);
                    LogUtil.Error(ex);
                    throw;
                }
            }, query?.CommandText, query?.CommandType.ToString(), dataBaseType: dbType, parameterList: query.ToMonitorParameterList());
        }

        /// <summary>
        /// 监控消耗时间
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="action">异步方法</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="memberName">调用方法</param>
        /// <returns>返回值</returns>
        public async static Task<T> MonitorAsync<T>(Func<Task<T>> action, string dbType = null, string memberName = null)
        {
            return await MonitorManage.GetSqlMonitor().MonitorAsync(async () =>
            {
                try
                {
                    return await action();
                }
                catch (Exception ex)
                {
                    LogUtil.Error($"执行的sql方法:{memberName}", _LOGGER_SQL);
                    LogUtil.Error(ex);
                    throw;
                }
            }, memberName, memberName, dataBaseType: dbType, parameterList: null);
        }

        /// <summary>
        /// 监控消耗时间
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="query">SqlQuery</param>
        /// <param name="action">异步方法</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns>返回值</returns>
        public async static Task<T> MonitorAsync<T>(SqlQuery query, Func<Task<T>> action, string dbType = null)
        {
            return await MonitorManage.GetSqlMonitor().MonitorAsync(async () =>
            {
                try
                {
                    return await action();
                }
                catch (Exception ex)
                {
                    LogUtil.Error($"执行的sql语句:{query.CommandText}", _LOGGER_SQL);
                    LogUtil.Error(ex);
                    throw;
                }
            }, query?.CommandText, query?.CommandType.ToString(), dataBaseType: dbType, parameterList: query.ToMonitorParameterList());
        }

        #endregion 监控消耗时间

        /// <summary>
        /// 转为监控参数列表
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns>监控参数列表</returns>
        private static List<NetMonitor.Client.Sql.ParameterInfo> ToMonitorParameterList(this SqlQuery sqlQuery)
        {
            return sqlQuery?.ParameterList?.Select(m => new NetMonitor.Client.Sql.ParameterInfo()
            {
                DbType = m.DbType,
                ParameterDirection = m.ParameterDirection,
                ParameterName = m.ParameterName,
                Scale = m.Scale,
                Size = m.Size,
                Value = m.Value
            })?.ToList();
        }
    }
}