using System;

namespace ConfigManager.Domain
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ReleaseRecordInfo.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：发布记录
	/// 创建标识：template 2017-07-30 22:11:58
	/// </summary>
	public sealed class ReleaseRecordInfo
	{
		/// <summary>
		/// 记录ID（主键、自增）
		/// </summary>
		public int FID { get; set; }

		/// <summary>
		/// 环境ID
		/// </summary>
		public int FEnvironmentID { get; set; }

		/// <summary>
		/// 是否废弃（回滚则视为废弃）
		/// </summary>
		public bool FIsAbandoned { get; set; }

		/// <summary>
		/// 前一次发布记录ID（未被回滚的,第一次发布则为空）
		/// </summary>
		public int? FPreviousReleaseId { get; set; }

		/// <summary>
		/// 发布类型（1:普通发布,2:回滚发布）
		/// </summary>
		public int FReleaseType { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string FComment { get; set; }

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
