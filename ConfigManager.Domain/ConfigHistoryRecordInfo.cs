using System;

namespace ConfigManager.Domain
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ConfigHistoryRecordInfo.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：配置信息历史记录
	/// 创建标识：template 2017-07-30 22:11:54
	/// </summary>
	public sealed class ConfigHistoryRecordInfo
	{
		/// <summary>
		/// 记录ID
		/// </summary>
		public int FID { get; set; }

		/// <summary>
		/// 配置值ID
		/// </summary>
		public int FConfigID { get; set; }

		/// <summary>
		/// 配置关系记录ID(T_Config_Map主键,同一个版本号只能有一条)
		/// </summary>
		public int FConfigMapID { get; set; }

		/// <summary>
		/// 版本号
		/// </summary>
		public string FVersion { get; set; }

		/// <summary>
		/// 配置类型(1:默认配置,2:负载均衡配置,3:故障转移)
		/// </summary>
		public int FType { get; set; }

		/// <summary>
		/// 配置Key
		/// </summary>
		public string FKey { get; set; }

		/// <summary>
		/// 配置值
		/// </summary>
		public string FValue { get; set; }

		/// <summary>
		/// 故障转移ID
		/// </summary>
		public int FFailOverID { get; set; }

		/// <summary>
		/// 负载均衡算法类型(1:轮询法,2:随机法,3:原地址哈希法,4:加权轮循法,5:加权随机发,6:最小连接数法)
		/// </summary>
		public int FLoadBalanceAlgorithmType { get; set; }

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
