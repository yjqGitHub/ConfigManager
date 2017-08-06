using ConfigManager.Constant.Constants;
using ConfigManager.Constant.EnumCollection;
using ConfigManager.Domain;
using ConfigManager.DomainService;
using ConfigManager.Repository;
using ConfigManager.TransDto.TransDto;
using ConfigManager.TransDto.TransModel;
using ConfigManager.UnitOfWork;
using JQ.Result.Operate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigManager.Application.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：EnvironmentApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：环境信息业务逻辑
    /// 创建标识：template 2017-07-30 22:11:56
    /// </summary>
    public sealed class EnvironmentApplication : IEnvironmentApplication
    {
        private readonly IEnvironmentRepository _environmentRepository;
        private readonly IEnvironmentDomainService _environmentDomainService;
        private readonly IAdminOperateLogRepository _adminOperateLogRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EnvironmentApplication(IEnvironmentRepository environmentRepository, IEnvironmentDomainService environmentDomainService, IUnitOfWork unitOfWork, IAdminOperateLogRepository adminOperateLogRepository)
        {
            _environmentRepository = environmentRepository;
            _environmentDomainService = environmentDomainService;
            _unitOfWork = unitOfWork;
            _adminOperateLogRepository = adminOperateLogRepository;
        }

        /// <summary>
        /// 获取环境列表
        /// </summary>
        /// <returns></returns>
        public Task<OperateResult<IEnumerable<EnvironmentDto>>> LoadEnvironmentListAsync()
        {
            return OperateUtil.ExecuteAsync(async () =>
             {
                 return await _environmentRepository.LoadEnvironmentListAsync();
             }, callMemberName: "EnvironmentApplication-LoadEnvironmentListAsync");
        }

        /// <summary>
        /// 添加环境信息
        /// </summary>
        /// <param name="model">环境信息</param>
        /// <param name="operateUserID">操作人</param>
        /// <returns>操作结果</returns>
        public Task<OperateResult> AddEnvironmentAsync(EnvironmentAddModel model, int operateUserID)
        {
            return OperateUtil.ExecuteAsync(async () =>
           {
               var environmentInfo = _environmentDomainService.Create(model, operateUserID);
               await _environmentDomainService.CheckAsync(environmentInfo);
               var operateLog = AdminOperateLogInfo.Create(BizType.Enviroment, $"添加{environmentInfo.GetDescription()}", operateUserID);
               _unitOfWork.Begin();
               _environmentRepository.InsertOne(environmentInfo, IgnoreFieldsConstant.Ignore_FID);
               _adminOperateLogRepository.InsertOne(operateLog, IgnoreFieldsConstant.Ignore_FID);
               _unitOfWork.Commit();
           }, callMemberName: "EnvironmentApplication-AddEnvironmentAsync");
        }
    }
}