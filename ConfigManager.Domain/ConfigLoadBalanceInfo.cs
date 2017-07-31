using System;

namespace ConfigManager.Domain
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ConfigLoadBalanceInfo.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：配置负载均衡信息
	/// 创建标识：template 2017-07-30 22:11:55
	/// </summary>
	public sealed class ConfigLoadBalanceInfo
	{
		/// <summary>
		/// 负载均衡ID(主键、自增)
		/// </summary>
		public int FID { get; set; }

		/// <summary>
		/// 配置ID
		/// </summary>
		public int FConfigID { get; set; }

		/// <summary>
		/// 版本号
		/// </summary>
		public string FVersion { get; set; }

		/// <summary>
		/// 权重
		/// </summary>
		public int FWeight { get; set; }

		/// <summary>
		/// 配置值
		/// </summary>
		public string FValue { get; set; }

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
