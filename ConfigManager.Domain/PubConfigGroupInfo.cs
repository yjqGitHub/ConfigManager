using System;

namespace ConfigManager.Domain
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：PubConfigGroupInfo.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：公共配置组信息
	/// 创建标识：template 2017-07-30 22:11:57
	/// </summary>
	public sealed class PubConfigGroupInfo
	{
		/// <summary>
		/// 配置组ID
		/// </summary>
		public int FID { get; set; }

		/// <summary>
		/// 配置组名字
		/// </summary>
		public string FName { get; set; }

		/// <summary>
		/// 编码（环境中唯一）
		/// </summary>
		public string FCode { get; set; }

		/// <summary>
		/// 所属环境
		/// </summary>
		public int FEnviromentID { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string FComment { get; set; }

		/// <summary>
		/// 是否启用(1表示启用)
		/// </summary>
		public bool FIsEnabled { get; set; }

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
