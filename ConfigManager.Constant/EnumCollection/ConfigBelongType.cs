using System.ComponentModel;

namespace ConfigManager.Constant.EnumCollection
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ConfigMapType.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：配置所属类型枚举
    /// 创建标识：yjq 2017/8/9 16:11:17
    /// </summary>
    public enum ConfigBelongType
    {
        /// <summary>
        /// 应用
        /// </summary>
        [Description("应用")]
        Application = 1,

        /// <summary>
        /// 配置组
        /// </summary>
        [Description("配置组")]
        PubConfigGroup = 2
    }
}