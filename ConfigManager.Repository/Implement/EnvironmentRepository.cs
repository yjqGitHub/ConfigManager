using ConfigManager.Constant.Constants;
using ConfigManager.Domain;
using ConfigManager.Repository.Constants;
using ConfigManager.TransDto.TransDto;
using JQ.DataAccess;
using JQ.DataAccess.DbClient;
using JQ.DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// 获取环境列表
        /// </summary>
        /// <returns>环境列表</returns>
        public Task<IEnumerable<EnvironmentDto>> LoadEnvironmentListAsync()
        {
            string sql = "SELECT FID,FName,FCode,FSecret,FComment,ISNULL(FLastModifyTime,FCreateTime) FLastModifyTime FROM " + TableName + " WITH(NOLOCK) WHERE FIsDeleted=0 ORDER BY ISNULL(FLastModifyTime,FCreateTime) DESC";
            SqlQuery sqlQuery = new SqlQuery(sql);
            return QueryListAsync<EnvironmentDto>(sqlQuery);
        }
    }
}