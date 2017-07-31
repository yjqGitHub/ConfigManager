using System;

namespace ConfigManager.Domain
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ApplicationPubConfigGroupMapInfo.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：应用程序与公共配置关系
	/// 创建标识：template 2017-07-30 22:11:52
	/// </summary>
	public sealed class ApplicationPubConfigGroupMapInfo
	{
		/// <summary>
		/// 记录ID
		/// </summary>
		public int FID { get; set; }

		/// <summary>
		/// 应用程序ID
		/// </summary>
		public int FApplicationID { get; set; }

		/// <summary>
		/// 基础公共配置组ID
		/// </summary>
		public int FPubConfigGroupID { get; set; }

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
