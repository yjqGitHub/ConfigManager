using ConfigManager.Constant.EnumCollection;
using System;

namespace ConfigManager.TransDto.TransModel
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ConfigDeatilModel.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：配置详情
    /// 创建标识：yjq 2017/8/10 10:41:30
    /// </summary>
    public class ConfigDeatilModel
    {
        /// <summary>
        /// 记录ID(主键、自增)
        /// </summary>
        public int FID { get; set; }

        /// <summary>
        /// 配置关系记录ID(T_Config_Map主键,同一个版本号只能有一条)
        /// </summary>
        public int FConfigMapID { get; set; }

        /// <summary>
        /// 配置类型(1:默认配置,2:负载均衡配置,3:故障转移)
        /// </summary>
        public ConfigType FType { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string FVersion { get; set; }

        /// <summary>
        /// 配置值
        /// </summary>
        public string FValue { get; set; }

        /// <summary>
        /// 故障转移ID
        /// </summary>
        public int FFailOverID { get; set; }

        /// <summary>
        /// 负载均衡算法类型(1:轮询法,2:随机法,3:源地址哈希法,4:加权轮循法,5:加权随机法,6:最小连接数法)
        /// </summary>
        public LoadBalanceAlgorithmType FLoadBalanceAlgorithmType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string FComment { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime FLastModifyTime { get; set; }
    }
}