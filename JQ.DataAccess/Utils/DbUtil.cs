namespace JQ.DataAccess.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：DbUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/8/9 10:00:51
    /// </summary>
    public static class DbUtil
    {
        /// <summary>
        /// 获取不能为空的函数方法
        /// </summary>
        /// <param name="checkColumn">需要校验的字段</param>
        /// <param name="replaceColumn">替换的字段</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns>不能为空的函数方法</returns>
        public static string IsNull(this string checkColumn, string replaceColumn, DatabaseType dbType = DatabaseType.MSSQLServer)
        {
            string notNullFunctionCode = string.Empty;
            switch (dbType)
            {
                case DatabaseType.MSSQLServer:
                    notNullFunctionCode = $"ISNULL({checkColumn},{replaceColumn})";
                    break;

                case DatabaseType.MySql:
                    notNullFunctionCode = $"IFNULL({checkColumn},{replaceColumn})";
                    break;

                case DatabaseType.Oracle:
                    notNullFunctionCode = $"nvl({checkColumn},{replaceColumn})";
                    break;

                default:
                    notNullFunctionCode = $"ISNULL({checkColumn},{replaceColumn})";
                    break;
            }
            return notNullFunctionCode;
        }

        /// <summary>
        /// 对表添加withNolock（只有MSSQLServer支持）
        /// </summary>
        /// <param name="tableName">表明</param>
        /// <param name="tableAlias">表别名</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns>表添加withNolock（只有MSSQLServer支持）</returns>
        public static string WithNolock(this string tableName, string tableAlias = null, DatabaseType dbType = DatabaseType.MSSQLServer)
        {
            string withNolockCode = string.Empty;
            string tableNameWithAlias = tableName + (string.IsNullOrWhiteSpace(tableAlias) ? string.Empty : " AS " + tableAlias);
            switch (dbType)
            {
                case DatabaseType.MSSQLServer:
                    withNolockCode = $"{tableNameWithAlias} WITH(NOLOCK)";
                    break;

                default:
                    withNolockCode = tableNameWithAlias;
                    break;
            }
            return withNolockCode;
        }

        /// <summary>
        /// 左连接
        /// </summary>
        /// <param name="tableName">左边表</param>
        /// <param name="targetTableName">被连接的表</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns>连接代码</returns>
        public static string LeftJoin(this string tableName, string targetTableName, DatabaseType dbType = DatabaseType.MSSQLServer)
        {
            string joinCode = string.Empty;
            switch (dbType)
            {
                default:
                    joinCode = $"{tableName} LEFT JOIN {targetTableName}";
                    break;
            }
            return joinCode;
        }

        /// <summary>
        /// 右连接
        /// </summary>
        /// <param name="tableName">左边表</param>
        /// <param name="targetTableName">被连接的表</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns>连接代码</returns>
        public static string RightJoin(this string tableName, string targetTableName, DatabaseType dbType = DatabaseType.MSSQLServer)
        {
            string joinCode = string.Empty;
            switch (dbType)
            {
                default:
                    joinCode = $"{tableName} RIGHT JOIN {targetTableName}";
                    break;
            }
            return joinCode;
        }

        /// <summary>
        /// 全连接
        /// </summary>
        /// <param name="tableName">左边表</param>
        /// <param name="targetTableName">被连接的表</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns>连接代码</returns>
        public static string InnerJoin(this string tableName, string targetTableName, DatabaseType dbType = DatabaseType.MSSQLServer)
        {
            string joinCode = string.Empty;
            switch (dbType)
            {
                default:
                    joinCode = $"{tableName} INNER JOIN {targetTableName}";
                    break;
            }
            return joinCode;
        }

        /// <summary>
        /// join条件
        /// </summary>
        /// <param name="joinTable"></param>
        /// <param name="onWhere">条件</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns>完整的join代码</returns>
        public static string JoinOn(this string joinTable, string onWhere, DatabaseType dbType = DatabaseType.MSSQLServer)
        {
            string joinOnCode = string.Empty;
            switch (dbType)
            {
                default:
                    joinOnCode = $"{joinTable} ON {onWhere} ";
                    break;
            }
            return joinOnCode;
        }
    }
}