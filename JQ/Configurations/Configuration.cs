using System;
using System.Collections.Generic;
using JQ.Extensions;

namespace JQ.Configurations
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：Configuration.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：项目配置
    /// 创建标识：yjq 2017/7/15 15:19:02
    /// </summary>
    public class Configuration
    {
        public static Configuration Instant { get; }

        private Stack<Action> _unstallActionList = new Stack<Action>();
        #region .ctor

        private Configuration()
        {
        }

        static Configuration()
        {
            Instant = new Configuration();
        }
        #endregion

        /// <summary>
        /// 解析IP的文件地址
        /// </summary>
        public string IpDataPath { get; set; }



        /// <summary>
        /// 添加程序停止时要执行的方法
        /// </summary>
        /// <param name="action">执行的方法</param>
        public Configuration AddUnInStallAction(Action action)
        {
            _unstallActionList.Push(action);
            return this;
        }

        /// <summary>
        /// 停止时执行
        /// </summary>
        public void Unstall()
        {
            while (_unstallActionList.Count > 0)
            {
                var action = _unstallActionList.Pop();
                action?.Invoke();
            }
        }

        /// <summary>
        /// 程序启动时执行的方法
        /// <param name="ipDataPath">解析IP的文件地址</param>
        /// </summary>
        public static void Install(string ipDataPath = null)
        {
            if (ipDataPath.IsNotNullAndNotEmptyWhiteSpace())
            {
                Instant.IpDataPath = ipDataPath;
            }
        }

        /// <summary>
        /// 程序停止时执行的方法
        /// </summary>
        public static void UnInstall()
        {
            Instant?.Unstall();
        }
    }
}