using ConfigManager.Domain;
using ConfigManager.Repository;
using ConfigManager.TransDto.TransModel;
using JQ;
using JQ.Utils;
using System;
using System.Threading.Tasks;

namespace ConfigManager.DomainService.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ApplicationDomainService.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：应用程序信息业务逻辑处理
    /// 创建标识：template 2017-07-30 22:11:50
    /// </summary>
    public sealed class ApplicationDomainService : IApplicationDomainService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IEnvironmentRepository _environmentRepository;

        public ApplicationDomainService(IApplicationRepository applicationRepository, IEnvironmentRepository environmentRepository)
        {
            _applicationRepository = applicationRepository;
            _environmentRepository = environmentRepository;
        }

        /// <summary>
        /// 创建应用信息
        /// </summary>
        /// <param name="model">应用信息</param>
        /// <param name="currentUserID">当前用户ID</param>
        /// <returns>应用信息</returns>
        public ApplicationInfo Create(ApplicationEditModel model, int currentUserID)
        {
            model.NotNull("应用信息不能为空");
            var applicationInfo = new ApplicationInfo
            {
                FCode = model.FCode,
                FComment = model.FComment,
                FCreateTime = DateTime.Now,
                FCreateUserID = currentUserID,
                FEnvironmentID = model.FEnvironmentID,
                FIsDeleted = false,
                FID = model.FID,
                FVersion = model.FVersion,
                FName = model.FName,
                FIsEnabled = model.FIsEnabled
            };
            if (model.FID > 0)
            {
                applicationInfo.FLaseModifyUserID = currentUserID;
                applicationInfo.FLastModifyTime = DateTime.Now;
            }
            return applicationInfo;
        }

        /// <summary>
        /// 校验是否可以新增或者修改
        /// </summary>
        /// <param name="info">应用信息</param>
        /// <returns></returns>
        public async Task CheckAsync(ApplicationInfo info)
        {
            info.NotNull("应用信息不能为空");
            info.FName.NotNullAndNotEmptyWhiteSpace("应用名称不能为空");
            info.FCode.NotNullAndNotEmptyWhiteSpace("编号不能为空");
            info.FEnvironmentID.GreaterThan(0, "所属环境不能为空");
            //修改时判断所属环境是否被修改过
            if (info.FID > 0)
            {
                var oldInfo = await _applicationRepository.GetInfoAsync(new { FID = info.FID, FIsDeleted = 0 });
                oldInfo.NotNull("应用信息不存在");
                if (oldInfo.FEnvironmentID != info.FEnvironmentID)
                {
                    throw new BizException("所属环境不能更换");
                }
            }
            //判断所属环境是否被删除
            var environmentInfo = await _environmentRepository.GetInfoAsync(new { FID = info.FEnvironmentID, FIsDeleted = 0 }, isWrite: true);
            environmentInfo.NotNull("所属环境信息错误");
            //判断当前环境内有无重复的名字与编号
            var existNameApplication = await _applicationRepository.GetInfoAsync(new { FEnvironmentID = info.FEnvironmentID, FName = info.FName, FIsDeleted = 0 }, isWrite: true);
            if (existNameApplication != null)
            {
                if (info.FID <= 0 || (info.FID > 0 && existNameApplication.FID != info.FID))
                {
                    throw new BizException($"名字【{info.FCode}】已存在");
                }
            }
            var existCodeApplication = await _applicationRepository.GetInfoAsync(new { FEnvironmentID = info.FEnvironmentID, FCode = info.FCode, FIsDeleted = 0 }, isWrite: true);
            if (existCodeApplication != null)
            {
                if (info.FID <= 0 || (info.FID > 0 && existCodeApplication.FID != info.FID))
                {
                    throw new BizException($"编号【{info.FCode}】已存在");
                }
            }
        }
    }
}