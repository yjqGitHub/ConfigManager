using ConfigManager.Constant.Constants;
using ConfigManager.Domain;
using ConfigManager.Repository.Constants;
using ConfigManager.TransDto.QueryWhereDto;
using ConfigManager.TransDto.TransDto;
using ConfigManager.TransDto.TransModel;
using JQ.DataAccess;
using JQ.DataAccess.DbClient;
using JQ.DataAccess.Repositories;
using JQ.DataAccess.Utils;
using JQ.Result.Page;
using System.Threading.Tasks;

namespace ConfigManager.Repository.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：PubConfigGroupRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：公共配置组信息数据访问类
    /// 创建标识：template 2017-07-30 22:11:57
    /// </summary>
    public sealed class PubConfigGroupRepository : BaseDataRepository<PubConfigGroupInfo>, IPubConfigGroupRepository
    {
        public PubConfigGroupRepository(IDataAccessFactory dataAccessFactory) : base(dataAccessFactory, RepositoryConstant.TABLE_NAME_PUBCONFIGGROUP, ConfigurationConstant.CONNECTION_NAME_CONFIGMANAGER)
        {
        }

        /// <summary>
        /// 异步加载分组列表
        /// </summary>
        /// <param name="queryWhere">查询条件</param>
        /// <returns>分组列表</returns>
        public Task<IPageResult<PubConfigGroupDto>> LoadConfigGroupListAsync(ConfigGroupQueryWhereDto queryWhere)
        {
            const string selectColumn = " A.FID,A.FCode,A.FName,A.FEnvironmentID,A.FIsEnabled,A.FComment,ISNULL(A.FLastModifyTime,A.FCreateTime) AS FLastModifyTime,B.FName AS FEnvironmentName,B.FCode AS FEnvironmentCode ";
            const string selectTable = " " + RepositoryConstant.TABLE_NAME_PUBCONFIGGROUP + " AS A WITH(NOLOCK) LEFT JOIN " + RepositoryConstant.TABLE_NAME_ENVIRONMENT + " AS B WITH(NOLOCK) ON A.FEnvironmentID=B.FID AND B.FIsDeleted=0 ";
            SqlWhereBuilder whereBuilder = new SqlWhereBuilder(" A.FIsDeleted=0 ", dbType: DataType);
            whereBuilder.AppendEqual("A.FEnvironmentID", queryWhere.EnvironmentID, nameof(queryWhere.EnvironmentID))
                        .AppendLike("A.FName", queryWhere.Name, nameof(queryWhere.Name))
                        .AppendEqual("A.FCode", queryWhere.Code, nameof(queryWhere.Code))
                        .AppendEqual("A.FIsEnabled", queryWhere.FIsEnabled, nameof(queryWhere.FIsEnabled))
                        ;
            string orderColumn = string.IsNullOrWhiteSpace(queryWhere.OrderColumn) ? "ISNULL(A.FLastModifyTime,A.FCreateTime)" : queryWhere.OrderColumn;
            return QueryPageListAsync<PubConfigGroupDto>(selectColumn, selectTable, whereBuilder.ToString(), orderColumn, queryWhere.PageIndex, queryWhere.PageSize, queryWhere);
        }

        /// <summary>
        /// 获取配置组编辑信息
        /// </summary>
        /// <param name="pubConfigGroupID">配置组ID</param>
        /// <returns>配置组编辑信息</returns>
        public Task<PubConfigGroupEditModel> GetEditModelAsync(int pubConfigGroupID)
        {
            string sql = "SELECT A.FID,A.FName,A.FCode,A.FEnvironmentID,A.FComment,A.FIsEnabled,B.FName AS FEnvironmentName,B.FCode AS FEnvironmentCode FROM  " + RepositoryConstant.TABLE_NAME_PUBCONFIGGROUP + " AS A WITH(NOLOCK) LEFT JOIN " + RepositoryConstant.TABLE_NAME_ENVIRONMENT + " AS B WITH(NOLOCK) ON A.FEnvironmentID=B.FID AND B.FIsDeleted=0 WHERE A.FID=@FID AND A.FIsDeleted=0;";
            SqlQuery sqlQuery = new SqlQuery(sql, new { FID = pubConfigGroupID });
            return SingleOrDefaultAsync<PubConfigGroupEditModel>(sqlQuery);
        }
    }
}