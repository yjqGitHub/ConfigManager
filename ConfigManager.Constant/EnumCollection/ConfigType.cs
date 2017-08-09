using System.ComponentModel;

namespace ConfigManager.Constant.EnumCollection
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ConfigType.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：配置类型枚举
    /// 创建标识：yjq 2017/8/9 19:12:49
    /// </summary>
    public enum ConfigType
    {
        /// <summary>
        /// 默认
        /// </summary>
        [Description("默认")]
        Default = 1,

        /// <summary>
        /// 负载均衡
        /// </summary>
        [Description("负载均衡")]
        LoadBalance = 2,

        /// <summary>
        /// 故障转移
        /// </summary>
        [Description("故障转移")]
        FailOver = 3
    }
}