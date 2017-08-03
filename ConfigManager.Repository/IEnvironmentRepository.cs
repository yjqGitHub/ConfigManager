using ConfigManager.Domain;
using ConfigManager.TransDto.TransDto;
using JQ.DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigManager.Repository
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IEnvironmentRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：环境信息数据访问接口
    /// 创建标识：template 2017-07-30 22:11:56
    /// </summary>
    public interface IEnvironmentRepository : IBaseDataRepository<EnvironmentInfo>
    {
        /// <summary>
        /// 获取环境列表
        /// </summary>
        /// <returns>环境列表</returns>
        Task<IEnumerable<EnvironmentDto>> LoadEnvironmentListAsync();
    }
}