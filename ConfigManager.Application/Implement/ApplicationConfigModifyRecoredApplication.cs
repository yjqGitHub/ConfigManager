using ConfigManager.Repository;
using ConfigManager.DomainService;

namespace ConfigManager.Application.Implement
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ApplicationConfigModifyRecoredApplication.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：应用更新配置记录业务逻辑
	/// 创建标识：template 2017-07-30 22:11:52
	/// </summary>
	public sealed class ApplicationConfigModifyRecoredApplication : IApplicationConfigModifyRecoredApplication
	{
		private readonly IApplicationConfigModifyRecoredRepository _applicationConfigModifyRecoredRepository;
		private readonly IApplicationConfigModifyRecoredDomainService _applicationConfigModifyRecoredDomainService;

		public ApplicationConfigModifyRecoredApplication(IApplicationConfigModifyRecoredRepository applicationConfigModifyRecoredRepository, IApplicationConfigModifyRecoredDomainService applicationConfigModifyRecoredDomainService)
		{
			_applicationConfigModifyRecoredRepository= applicationConfigModifyRecoredRepository;
			_applicationConfigModifyRecoredDomainService =applicationConfigModifyRecoredDomainService; 
		}
	}
}
