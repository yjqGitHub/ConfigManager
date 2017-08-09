using ConfigManager.Constant.Constants;
using ConfigManager.Domain;
using ConfigManager.TransDto.QueryWhereDto;
using ConfigManager.TransDto.TransDto;
using ConfigManager.TransDto.TransModel;
using JQ.DataAccess;
using JQ.DataAccess.DbClient;
using JQ.DataAccess.Repositories;
using JQ.DataAccess.Utils;
using JQ.Result.Page;
using System.Threading.Tasks;
using static ConfigManager.Repository.Constants.RepositoryConstant;

namespace ConfigManager.Repository.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ApplicationRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：应用程序信息数据访问类
    /// 创建标识：template 2017-07-30 22:11:50
    /// </summary>
    public sealed class ApplicationRepository : BaseDataRepository<ApplicationInfo>, IApplicationRepository
    {
        public ApplicationRepository(IDataAccessFactory dataAccessFactory) : base(dataAccessFactory, TABLE_NAME_APPLICATION, ConfigurationConstant.CONNECTION_NAME_CONFIGMANAGER)
        {
        }

        /// <summary>
        /// 异步加载环境下的应用列表
        /// </summary>
        /// <param name="queryWhere">查询条件</param>
        /// <returns>应用列表</returns>
        public Task<IPageResult<ApplicationDto>> LoadApplicationListAsync(ApplicationQueryWhereDto queryWhere)
        {
            const string selectColumn = " A.FID,A.FName,A.FCode,A.FEnvironmentID,A.FComment,A.FIsEnabled,A.FVersion,ISNULL(A.FLastModifyTime,A.FCreateTime) AS FLastModifyTime,B.FName AS FEnvironmentName,B.FCode AS FEnvironmentCode ";
            const string selectTable = " " + TABLE_NAME_APPLICATION + " AS A WITH(NOLOCK)  LEFT JOIN " + TABLE_NAME_ENVIRONMENT + " AS B ON A.FEnvironmentID=B.FID AND B.FIsDeleted=0 ";
            SqlWhereBuilder whereBuilder = new SqlWhereBuilder(" A.FIsDeleted=0 ", dbType: DataType);
            whereBuilder.AppendEqual("A.FEnvironmentID", queryWhere.EnvironmentID, paramKey: nameof(queryWhere.EnvironmentID))
                       .AppendLike("A.FName", queryWhere.Name, nameof(queryWhere.Name))
                       .AppendEqual("A.FCode", queryWhere.Code, nameof(queryWhere.Code))
                       .AppendEqual("A.FVersion", queryWhere.Version, nameof(queryWhere.Version))
                       .AppendEqual("A.FIsEnabled", queryWhere.FIsEnabled, nameof(queryWhere.FIsEnabled))
                       ;
            string orderColumn = string.IsNullOrWhiteSpace(queryWhere.OrderColumn) ? "ISNULL(A.FLastModifyTime,A.FCreateTime)" : queryWhere.OrderColumn;
            return QueryPageListAsync<ApplicationDto>(selectColumn, selectTable, whereBuilder.ToString(), orderColumn, queryWhere.PageIndex, queryWhere.PageSize, queryWhere);
        }

        /// <summary>
        /// 异步获取应用编辑信息
        /// </summary>
        /// <param name="applicationID">应用ID</param>
        /// <returns>应用编辑信息</returns>
        public Task<ApplicationEditModel> GetEditModelAsync(int applicationID)
        {
            const string selectSql = "SELECT A.FID,A.FName,A.FCode,A.FEnvironmentID,A.FComment,A.FIsEnabled,A.FVersion,B.FName AS FEnvironmentName,B.FCode AS FEnvironmentCode  FROM  " + TABLE_NAME_APPLICATION + " AS A WITH(NOLOCK)  LEFT JOIN " + TABLE_NAME_ENVIRONMENT + " AS B ON A.FEnvironmentID=B.FID AND B.FIsDeleted=0 WHERE A.FID=@FID AND A.FIsDeleted=0";
            SqlQuery sqlQuery = new SqlQuery(selectSql, new { FID = applicationID });
            return SingleOrDefaultAsync<ApplicationEditModel>(sqlQuery);
        }
    }
}