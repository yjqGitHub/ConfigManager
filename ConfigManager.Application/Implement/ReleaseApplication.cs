using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ReleaseApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：发布内容业务逻辑
	/// 创建标识：template 2017-07-30 22:11:57
	/// </summary>
	public sealed class ReleaseApplication : IReleaseApplication
	{
		private readonly IReleaseRepository _releaseRepository;
		private readonly IReleaseDomainService _releaseDomainService;

		public ReleaseApplication(IReleaseRepository releaseRepository, IReleaseDomainService releaseDomainService)
		{
			_releaseRepository= releaseRepository;
			_releaseDomainService =releaseDomainService; 
		}
	}
}
