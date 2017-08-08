using ConfigManager.TransDto.TransDto;
using ConfigManager.TransDto.TransModel;
using JQ.Result.Operate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigManager.Application
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IEnvironmentApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：环境信息业务逻辑接口
    /// 创建标识：template 2017-07-30 22:11:56
    /// </summary>
    public interface IEnvironmentApplication
    {
        /// <summary>
        /// 异步获取环境列表
        /// </summary>
        /// <returns></returns>
        Task<OperateResult<IEnumerable<EnvironmentDto>>> LoadEnvironmentListAsync();

        /// <summary>
        /// 异步添加环境信息
        /// </summary>
        /// <param name="model">环境信息</param>
        /// <param name="operateUserID">操作人</param>
        /// <returns>操作结果</returns>
        Task<OperateResult> AddEnvironmentAsync(EnvironmentEditModel model, int operateUserID);

        /// <summary>
        /// 异步获取环境编辑信息
        /// </summary>
        /// <param name="environmentID">环境ID</param>
        /// <returns>环境编辑信息</returns>
        Task<OperateResult<EnvironmentEditModel>> GetEnvironmentModelAsync(int environmentID);

        /// <summary>
        /// 异步编辑环境信息
        /// </summary>
        /// <param name="model">环境信息</param>
        /// <param name="operateUserID">操作人</param>
        /// <returns>操作结果</returns>
        Task<OperateResult> EditEnvironmentAsync(EnvironmentEditModel model, int operateUserID);

        /// <summary>
        /// 异步获取环境信息
        /// </summary>
        /// <param name="environmentID">环境ID</param>
        /// <returns>环境信息</returns>
        Task<OperateResult<EnvironmentDto>> GetEnvironmentInfoAsync(int environmentID);

        /// <summary>
        /// 异步删除环境
        /// </summary>
        /// <param name="environmentID">环境ID</param>
        /// <param name="operateUserID">操作人</param>
        /// <returns>操作结果</returns>
        Task<OperateResult> DeleteEnvironmentAsync(int environmentID, int operateUserID);
    }
}