using ConfigManager.Domain;
using ConfigManager.TransDto.QueryWhereDto;
using ConfigManager.TransDto.TransDto;
using ConfigManager.TransDto.TransModel;
using JQ.DataAccess.Repositories;
using JQ.Result.Page;
using System.Threading.Tasks;

namespace ConfigManager.Repository
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IApplicationRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：应用程序信息数据访问接口
    /// 创建标识：template 2017-07-30 22:11:50
    /// </summary>
    public interface IApplicationRepository : IBaseDataRepository<ApplicationInfo>
    {
        /// <summary>
        /// 异步加载环境下的应用列表
        /// </summary>
        /// <param name="queryWhere">查询条件</param>
        /// <returns>应用列表</returns>
        Task<IPageResult<ApplicationDto>> LoadApplicationListAsync(ApplicationQueryWhereDto queryWhere);

        /// <summary>
        /// 异步获取应用编辑信息
        /// </summary>
        /// <param name="applicationID">应用ID</param>
        /// <returns>应用编辑信息</returns>
        Task<ApplicationEditModel> GetEditModelAsync(int applicationID);
    }
}