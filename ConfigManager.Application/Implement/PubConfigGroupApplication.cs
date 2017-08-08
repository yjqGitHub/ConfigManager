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
using System.Threading.Tasks;

namespace ConfigManager.Application.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：PubConfigGroupApplication.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：公共配置组信息业务逻辑
    /// 创建标识：template 2017-07-30 22:11:57
    /// </summary>
    public sealed class PubConfigGroupApplication : IPubConfigGroupApplication
    {
        private readonly IPubConfigGroupRepository _pubConfigGroupRepository;
        private readonly IPubConfigGroupDomainService _pubConfigGroupDomainService;
        private readonly IAdminOperateLogDomainService _adminOperateLogDomainService;
        private readonly IUnitOfWork _unitOfWork;

        public PubConfigGroupApplication(IPubConfigGroupRepository pubConfigGroupRepository, IPubConfigGroupDomainService pubConfigGroupDomainService, IUnitOfWork unitOfWork, IAdminOperateLogDomainService adminOperateLogDomainService)
        {
            _pubConfigGroupRepository = pubConfigGroupRepository;
            _pubConfigGroupDomainService = pubConfigGroupDomainService;
            _adminOperateLogDomainService = adminOperateLogDomainService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 分页加载配置组列表
        /// </summary>
        /// <param name="queryWhere">查询条件</param>
        /// <returns>配置组列表</returns>
        public Task<OperateResult<IPageResult<PubConfigGroupDto>>> LoadConfigGroupListAsync(ConfigGroupQueryWhereDto queryWhere)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                return await _pubConfigGroupRepository.LoadConfigGroupListAsync(queryWhere);
            }, callMemberName: "PubConfigGroupApplication-LoadConfigGroupListAsync");
        }

        /// <summary>
        /// 异步添加配置组信息
        /// </summary>
        /// <param name="model">配置组信息</param>
        /// <param name="operateUserID">当前用户ID</param>
        /// <returns>操作结果</returns>
        public Task<OperateResult> AddConfigGroupAsync(PubConfigGroupEditModel model, int operateUserID)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                var groupInfo = _pubConfigGroupDomainService.Create(model, operateUserID);
                await _pubConfigGroupDomainService.CheckAsync(groupInfo);
                _unitOfWork.ExecuteTran(() =>
                {
                    _pubConfigGroupRepository.InsertOne(groupInfo, IgnoreFieldsConstant.Ignore_FID);
                });
                _adminOperateLogDomainService.AddOperateLog(BizType.ConfigGroup, $"添加{groupInfo.GetDescription()}", operateUserID);
            }, callMemberName: "PubConfigGroupApplication-AddConfigGroupAsync");
        }

        /// <summary>
        /// 异步获取分组配置的编辑信息
        /// </summary>
        /// <param name="pubConfigGroupID">分组配置ID</param>
        /// <returns>分组配置的编辑信息</returns>
        public Task<OperateResult<PubConfigGroupEditModel>> GetConfigGroupEditModelAsync(int pubConfigGroupID)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                return await _pubConfigGroupRepository.GetEditModelAsync(pubConfigGroupID);
            }, callMemberName: "PubConfigGroupApplication-GetConfigGroupEditModelAsync");
        }

        /// <summary>
        /// 异步编辑配置组信息
        /// </summary>
        /// <param name="model">配置组信息</param>
        /// <param name="operateUserID">操作人</param>
        /// <returns>操作结果</returns>
        public Task<OperateResult> EditConfigGroupAsync(PubConfigGroupEditModel model, int operateUserID)
        {
            return OperateUtil.ExecuteAsync(async () =>
            {
                var publicConfigGroupInfo = _pubConfigGroupDomainService.Create(model, operateUserID);
                await _pubConfigGroupDomainService.CheckAsync(publicConfigGroupInfo);
                _unitOfWork.ExecuteTran(() =>
                {
                    _pubConfigGroupRepository.Update(publicConfigGroupInfo, new { FID = publicConfigGroupInfo.FID }, ignoreFields: IgnoreFieldsConstant.Ignore_KeyAndCreate);
                });
                _adminOperateLogDomainService.AddOperateLog(BizType.ConfigGroup, $"修改{publicConfigGroupInfo.GetDescription()}", operateUserID);
            }, callMemberName: "PubConfigGroupApplication-EditConfigGroupAsync");
        }
    }
}