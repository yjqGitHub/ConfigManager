using ConfigManager.Domain;
using ConfigManager.TransDto.TransDto;
using JQ.DataAccess.Repositories;
using System.Threading.Tasks;

namespace ConfigManager.Repository
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IAdminRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员信息数据访问接口
    /// 创建标识：template 2017-07-30 22:11:48
    /// </summary>
    public interface IAdminRepository : IBaseDataRepository<AdminInfo>
    {
        /// <summary>
        /// 异步获取管理员信息（传输对象）
        /// </summary>
        /// <param name="adminId">管理员ID</param>
        /// <returns>管理员信息（传输对象）</returns>
        Task<AdminDto> GetAdminTransInfo(int adminId);
    }
}