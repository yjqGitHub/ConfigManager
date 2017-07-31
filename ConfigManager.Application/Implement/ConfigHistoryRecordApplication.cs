using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ConfigHistoryRecordApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：配置信息历史记录业务逻辑
	/// 创建标识：template 2017-07-30 22:11:54
	/// </summary>
	public sealed class ConfigHistoryRecordApplication : IConfigHistoryRecordApplication
	{
		private readonly IConfigHistoryRecordRepository _configHistoryRecordRepository;
		private readonly IConfigHistoryRecordDomainService _configHistoryRecordDomainService;

		public ConfigHistoryRecordApplication(IConfigHistoryRecordRepository configHistoryRecordRepository, IConfigHistoryRecordDomainService configHistoryRecordDomainService)
		{
			_configHistoryRecordRepository= configHistoryRecordRepository;
			_configHistoryRecordDomainService =configHistoryRecordDomainService; 
		}
	}
}
