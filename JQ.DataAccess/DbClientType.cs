namespace JQ.DataAccess
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：DbClientType.cs
    /// 类属性：内部类（非静态）
    /// 类功能描述：数据库连接类型
    /// 创建标识：yjq 2017/7/12 19:25:04
    /// </summary>
    internal static class DbClientType
    {
        /// <summary>
        /// sqlservcer的连接类型
        /// </summary>
        public const string DB_CLINET_MSSQL = "System.Data.SqlClient";

        /// <summary>
        /// Oracle的连接类型
        /// </summary>
        public const string DB_CLINET_ORACLE = "System.Data.OracleClien";

        /// <summary>
        /// MySql的连接类型
        /// </summary>
        public const string DB_CLINET_MYSQL = "MySql.Data.MySqlClient";
    }
}