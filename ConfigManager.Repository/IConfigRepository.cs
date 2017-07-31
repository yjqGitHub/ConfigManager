using JQ.DataAccess.Repositories;
using ConfigManager.Domain;

namespace ConfigManager.Repository
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：IConfigRepository.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：配置值信息数据访问接口
	/// 创建标识：template 2017-07-30 22:11:52
	/// </summary>
	public interface IConfigRepository : IBaseDataRepository<ConfigInfo>
	{
	}
}
