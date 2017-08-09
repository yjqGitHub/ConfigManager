using ConfigManager.Domain;
using ConfigManager.TransDto.TransModel;
using System.Threading.Tasks;

namespace ConfigManager.DomainService
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IApplicationDomainService.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：应用程序信息领域服务接口
    /// 创建标识：template 2017-07-30 22:11:50
    /// </summary>
    public interface IApplicationDomainService
    {
        /// <summary>
        /// 创建应用信息
        /// </summary>
        /// <param name="model">应用信息</param>
        /// <param name="currentUserID">当前用户ID</param>
        /// <returns>应用信息</returns>
        ApplicationInfo Create(ApplicationEditModel model, int currentUserID);

        /// <summary>
        /// 校验是否可以新增或者修改
        /// </summary>
        /// <param name="info">应用信息</param>m
        /// <returns></returns>
        Task CheckAsync(ApplicationInfo info);
    }
}