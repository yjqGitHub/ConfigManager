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
        /// 获取环境列表
        /// </summary>
        /// <returns></returns>
        Task<OperateResult<IEnumerable<EnvironmentDto>>> LoadEnvironmentListAsync();

        /// <summary>
        /// 添加环境信息
        /// </summary>
        /// <param name="model">环境信息</param>
        /// <param name="operateUserID">操作人</param>
        /// <returns>操作结果</returns>
        Task<OperateResult> AddEnvironmentAsync(EnvironmentAddModel model, int operateUserID);
    }
}