using ConfigManager.Domain;
using ConfigManager.TransDto.TransModel;
using System.Threading.Tasks;

namespace ConfigManager.DomainService
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IEnvironmentDomainService.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：环境信息领域服务接口
    /// 创建标识：template 2017-07-30 22:11:56
    /// </summary>
    public interface IEnvironmentDomainService
    {
        /// <summary>
        /// 异步判断是否可以新增或修改
        /// </summary>
        /// <param name="info">环境信息</param>
        /// <returns></returns>
        Task CheckAsync(EnvironmentInfo info);

        /// <summary>
        /// 创建环境信息
        /// </summary>
        /// <param name="model">添加信息</param>
        /// <param name="currentUserID">当前用户信息</param>
        /// <returns>环境信息</returns>
        EnvironmentInfo Create(EnvironmentEditModel model, int currentUserID);
    }
}