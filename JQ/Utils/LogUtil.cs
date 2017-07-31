using JQ.Extensions;
using JQ.Logger;
using JQ.Logger.NLogger;
using NetMonitor.Client;
using System;

namespace JQ.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：LogUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：日志记录帮助类
    /// 创建标识：yjq 2017/7/12 17:30:11
    /// </summary>
    public static class LogUtil
    {
        #region ILogger

        /// <summary>
        /// 获取创建ILogger工厂
        /// </summary>
        /// <returns>ILogger工厂</returns>
        private static ILoggerFactory GetLoggerFactory()
        {
            return new NLoggerFactory();
        }

        /// <summary>
        /// 获取ILogger
        /// </summary>
        /// <param name="loggerName">记录器名字</param>
        /// <returns>ILogger</returns>
        private static ILogger GetLogger(string loggerName = null)
        {
            if (string.IsNullOrWhiteSpace(loggerName))
            {
                loggerName = "JQ";
            }
            return GetLoggerFactory().Create(loggerName);
        }

        #endregion ILogger

        /// <summary>
        /// 输出调试日志信息
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Debug(string msg, string loggerName = null)
        {
            GetLogger(loggerName: loggerName).Debug(msg);
            MonitorManage.GetLogger().Debug(msg, loggerName: loggerName);
        }

        /// <summary>
        /// 输出普通日志信息
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Info(string msg, string loggerName = null)
        {
            GetLogger(loggerName: loggerName).Info(msg);
            MonitorManage.GetLogger().Info(msg, loggerName: loggerName);
        }

        /// <summary>
        /// 输出警告日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="loggerName"></param>
        public static void Warn(string msg, string loggerName = null)
        {
            GetLogger(loggerName: loggerName).Warn(msg);
            MonitorManage.GetLogger().Warn(msg, loggerName: loggerName);
        }

        /// <summary>
        /// 输出警告日志信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="memberName"></param>
        /// <param name="loggerName"></param>
        public static void Warn(Exception ex, string memberName = null, string loggerName = null)
        {
            GetLogger(loggerName: loggerName).Warn(ex.ToErrMsg(memberName: memberName));
            MonitorManage.GetLogger().Warn(ex, memberName: memberName, loggerName: loggerName);
        }

        /// <summary>
        /// 输出错误日志信息
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Error(string msg, string loggerName = null)
        {
            GetLogger(loggerName: loggerName).Error(msg);
            MonitorManage.GetLogger().Error(msg, loggerName: loggerName);
        }

        /// <summary>
        /// 输出错误日志信息
        /// </summary>
        /// <param name="ex">异常信息</param>
        public static void Error(Exception ex, string memberName = null, string loggerName = null)
        {
            GetLogger(loggerName: loggerName).Error(ex.ToErrMsg(memberName: memberName));
            MonitorManage.GetLogger().Error(ex, memberName: memberName, loggerName: loggerName);
        }

        /// <summary>
        /// 输出严重错误日志信息
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Fatal(string msg, string loggerName = null)
        {
            GetLogger(loggerName: loggerName).Fatal(msg);
            MonitorManage.GetLogger().Fatal(msg, loggerName: loggerName);
        }

        /// <summary>
        /// 输出严重错误日志信息
        /// </summary>
        /// <param name="ex">异常信息</param>
        public static void Fatal(Exception ex, string memberName = null, string loggerName = null)
        {
            GetLogger(loggerName: loggerName).Fatal(ex.ToErrMsg(memberName: memberName));
            MonitorManage.GetLogger().Fatal(ex, memberName: memberName, loggerName: loggerName);
        }
    }
}