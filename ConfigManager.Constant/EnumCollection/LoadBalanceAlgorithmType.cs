using System.ComponentModel;

namespace ConfigManager.Constant.EnumCollection
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：LoadBalanceAlgorithmType.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：负载均衡算法枚举
    /// 创建标识：yjq 2017/8/9 19:16:06
    /// </summary>
    public enum LoadBalanceAlgorithmType
    {
        /// <summary>
        /// 轮询法
        /// </summary>
        [Description("轮询法")]
        Polling = 1,

        /// <summary>
        /// 随机法
        /// </summary>
        [Description("随机法")]
        Random = 2,

        /// <summary>
        /// 源地址哈希法
        /// </summary>
        [Description("源地址哈希法")]
        SourceHash = 3,

        /// <summary>
        /// 加权轮循法
        /// </summary>
        [Description("加权轮循法")]
        WeightPolling = 4,

        /// <summary>
        /// 加权随机法
        /// </summary>
        [Description("加权随机法")]
        WeightRandom = 5,

        /// <summary>
        /// 最小连接数法
        /// </summary>
        [Description("最小连接数法")]
        LeatConnection = 6
    }
}