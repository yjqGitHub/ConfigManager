using System;

namespace ConfigManager.Domain
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ReleaseInfo.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：发布内容
	/// 创建标识：template 2017-07-30 22:11:57
	/// </summary>
	public sealed class ReleaseInfo
	{
		/// <summary>
		/// 记录ID(主键、自增)
		/// </summary>
		public int FID { get; set; }

		/// <summary>
		/// 发布记录ID（相同记录表示同义次发布）
		/// </summary>
		public int FReleaseRecordID { get; set; }

		/// <summary>
		/// 环境ID
		/// </summary>
		public int FEnvironmentID { get; set; }

		/// <summary>
		/// 项目ID
		/// </summary>
		public int FApplicationID { get; set; }

		/// <summary>
		/// 配置组ID
		/// </summary>
		public int FConfigGroupID { get; set; }

		/// <summary>
		/// 发布内容
		/// </summary>
		public string FReleaseContent { get; set; }

		/// <summary>
		/// 是否废弃(被回滚则视为废弃)
		/// </summary>
		public bool FIsAbandoned { get; set; }

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
