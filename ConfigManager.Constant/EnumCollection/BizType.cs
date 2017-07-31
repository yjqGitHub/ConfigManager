using System.ComponentModel;

namespace ConfigManager.Constant.EnumCollection
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：BizType.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：业务类型枚举
    /// 创建标识：yjq 2017/7/31 18:16:34
    /// </summary>
    public enum BizType
    {
        /// <summary>
        /// 用户
        /// </summary>
        [Description("用户")]
        User = 1,

        /// <summary>
        /// 配置
        /// </summary>
        [Description("配置")]
        Config = 2,

        /// <summary>
        /// 发布
        /// </summary>
        [Description("发布")]
        Release = 3,

        /// <summary>
        /// 环境
        /// </summary>
        [Description("环境")]
        Enviroment = 4,

        /// <summary>
        /// 项目
        /// </summary>
        [Description("项目")]
        Application = 5
    }
}