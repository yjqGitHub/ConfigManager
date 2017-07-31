using ConfigManager.TransDto.TransDto;
using ConfigManager.TransDto.TransModel;
using JQ.Result.Operate;
using System.Threading.Tasks;

namespace ConfigManager.Application
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IAdminApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员信息业务逻辑接口
    /// 创建标识：template 2017-07-30 22:11:49
    /// </summary>
    public interface IAdminApplication
    {
        /// <summary>
        /// 异步登录
        /// </summary>
        /// <param name="model">登录用户信息</param>
        /// <returns>操作结果</returns>
        Task<OperateResult<AdminDto>> LoginAsync(LoginModel model);
    }
}