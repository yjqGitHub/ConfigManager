using ConfigManager.Constant.EnumCollection;
using ConfigManager.TransDto.TransDto;
using System.Threading.Tasks;

namespace ConfigManager.DomainService
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IAdminDomainService.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员信息领域服务接口
    /// 创建标识：template 2017-07-30 22:11:48
    /// </summary>
    public interface IAdminDomainService
    {
        /// <summary>
        /// 异步登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="sitePort">端口</param>
        /// <returns>用户信息</returns>
        Task<AdminDto> LoginAsync(string userName, string pwd, WebSitePort sitePort);
    }
}