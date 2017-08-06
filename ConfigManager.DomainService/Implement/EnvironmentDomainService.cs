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
    /// 类名：EnvironmentDomainService.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：环境信息业务逻辑处理
    /// 创建标识：template 2017-07-30 22:11:56
    /// </summary>
    public sealed class EnvironmentDomainService : IEnvironmentDomainService
    {
        private readonly IEnvironmentRepository _environmentRepository;

        public EnvironmentDomainService(IEnvironmentRepository environmentRepository)
        {
            _environmentRepository = environmentRepository;
        }

        /// <summary>
        /// 创建环境信息
        /// </summary>
        /// <param name="model">添加信息</param>
        /// <param name="currentUserID">当前用户信息</param>
        /// <returns>环境信息</returns>
        public EnvironmentInfo Create(EnvironmentAddModel model, int currentUserID)
        {
            model.NotNull("环境信息不能为空");
            return new EnvironmentInfo
            {
                FCode = model.FCode,
                FComment = model.FComment,
                FCreateTime = DateTime.Now,
                FCreateUserID = currentUserID,
                FIsDeleted = false,
                FName = model.FName,
                FSecret = model.FSecret
            };
        }

        /// <summary>
        /// 异步判断是否可以新增
        /// </summary>
        /// <param name="info">环境信息</param>
        /// <returns></returns>
        public async Task CheckAsync(EnvironmentInfo info)
        {
            info.NotNull("环境信息不能为空");
            info.FName.NotNullAndNotEmptyWhiteSpace("环境名称不能为空");
            info.FCode.NotNullAndNotEmptyWhiteSpace("编号不能为空");
            //判断是否存在相同的code
            var existesInfo = await _environmentRepository.GetInfoAsync(new { FCode = info.FCode, FIsDeleted = 0 }, isWrite: true);
            if (existesInfo != null)
            {
                if (info.FID <= 0 || (info.FID > 0 && existesInfo.FID != info.FID))
                {
                    throw new BizException($"编号【{info.FCode}】已存在");
                }
            }
        }
    }
}