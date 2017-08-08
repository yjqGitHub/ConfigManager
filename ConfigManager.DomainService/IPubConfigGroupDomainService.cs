using ConfigManager.Domain;
using ConfigManager.TransDto.TransModel;
using System.Threading.Tasks;

namespace ConfigManager.DomainService
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IPubConfigGroupDomainService.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：公共配置组信息领域服务接口
    /// 创建标识：template 2017-07-30 22:11:57
    /// </summary>
    public interface IPubConfigGroupDomainService
    {
        /// <summary>
        /// 创建组信息
        /// </summary>
        /// <param name="model">组信息</param>
        /// <param name="currentUserID">当前用户ID</param>
        /// <returns>组信息</returns>
        PubConfigGroupInfo Create(PubConfigGroupEditModel model, int currentUserID);

        /// <summary>
        /// 异步判断是否可以新增或修改
        /// </summary>
        /// <param name="info">组信息</param>
        /// <returns></returns>
        Task CheckAsync(PubConfigGroupInfo info);
    }
}