using ConfigManager.TransDto.TransDto;
using System.Threading.Tasks;

namespace ConfigManager.Cache
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：IAdminCache.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：IAdminCache接口
    /// 创建标识：yjq 2017/7/31 16:04:33
    /// </summary>
    public interface IAdminCache
    {
        /// <summary>
        /// 异步设置尝试登录次数
        /// </summary>
        /// <param name="userName">要设置的用户名</param>
        /// <returns></returns>
        Task<long> AddTryLoginCountAsync(string userName);

        /// <summary>
        /// 异步获取尝试登录次数
        /// </summary>
        /// <param name="userName">要获取的用户名</param>
        /// <returns>失败次数</returns>
        Task<long> GetTryLoginCountAsync(string userName);

        /// <summary>
        /// 异步添加管理员信息缓存(1小时之内无访问则过期)
        /// </summary>
        /// <param name="adminInfo">管理员信息</param>
        /// <returns>异步，可等待</returns>
        Task AddAdminInfoAsync(AdminDto adminInfo);

        /// <summary>
        /// 异步获取管理员信息
        /// </summary>
        /// <param name="adminId">管理员ID</param>
        /// <returns>管理员信息</returns>
        Task<AdminDto> GetAdminInfoAsync(int adminId);
    }
}