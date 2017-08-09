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
    /// 类名：IApplicationApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：应用程序信息业务逻辑接口
    /// 创建标识：template 2017-07-30 22:11:50
    /// </summary>
    public interface IApplicationApplication
    {
        /// <summary>
        /// 异步分页加载应用列表
        /// </summary>
        /// <param name="queryWhere">查询条件</param>
        /// <returns>配置组列表</returns>
        Task<OperateResult<IPageResult<ApplicationDto>>> LoadApplicationListAsync(ApplicationQueryWhereDto queryWhere);

        /// <summary>
        /// 异步添加应用
        /// </summary>
        /// <param name="model">应用信息</param>
        /// <param name="operateUserID">当前用户ID</param>
        /// <returns>操作结果</returns>
        Task<OperateResult> AddApplicationAsync(ApplicationEditModel model, int operateUserID);

        /// <summary>
        /// 异步获取应用编辑信息
        /// </summary>
        /// <param name="applicationID">应用ID</param>
        /// <returns>应用编辑信息</returns>
        Task<OperateResult<ApplicationEditModel>> GetApplicationModelAsync(int applicationID);

        /// <summary>
        /// 异步修改应用信息
        /// </summary>
        /// <param name="model">应用信息</param>
        /// <param name="operateUserID">当前用户ID</param>
        /// <returns>操作结果</returns>
        Task<OperateResult> EditApplicationAsync(ApplicationEditModel model, int operateUserID);

        /// <summary>
        /// 异步删除应用信息
        /// </summary>
        /// <param name="applicationID">应用ID</param>
        /// <param name="operateUserID">当前用户ID</param>
        /// <returns>操作结果</returns>
        Task<OperateResult> DeleteApplicationAsync(int applicationID, int operateUserID);
    }
}