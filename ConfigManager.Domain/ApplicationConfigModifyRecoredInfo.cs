using System;

namespace ConfigManager.Domain
{
	/// <summary>
	/// Copyright (C) 2015 备胎 版权所有。
	/// 类名：ApplicationConfigModifyRecoredInfo.cs
	/// 类属性：公共类（非静态）
	/// 类功能描述：应用更新配置记录
	/// 创建标识：template 2017-07-30 22:11:52
	/// </summary>
	public sealed class ApplicationConfigModifyRecoredInfo
	{
		/// <summary>
		/// 记录ID
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
		/// 版本号
		/// </summary>
		public string FVersion { get; set; }

		/// <summary>
		/// 获取类型(1:主动获取,2::服务端更新通知后获取)
		/// </summary>
		public int FGetType { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime FCreateTime { get; set; }

		/// <summary>
		/// 最后修改时间
		/// </summary>
		public DateTime? FLastModifyTime { get; set; }

		/// <summary>
		/// 是否已删除
		/// </summary>
		public bool FIsDeleted { get; set; }

	}
}
