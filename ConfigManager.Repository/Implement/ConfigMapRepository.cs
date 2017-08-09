using ConfigManager.Constant.Constants;
using ConfigManager.Domain;
using ConfigManager.TransDto.QueryWhereDto;
using ConfigManager.TransDto.TransDto;
using JQ.DataAccess;
using JQ.DataAccess.DbClient;
using JQ.DataAccess.Repositories;
using JQ.DataAccess.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ConfigManager.Repository.Constants.RepositoryConstant;

namespace ConfigManager.Repository.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ConfigMapRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：环境、项目公共配置组与配置关系数据访问类
    /// 创建标识：template 2017-07-30 22:11:55
    /// </summary>
    public sealed class ConfigMapRepository : BaseDataRepository<ConfigMapInfo>, IConfigMapRepository
    {
        public ConfigMapRepository(IDataAccessFactory dataAccessFactory) : base(dataAccessFactory, TABLE_NAME_CONFIGMAP, ConfigurationConstant.CONNECTION_NAME_CONFIGMANAGER)
        {
        }

        /// <summary>
        /// 异步根据所属类型加载配置列表
        /// </summary>
        /// <param name="queryWhere">查询条件</param>
        /// <returns>配置列表</returns>
        public Task<IEnumerable<ConfigMapDto>> LoadConfigList(ConfigMapQueryWhereDto queryWhere)
        {
            const string selectColumn = " A.FID,A.FBelongType,A.FEnvironmentID,A.FBelongID,A.FKey,A.FComment,ISNULL(A.FLastModifyTime,A.FCreateTime) AS FLastModifyTime,B.FID,B.FConfigMapID,B.FType,B.FVersion,B.FValue,B.FFailOverID,B.FLoadBalanceAlgorithmType,B.FComment,ISNULL(B.FLastModifyTime,B.FCreateTime) AS FLastModifyTime ";
            const string selectTable = " " + TABLE_NAME_CONFIGMAP + " AS A WITH(NOLOCK) LEFT JOIN " + TABLE_NAME_CONFIG + " B WITH(NOLOCK) ON B.FConfigMapID=A.FID AND B.FIsDeleted=0 ";
            SqlWhereBuilder whereBuilder = new SqlWhereBuilder(" A.FIsDeleted=0 ", dbType: DataType);
            if (queryWhere.BelongType.HasValue)
            {
                whereBuilder.AppendEqual("A.FBelongType", (int)queryWhere.BelongType.Value, nameof(queryWhere.BelongType))
                            .AppendEqual("A.FBelongID", queryWhere.BelongID, nameof(queryWhere.BelongID))
                            .AppendLike("A.FKey", queryWhere.KeyName, nameof(queryWhere.KeyName))
                            ;
                SqlQuery sqlQuery = SqlQueryUtil.BuilderQueryListSqlQuery(selectColumn, selectTable, whereBuilder.ToString(), "ISNULL(A.FLastModifyTime,A.FCreateTime) DESC", queryWhere);
                var lookup = new Dictionary<int, ConfigMapDto>();
                return GetDataAccess(isWrite: false).QueryAsync<ConfigMapDto, ConfigDto, ConfigMapDto>(sqlQuery, (configMap, config) =>
                {
                    ConfigMapDto configMapDto;
                    if (lookup.TryGetValue(configMap.FID, out configMapDto))
                    {
                        configMapDto.AddConfig(config);
                    }
                    else
                    {
                        configMapDto = configMap;
                        configMapDto.AddConfig(config);
                        lookup.Add(configMapDto.FID, configMapDto);
                    }
                    return configMapDto;
                }, splitOn: "FID");
            }
            else
            {
                return null;
            }
        }
    }
}