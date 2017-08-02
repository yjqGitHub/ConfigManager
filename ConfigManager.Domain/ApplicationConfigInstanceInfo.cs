using System;

namespace ConfigManager.Domain
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ApplicationConfigInstanceInfo.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：当前应用配置信息
	/// 创建标识：template 2017-07-30 22:11:51
	/// </summary>
	public sealed class ApplicationConfigInstanceInfo
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
		/// 应用ID
		/// </summary>
		public int FApplicationID { get; set; }

		/// <summary>
		/// 配置内容
		/// </summary>
		public string FConfigContent { get; set; }

		/// <summary>
		/// 发布记录ID
		/// </summary>
		public int FReleaseRecordID { get; set; }

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
