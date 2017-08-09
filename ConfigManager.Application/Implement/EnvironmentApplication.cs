using ConfigManager.Constant.Constants;
using ConfigManager.Constant.EnumCollection;
using ConfigManager.DomainService;
using ConfigManager.Repository;
using ConfigManager.TransDto.TransDto;
using ConfigManager.TransDto.TransModel;
using ConfigManager.UnitOfWork;
using JQ.Result.Operate;
using System;
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
        private readonly IAdminOperateLogDomainService _adminOperateLogDomainService;
        private readonly IUnitOfWork _unitOfWork;

        public EnvironmentApplication(IEnvironmentRepository environmentRepository, IEnvironmentDomainService environmentDomainService, IUnitOfWork unitOfWork, IAdminOperateLogDomainService adminOperateLogDomainService)
        {
            _environmentRepository = environmentRepository;
            _environmentDomainService = environmentDomainService;
            _unitOfWork = unitOfWork;
            _adminOperateLogDomainService = adminOperateLogDomainService;
        }

        /// <summary>
        /// 异步获取环境列表
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
        /// 异步添加环境信息
        /// </summary>
        /// <param name="model">环境信息</param>
        /// <param name="operateUserID">操作人</param>
        /// <returns>操作结果</returns>
        public Task<OperateResult> AddEnvironmentAsync(EnvironmentEditModel model, int operateUserID)
        {
            return OperateUtil.ExecuteAsync(async () =>
           {
               var environmentInfo = _environmentDomainService.Create(model, operateUserID);
               await _environmentDomainService.CheckAsync(environmentInfo);
               _unitOfWork.ExecuteTran(() =>
               {
                   _environmentRepository.InsertOne(environmentInfo, IgnoreFieldsConstant.Ignore_FID);
               });
               _adminOperateLogDomainService.AddOperateLog(BizType.Enviroment, $"添加{environmentInfo.GetDescription()}", operateUserID);
           }, callMemberName: "EnvironmentApplication-AddEnvironmentAsync");
        }

        /// <summary>
        /// 异步获取环境编辑信息
        /// </summary>
        /// <param name="environmentID">环境ID</param>
        /// <returns>环境编辑信息</returns>
        public Task<OperateResult<EnvironmentEditModel>> GetEnvironmentModelAsync(int environmentID)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                return await _environmentRepository.GetDtoAsync<EnvironmentEditModel>(new { FID = environmentID, FIsDeleted = 0 });
            }, callMemberName: "EnvironmentApplication-GetEnvironmentModel");
        }

        /// <summary>
        /// 异步编辑环境信息
        /// </summary>
        /// <param name="model">环境信息</param>
        /// <param name="operateUserID">操作人</param>
        /// <returns>操作结果</returns>
        public Task<OperateResult> EditEnvironmentAsync(EnvironmentEditModel model, int operateUserID)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                var environmentInfo = _environmentDomainService.Create(model, operateUserID);
                await _environmentDomainService.CheckAsync(environmentInfo);
                _unitOfWork.ExecuteTran(() =>
                {
                    _environmentRepository.Update(environmentInfo, new { FID = environmentInfo.FID }, ignoreFields: IgnoreFieldsConstant.Ignore_KeyAndCreate);
                });
                _adminOperateLogDomainService.AddOperateLog(BizType.Enviroment, $"修改{environmentInfo.GetDescription()}", operateUserID);
            }, callMemberName: "EnvironmentApplication-AddEnvironmentAsync");
        }

        /// <summary>
        /// 异步获取环境信息
        /// </summary>
        /// <param name="environmentID">环境ID</param>
        /// <returns>环境信息</returns>
        public Task<OperateResult<EnvironmentDto>> GetEnvironmentInfoAsync(int environmentID)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                return await _environmentRepository.GetEnvironmentDtoAsync(environmentID);
            }, callMemberName: "EnvironmentApplication-GetEnvironmentInfoAsync");
        }

        /// <summary>
        /// 异步删除环境
        /// </summary>
        /// <param name="environmentID">环境ID</param>
        /// <param name="operateUserID">操作人</param>
        /// <returns>操作结果</returns>
        public Task<OperateResult> DeleteEnvironmentAsync(int environmentID, int operateUserID)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                await _environmentRepository.UpdateAsync(new
                {
                    FIsDeleted = 1,
                    FLastModifyTime = DateTime.Now,
                    FLaseModifyUserID = operateUserID
                }, new { FID = environmentID });
                _adminOperateLogDomainService.AddOperateLog(BizType.Enviroment, $"删除环境【FID:{environmentID.ToString()}】", operateUserID);
            }, callMemberName: "EnvironmentApplication-DeleteEnvironmentAsync");
        }
    }
}