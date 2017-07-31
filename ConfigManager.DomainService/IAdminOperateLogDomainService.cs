using ConfigManager.Constant.EnumCollection;

namespace ConfigManager.DomainService
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：IAdminOperateLogDomainService.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员操作记录领域服务接口
    /// 创建标识：template 2017-07-31 11:57:46
    /// </summary>
    public interface IAdminOperateLogDomainService
    {
        /// <summary>
        /// 添加操作信息
        /// </summary>
        /// <param name="bizType">业务类型</param>
        /// <param name="operateContent">操作内容</param>
        /// <param name="operateUserID">操作人</param>
        void AddOperateLog(BizType bizType, string operateContent, int operateUserID);
    }
}