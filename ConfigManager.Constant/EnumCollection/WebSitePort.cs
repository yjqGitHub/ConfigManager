using System.ComponentModel;

namespace ConfigManager.Constant.EnumCollection
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：WebSitePort.cs
    /// 类属性：枚举类（非静态）
    /// 类功能描述：站点端口
    /// 创建标识：yjq 2017/7/31 14:47:49
    /// </summary>
    public enum WebSitePort
    {
        /// <summary>
        /// WebManage
        /// </summary>
        [Description("WebManage")]
        WebManage = 1,

        /// <summary>
        /// IOS
        /// </summary>
        [Description("IOS")]
        IOS = 2,

        /// <summary>
        /// Android
        /// </summary>
        [Description("Android")]
        Android = 3,

        /// <summary>
        /// Wechat
        /// </summary>
        [Description("Wechat")]
        Wechat = 4,

        /// <summary>
        /// 其它
        /// </summary>
        [Description("其它")]
        Other = 9
    }
}