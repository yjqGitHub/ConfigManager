using System;

namespace ConfigManager.Domain
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：AdminEnviromentRoleInfo.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：管理员对应环境权限信息
	/// 创建标识：template 2017-07-30 22:11:50
	/// </summary>
	public sealed class AdminEnvironmentRoleInfo
	{
		/// <summary>
		/// 记录ID
		/// </summary>
		public int FID { get; set; }

		/// <summary>
		/// 管理员ID
		/// </summary>
		public int FAdminID { get; set; }

		/// <summary>
		/// 环境ID
		/// </summary>
		public int FEnvironmentID { get; set; }

		/// <summary>
		/// 创建人ID
		/// </summary>
		public int FCreateUserID { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime FCreateTime { get; set; }

		/// <summary>
		/// 最后修改人
		/// </summary>
		public int? FLastModifyUserID { get; set; }

		/// <summary>
		/// 最后修改时间
		/// </summary>
		public DateTime? FLastModifyTime { get; set; }

	}
}
