using ConfigManager.Constant.EnumCollection;
using System;

namespace ConfigManager.Domain
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AdminOperateLogInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员操作记录
    /// 创建标识：template 2017-07-31 11:57:46
    /// </summary>
    public sealed class AdminOperateLogInfo
    {
        /// <summary>
        /// 记录ID(主键、自增)
        /// </summary>
        public int FID { get; set; }

        /// <summary>
        /// 操作模块(枚举,1:用户,2:配置,3:发布,4:环境,5:项目)
        /// </summary>
        public BizType FBizType { get; set; }

        /// <summary>
        /// 操作内容
        /// </summary>
        public string FOperateContent { get; set; }

        /// <summary>
        /// 操作人IP
        /// </summary>
        public string FOperaterIP { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime FCreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int FCreateUserID { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? FLastModifyTime { get; set; }

        /// <summary>
        /// 最后修改人`
        /// </summary>
        public int? FLaseModifyUserID { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool FIsDeleted { get; set; }
    }
}