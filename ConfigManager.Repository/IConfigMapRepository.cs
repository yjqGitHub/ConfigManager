using ConfigManager.Domain;
using ConfigManager.TransDto.QueryWhereDto;
using ConfigManager.TransDto.TransDto;
using JQ.DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigManager.Repository
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IConfigMapRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：环境、项目公共配置组与配置关系数据访问接口
    /// 创建标识：template 2017-07-30 22:11:55
    /// </summary>
    public interface IConfigMapRepository : IBaseDataRepository<ConfigMapInfo>
    {
        /// <summary>
        /// 异步根据所属类型加载配置列表
        /// </summary>
        /// <param name="queryWhere">查询条件</param>
        /// <returns>配置列表</returns>
        Task<IEnumerable<ConfigMapDto>> LoadConfigList(ConfigMapQueryWhereDto queryWhere);
    }
}