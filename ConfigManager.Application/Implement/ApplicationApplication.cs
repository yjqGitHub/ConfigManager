using ConfigManager.Constant.Constants;
using ConfigManager.Constant.EnumCollection;
using ConfigManager.DomainService;
using ConfigManager.Repository;
using ConfigManager.TransDto.QueryWhereDto;
using ConfigManager.TransDto.TransDto;
using ConfigManager.TransDto.TransModel;
using ConfigManager.UnitOfWork;
using JQ.Result.Operate;
using JQ.Result.Page;
using System;
using System.Threading.Tasks;

namespace ConfigManager.Application.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ApplicationApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：应用程序信息业务逻辑
    /// 创建标识：template 2017-07-30 22:11:50
    /// </summary>
    public sealed class ApplicationApplication : IApplicationApplication
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicationDomainService _applicationDomainService;
        private readonly IAdminOperateLogDomainService _adminOperateLogDomainService;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationApplication(IApplicationRepository applicationRepository, IApplicationDomainService applicationDomainService, IUnitOfWork unitOfWork, IAdminOperateLogDomainService adminOperateLogDomainService)
        {
            _applicationRepository = applicationRepository;
            _applicationDomainService = applicationDomainService;
            _adminOperateLogDomainService = adminOperateLogDomainService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 异步分页加载应用列表
        /// </summary>
        /// <param name="queryWhere">查询条件</param>
        /// <returns>配置组列表</returns>
        public Task<OperateResult<IPageResult<ApplicationDto>>> LoadApplicationListAsync(ApplicationQueryWhereDto queryWhere)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                return await _applicationRepository.LoadApplicationListAsync(queryWhere);
            }, callMemberName: "ApplicationApplication-LoadApplicationListAsync");
        }

        /// <summary>
        /// 异步添加应用
        /// </summary>
        /// <param name="model">应用信息</param>
        /// <param name="operateUserID">当前用户ID</param>
        /// <returns>操作结果</returns>
        public Task<OperateResult> AddApplicationAsync(ApplicationEditModel model, int operateUserID)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                var applicationInfo = _applicationDomainService.Create(model, operateUserID);
                await _applicationDomainService.CheckAsync(applicationInfo);
                _unitOfWork.Begin();
                _applicationRepository.InsertOne(applicationInfo, IgnoreFieldsConstant.Ignore_FID);
                _adminOperateLogDomainService.AddOperateLog(BizType.Application, $"添加{applicationInfo.GetDescription()}", operateUserID);
                _unitOfWork.Commit();
            }, callMemberName: "ApplicationApplication-AddApplicationAsync");
        }

        /// <summary>
        /// 异步获取应用编辑信息
        /// </summary>
        /// <param name="applicationID">应用ID</param>
        /// <returns>应用编辑信息</returns>
        public Task<OperateResult<ApplicationEditModel>> GetApplicationModelAsync(int applicationID)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                return await _applicationRepository.GetEditModelAsync(applicationID);
            }, callMemberName: "ApplicationApplication-GetApplicationModelAsync");
        }

        /// <summary>
        /// 异步修改应用信息
        /// </summary>
        /// <param name="model">应用信息</param>
        /// <param name="operateUserID">当前用户ID</param>
        /// <returns>操作结果</returns>
        public Task<OperateResult> EditApplicationAsync(ApplicationEditModel model, int operateUserID)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                var applicationInfo = _applicationDomainService.Create(model, operateUserID);
                await _applicationDomainService.CheckAsync(applicationInfo);
                _unitOfWork.Begin();
                _applicationRepository.Update(applicationInfo, new { FID = applicationInfo.FID }, ignoreFields: IgnoreFieldsConstant.Ignore_KeyAndCreate);
                _adminOperateLogDomainService.AddOperateLog(BizType.Application, $"修改{applicationInfo.GetDescription()}", operateUserID);
                _unitOfWork.Commit();
            }, callMemberName: "ApplicationApplication-EditApplicationAsync");
        }

        /// <summary>
        /// 异步删除应用信息
        /// </summary>
        /// <param name="applicationID">应用ID</param>
        /// <param name="operateUserID">当前用户ID</param>
        /// <returns>操作结果</returns>
        public Task<OperateResult> DeleteApplicationAsync(int applicationID, int operateUserID)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                await _applicationRepository.UpdateAsync(new
                {
                    FIsDeleted = 1,
                    FLastModifyTime = DateTime.Now,
                    FLaseModifyUserID = operateUserID
                }, new { FID = applicationID });
                _adminOperateLogDomainService.AddOperateLog(BizType.Application, $"删除应用【FID:{applicationID.ToString()}】", operateUserID);
            }, callMemberName: "ApplicationApplication-DeleteApplicationAsync");
        }
    }
}