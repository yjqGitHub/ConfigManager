using ConfigManager.TransDto.QueryWhereDto;
using ConfigManager.TransDto.TransDto;
using ConfigManager.TransDto.TransModel;
using JQ.Result.Operate;
using JQ.Result.Page;
using System.Threading.Tasks;

namespace ConfigManager.Application
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IPubConfigGroupApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：公共配置组信息业务逻辑接口
    /// 创建标识：template 2017-07-30 22:11:57
    /// </summary>
    public interface IPubConfigGroupApplication
    {
        /// <summary>
        /// 分页加载配置组列表
        /// </summary>
        /// <param name="queryWhere">查询条件</param>
        /// <returns>配置组列表</returns>
        Task<OperateResult<IPageResult<PubConfigGroupDto>>> LoadConfigGroupListAsync(ConfigGroupQueryWhereDto queryWhere);

        /// <summary>
        /// 异步添加配置组信息
        /// </summary>
        /// <param name="model">配置组信息</param>
        /// <param name="operateUserID">当前用户ID</param>
        /// <returns>操作结果</returns>
        Task<OperateResult> AddConfigGroupAsync(PubConfigGroupEditModel model, int operateUserID);

        /// <summary>
        /// 异步获取分组配置的编辑信息
        /// </summary>
        /// <param name="pubConfigGroupID">分组配置ID</param>
        /// <returns>分组配置的编辑信息</returns>
        Task<OperateResult<PubConfigGroupEditModel>> GetConfigGroupEditModelAsync(int pubConfigGroupID);

        /// <summary>
        /// 异步编辑配置组信息
        /// </summary>
        /// <param name="model">配置组信息</param>
        /// <param name="operateUserID">操作人</param>
        /// <returns>操作结果</returns>
        Task<OperateResult> EditConfigGroupAsync(PubConfigGroupEditModel model, int operateUserID);
    }
}