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
    /// 类名：IPubConfigGroupRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：公共配置组信息数据访问接口
    /// 创建标识：template 2017-07-30 22:11:56
    /// </summary>
    public interface IPubConfigGroupRepository : IBaseDataRepository<PubConfigGroupInfo>
    {
        /// <summary>
        /// 获取配置组编辑信息
        /// </summary>
        /// <param name="pubConfigGroupID">配置组ID</param>
        /// <returns>配置组编辑信息</returns>
        Task<PubConfigGroupEditModel> GetEditModelAsync(int pubConfigGroupID);

        /// <summary>
        /// 异步加载分组列表
        /// </summary>
        /// <param name="queryWhere">查询条件</param>
        /// <returns>分组列表</returns>
        Task<IPageResult<PubConfigGroupDto>> LoadConfigGroupListAsync(ConfigGroupQueryWhereDto queryWhere);
    }
}