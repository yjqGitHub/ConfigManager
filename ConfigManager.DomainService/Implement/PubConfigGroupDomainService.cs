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
    /// 类名：PubConfigGroupDomainService.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：公共配置组信息业务逻辑处理
    /// 创建标识：template 2017-07-30 22:11:57
    /// </summary>
    public sealed class PubConfigGroupDomainService : IPubConfigGroupDomainService
    {
        private readonly IPubConfigGroupRepository _pubConfigGroupRepository;
        private readonly IEnvironmentRepository _environmentRepository;

        public PubConfigGroupDomainService(IPubConfigGroupRepository pubConfigGroupRepository, IEnvironmentRepository environmentRepository)
        {
            _pubConfigGroupRepository = pubConfigGroupRepository;
            _environmentRepository = environmentRepository;
        }

        /// <summary>
        /// 创建组信息
        /// </summary>
        /// <param name="model">组信息</param>
        /// <param name="currentUserID">当前用户ID</param>
        /// <returns>组信息</returns>
        public PubConfigGroupInfo Create(PubConfigGroupEditModel model, int currentUserID)
        {
            model.NotNull("配置组信息不能为空");
            var groupInfo = new PubConfigGroupInfo
            {
                FCode = model.FCode,
                FComment = model.FComment,
                FCreateTime = DateTime.Now,
                FCreateUserID = currentUserID,
                FEnvironmentID = model.FEnvironmentID,
                FIsDeleted = false,
                FID = model.FID,
                FIsEnabled = model.FIsEnabled,
                FName = model.FName
            };
            if (model.FID > 0)
            {
                groupInfo.FLaseModifyUserID = currentUserID;
                groupInfo.FLastModifyTime = DateTime.Now;
            }
            return groupInfo;
        }

        /// <summary>
        /// 异步判断是否可以新增或修改
        /// </summary>
        /// <param name="info">组信息</param>
        /// <returns></returns>
        public async Task CheckAsync(PubConfigGroupInfo info)
        {
            info.NotNull("配置组信息不能为空");
            info.FName.NotNullAndNotEmptyWhiteSpace("配置组名称不能为空");
            info.FCode.NotNullAndNotEmptyWhiteSpace("编号不能为空");
            info.FEnvironmentID.GreaterThan(0, "所属环境不能为空");
            //修改时判断所属环境是否被修改过
            if (info.FID > 0)
            {
                var oldInfo = await _pubConfigGroupRepository.GetInfoAsync(new { FID = info.FID, FIsDeleted = 0 });
                oldInfo.NotNull("配置组信息不存在");
                if (oldInfo.FEnvironmentID != info.FEnvironmentID)
                {
                    throw new BizException("所属环境不能更换");
                }
            }

            //判断所属环境是否被删除
            var environmentInfo = await _environmentRepository.GetInfoAsync(new { FID = info.FEnvironmentID, FIsDeleted = 0 }, isWrite: true);
            environmentInfo.NotNull("所属环境信息错误");
            //判断当前环境内有无重复的名字与编号
            var existNameGroup = await _pubConfigGroupRepository.GetInfoAsync(new { FEnvironmentID = info.FEnvironmentID, FName = info.FName, FIsDeleted = 0 }, isWrite: true);
            if (existNameGroup != null)
            {
                if (info.FID <= 0 || (info.FID > 0 && existNameGroup.FID != info.FID))
                {
                    throw new BizException($"名字【{info.FCode}】已存在");
                }
            }
            var existCodeGroup = await _pubConfigGroupRepository.GetInfoAsync(new { FEnvironmentID = info.FEnvironmentID, FCode = info.FCode, FIsDeleted = 0 }, isWrite: true);
            if (existCodeGroup != null)
            {
                if (info.FID <= 0 || (info.FID > 0 && existCodeGroup.FID != info.FID))
                {
                    throw new BizException($"编号【{info.FCode}】已存在");
                }
            }
        }
    }
}