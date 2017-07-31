using System;
using System.Configuration;

namespace JQ.DataAccess
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：DBSettings.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：设置数据库属性信息
    /// 创建标识：yjq 2017/7/12 21:31:24
    /// </summary>
    internal static class DBSettings
    {
        /// <summary>
        /// 根据配置名字获取数据库属性信息
        /// </summary>
        /// <param name="name">配置名字</param>
        /// <returns>数据库属性信息</returns>
        public static DatabaseProperty GetDatabaseProperty(string name)
        {
            DatabaseConnection reader = GetDbConnection(name + ".Reader");
            DatabaseConnection writer = GetDbConnection(name + ".Writer");
            return new DatabaseProperty(reader, writer);
        }

        /// <summary>
        /// 根据配置名字获取连接信息
        /// </summary>
        /// <param name="connectionSettingName">配置名字</param>
        /// <returns>连接信息</returns>
        private static DatabaseConnection GetDbConnection(string connectionSettingName)
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionSettingName];
            DatabaseConnection dbConnection = default(DatabaseConnection);
            dbConnection.DatabaseType = DatabaseType.MSSQLServer;
            if (connectionStringSettings == null)
            {
                dbConnection.ConnectionString = string.Empty;
            }
            else
            {
                dbConnection.ConnectionString = connectionStringSettings.ConnectionString;
                dbConnection.DatabaseType = GetDbType(connectionStringSettings.ProviderName);
            }
            return dbConnection;
        }

        /// <summary>
        /// 根据提供程序名称属性获取对应数据库类型
        /// </summary>
        /// <param name="providerName">提供程序名称属性</param>
        /// <returns>数据库类型</returns>
        private static DatabaseType GetDbType(string providerName)
        {
            DatabaseType dataType = default(DatabaseType);
            switch (providerName)
            {
                case DbClientType.DB_CLINET_MSSQL:
                    dataType = DatabaseType.MSSQLServer;
                    break;

                case DbClientType.DB_CLINET_MYSQL:
                    dataType = DatabaseType.MySql;
                    break;

                case DbClientType.DB_CLINET_ORACLE:
                    dataType = DatabaseType.Oracle;
                    break;

                default:
                    throw new ArgumentNullException(providerName, "未找到该数据库类型.");
            }
            return dataType;
        }
    }
}