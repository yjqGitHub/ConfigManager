using ConfigManager.Constant.Constants;
using ConfigManager.Domain;
using ConfigManager.Repository.Constants;
using ConfigManager.TransDto.TransDto;
using JQ.DataAccess;
using JQ.DataAccess.DbClient;
using JQ.DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using JQ.DataAccess.Utils;

namespace ConfigManager.Repository.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：EnvironmentRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：环境信息数据访问类
    /// 创建标识：template 2017-07-30 22:11:56
    /// </summary>
    public sealed class EnvironmentRepository : BaseDataRepository<EnvironmentInfo>, IEnvironmentRepository
    {
        public EnvironmentRepository(IDataAccessFactory dataAccessFactory) : base(dataAccessFactory, RepositoryConstant.TABLE_NAME_ENVIRONMENT, ConfigurationConstant.CONNECTION_NAME_CONFIGMANAGER)
        {
        }

        /// <summary>
        /// 异步获取环境列表
        /// </summary>
        /// <returns>环境列表</returns>
        public Task<IEnumerable<EnvironmentDto>> LoadEnvironmentListAsync()
        {
            string sql = "SELECT FID,FName,FCode,FSecret,FOrderIndex,FComment," + "FLastModifyTime".IsNull("FCreateTime", dbType: DataType) + " AS FLastModifyTime FROM " + TableName.WithNolock(dbType: DataType) + " WHERE FIsDeleted=0 ORDER BY ISNULL(FLastModifyTime,FCreateTime) DESC";
            SqlQuery sqlQuery = new SqlQuery(sql);
            return QueryListAsync<EnvironmentDto>(sqlQuery);
        }

        /// <summary>
        /// 异步获取环境传输信息
        /// </summary>
        /// <param name="environmentID">环境ID</param>
        /// <returns>环境传输信息</returns>
        public Task<EnvironmentDto> GetEnvironmentDtoAsync(int environmentID)
        {
            string sql = "SELECT FID,FName,FCode,FSecret,FOrderIndex,FComment," + "FLastModifyTime".IsNull("FCreateTime", dbType: DataType) + " AS FLastModifyTime FROM " + TableName.WithNolock(dbType: DataType) + " WHERE FID=@FID AND FIsDeleted=0;";
            SqlQuery sqlQuery = new SqlQuery(sql, new { FID = environmentID });
            return SingleOrDefaultAsync<EnvironmentDto>(sqlQuery);
        }
    }
}