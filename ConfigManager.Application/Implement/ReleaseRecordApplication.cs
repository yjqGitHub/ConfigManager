using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ReleaseRecordApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：发布记录业务逻辑
	/// 创建标识：template 2017-07-30 22:11:58
	/// </summary>
	public sealed class ReleaseRecordApplication : IReleaseRecordApplication
	{
		private readonly IReleaseRecordRepository _releaseRecordRepository;
		private readonly IReleaseRecordDomainService _releaseRecordDomainService;

		public ReleaseRecordApplication(IReleaseRecordRepository releaseRecordRepository, IReleaseRecordDomainService releaseRecordDomainService)
		{
			_releaseRecordRepository= releaseRecordRepository;
			_releaseRecordDomainService =releaseRecordDomainService; 
		}
	}
}
