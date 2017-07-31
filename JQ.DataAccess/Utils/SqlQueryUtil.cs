using JQ.DataAccess.DbClient;
using JQ.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JQ.DataAccess.Utils
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：SqlQueryUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/13 16:40:16
    /// </summary>
    public static class SqlQueryUtil
    {
        /// <summary>
        /// 拼接单个插入的SqlQuery
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">实体值</param>
        /// <param name="tableName">表名</param>
        /// <param name="ignoreFields">需要忽略的字段</param>
        /// <param name="isIdentity">是否自增</param>
        /// <param name="dbType">数据库类型，默认MSSQLServer</param>
        /// <returns>单个插入的SqlQuery</returns>
        public static SqlQuery BuilderInsertOneSqlQuery<T>(T entity, string tableName, string[] ignoreFields = null, bool isIdentity = true, DatabaseType dbType = DatabaseType.MSSQLServer) where T : new()
        {
            var propertyList = PropertyUtil.GetPropertyInfos(entity, ignoreFields);
            var proNameList = propertyList.Select(m => m.Name);
            var columns = string.Join(",", proNameList);
            var values = string.Join(",", proNameList.Select(p => GetSign(dbType) + p));
            string commandText = string.Format("INSERT INTO {0} ({1}) VALUES ({2}){3};", tableName, columns, values, isIdentity ? " SELECT scope_identity()" : string.Empty);
            return new SqlQuery(commandText, entity);
        }

        /// <summary>
        /// 拼接批量插入的SqlQuery
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <exception cref="ArgumentNullException">entityList</exception>
        /// <param name="entityList">实体列表，不能为Null或者为空列表</param>
        /// <param name="tableName">表名</param>
        /// <param name="ignoreFields">需要忽略的字段</param>
        /// <param name="isIdentity">是否自增</param>
        /// <param name="dbType">数据库类型，默认MSSQLServer</param>
        /// <returns>批量插入的SqlQuery</returns>
        public static SqlQuery BuilderInsertManySqlQuery<T>(List<T> entityList, string tableName, string[] ignoreFields = null, bool isIdentity = true, DatabaseType dbType = DatabaseType.MSSQLServer) where T : new()
        {
            EnsureUtil.NotNull(entityList, "entityList");
            var entity = entityList.FirstOrDefault();
            if (entity == null)
            {
                throw new ArgumentNullException("entityList");
            }
            var propertyList = PropertyUtil.GetPropertyInfos(entity, ignoreFields);
            var proNameList = propertyList.Select(m => m.Name);
            var columns = string.Join(",", proNameList);
            StringBuilder builder = new StringBuilder();
            SqlQuery sqlQuery = new SqlQuery();
            for (int i = 0; i < entityList.Count; i++)
            {
                var values = string.Join(",", proNameList.Select(p => GetSign(dbType) + i.ToString() + p));
                builder.AppendFormat("INSERT INTO {0} ({1}) VALUES ({2}){3};", tableName, columns, values, isIdentity ? " SELECT scope_identity()" : string.Empty);
                sqlQuery.AddObjectParam(entityList[i], i.ToString());
            }
            sqlQuery.CommandText = builder.ToString();
            return sqlQuery;
        }

        /// <summary>
        /// 拼接修改的SqlQuery
        /// </summary>
        /// <param name="data">要修改的内容</param>
        /// <param name="condition">修改的条件</param>
        /// <param name="tableName">表名</param>
        /// <param name="ignoreFields">需要忽略的字段</param>
        /// <param name="dbType">数据库类型，默认MSSQLServer</param>
        /// <returns>修改的SqlQuery</returns>
        public static SqlQuery BuilderUpdateSqlQuery(object data, object condition, string tableName, string[] ignoreFields = null, DatabaseType dbType = DatabaseType.MSSQLServer)
        {
            var updatePropertyInfos = PropertyUtil.GetPropertyInfos(data, ignoreFields);
            var wherePropertyInfos = PropertyUtil.GetPropertyInfos(condition);

            var updateProperties = updatePropertyInfos.Select(p => p.Name);
            var whereProperties = wherePropertyInfos.Select(p => p.Name);

            var updateFields = string.Join(",", updateProperties.Select(p => p + " =" + GetSign(dbType) + p));
            var whereFields = string.Empty;

            if (whereProperties.Any())
            {
                whereFields = " WHERE " + string.Join(" AND ", whereProperties.Select(p => p + " =" + GetSign(dbType) + "W_" + p));
            }
            SqlQuery sqlQuery = new SqlQuery()
                                .AddObjectParam(data)
                                .AddObjectParam(condition, "W_")
                                .ChangeCommandText(string.Format("UPDATE {0} SET {1}{2}", tableName, updateFields, whereFields));
            return sqlQuery;
        }

        /// <summary>
        /// 拼接删除的SqlQuery
        /// </summary>
        /// <param name="condition">删除的条件</param>
        /// <param name="tableName">表名</param>
        /// <param name="dbType">数据库类型，默认MSSQLServer</param>
        /// <returns>删除的SqlQuery</returns>
        public static SqlQuery BuilderDeleteSqlQuery(object condition, string tableName, DatabaseType dbType = DatabaseType.MSSQLServer)
        {
            var whereFields = string.Empty;
            var whereProperties = PropertyUtil.GetPropertyInfos(condition);
            var whereFieldNames = whereProperties.Select(p => p.Name);
            if (whereFieldNames.Any())
            {
                whereFields = " WHERE " + string.Join(" AND ", whereFieldNames.Select(p => p + " = " + GetSign(dbType) + p));
            }
            var sql = string.Format("DELETE FROM {0}{1};", tableName, whereFields);
            return new SqlQuery(sql, condition);
        }

        /// <summary>
        /// 拼接查询的SqlQuery
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="tableName">表名</param>
        /// <param name="dbType">数据库类型，默认MSSQLServer</param>
        /// <returns>查询的SqlQuery</returns>
        public static SqlQuery BuilderQuerySqlQuery(object condition, string tableName, DatabaseType dbType = DatabaseType.MSSQLServer)
        {
            SqlQuery sqlQuery = new SqlQuery();
            var whereFields = string.Empty;
            var whereProperties = PropertyUtil.GetPropertyInfos(condition);
            var whereFieldNames = whereProperties.Select(p => p.Name);
            if (whereFieldNames.Any())
            {
                whereFields = " WHERE " + string.Join(" AND ", whereFieldNames.Select(p => p + " = " + GetSign(dbType) + p));
            }
            var sql = string.Format("SELECT * FROM {0}{1};", tableName, whereFields);
            return new SqlQuery(sql, condition);
        }

        /// <summary>
        /// 拼接查询的SqlQuery
        /// </summary>
        /// <typeparam name="TModel">查询字段的类型</typeparam>
        /// <param name="condition">查询条件</param>
        /// <param name="tableName">表名</param>
        /// <param name="ignoreFields">需要忽略的字段</param>
        /// <param name="dbType">数据库类型，默认MSSQLServer</param>
        /// <returns>查询的SqlQuery</returns>
        public static SqlQuery BuilderQuerySqlQuery<TModel>(object condition, string tableName, string[] ignoreFields = null, DatabaseType dbType = DatabaseType.MSSQLServer)
        {
            SqlQuery sqlQuery = new SqlQuery();
            var whereFields = string.Empty;
            var selectProperties = PropertyUtil.GetTypeProperties(typeof(TModel), ignoreFields);
            var whereProperties = PropertyUtil.GetPropertyInfos(condition);
            var whereFieldNames = whereProperties.Select(p => p.Name);
            if (whereFieldNames.Any())
            {
                whereFields = " WHERE " + string.Join(" AND ", whereFieldNames.Select(p => p + " = " + GetSign(dbType) + p));
            }
            var sql = string.Format("SELECT {0} FROM {1}{2};", string.Join(",", selectProperties.Select(m => m.Name)), tableName, whereFields);
            return new SqlQuery(sql, condition);
        }

        /// <summary>
        /// 拼接查询数量的SqlQuery
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="tableName">表名</param>
        /// <param name="dbType">数据库类型，默认MSSQLServer</param>
        /// <returns>查询数量的SqlQuery</returns>
        public static SqlQuery BuilderQueryCountSqlQuery(object condition, string tableName, DatabaseType dbType = DatabaseType.MSSQLServer)
        {
            var whereFields = string.Empty;
            var whereProperties = PropertyUtil.GetPropertyInfos(condition);
            var whereFieldNames = whereProperties.Select(p => p.Name);
            if (whereFieldNames.Any())
            {
                whereFields = " WHERE " + string.Join(" AND ", whereFieldNames.Select(p => p + " = " + GetSign(dbType) + p));
            }
            var sql = string.Format("SELECT COUNT(0) FROM {0}{1};", tableName, whereFields);
            return new SqlQuery(sql, condition);
        }

        /// <summary>
        /// 获取参数符号
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns>参数符号</returns>
        public static string GetSign(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.MSSQLServer:
                    return "@";

                case DatabaseType.MySql:
                    return "?";

                case DatabaseType.Oracle:
                    return ":";

                default:
                    throw new NotSupportedException(dbType.ToString());
            }
        }
    }
}