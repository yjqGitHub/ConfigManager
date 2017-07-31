using System;

namespace ConfigManager.Domain
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ConfigOperateLogInfo.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：配置操作记录
	/// 创建标识：template 2017-07-30 22:11:56
	/// </summary>
	public sealed class ConfigOperateLogInfo
	{
		/// <summary>
		/// 记录ID
		/// </summary>
		public int FID { get; set; }

		/// <summary>
		/// 配置ID
		/// </summary>
		public int FConfigID { get; set; }

		/// <summary>
		/// 操作内容
		/// </summary>
		public string FOperareContent { get; set; }

		/// <summary>
		/// 操作类型(1:新增、2:修改、3:删除、4:发布)
		/// </summary>
		public int FOperateType { get; set; }

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
