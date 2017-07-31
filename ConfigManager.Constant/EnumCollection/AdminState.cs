using System.ComponentModel;

namespace ConfigManager.Constant.EnumCollection
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AdminState.cs
    /// 类属性：枚举类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/31 14:42:46
    /// </summary>
    public enum AdminState
    {
        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Enable = 0,

        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disable = 1
    }
}