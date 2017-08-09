using System;

namespace ConfigManager.TransDto.TransDto
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ApplicationDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/8/9 9:41:57
    /// </summary>
    public class ApplicationDto
    {
        /// <summary>
		/// 应用ID(主键、自增)
		/// </summary>
		public int FID { get; set; }

        /// <summary>
        /// 所属环境
        /// </summary>
        public int FEnvironmentID { get; set; }

        /// <summary>
        /// 环境名称
        /// </summary>
        public string FEnvironmentName { get; set; }

        /// <summary>
        /// 环境编号
        /// </summary>
        public string FEnvironmentCode { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// 编码(环境中唯一)
        /// </summary>
        public string FCode { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string FVersion { get; set; }

        /// <summary>
        /// 是否启用(1表示启用)
        /// </summary>
        public bool FIsEnabled { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string FComment { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? FLastModifyTime { get; set; }

        public string GetEnvironmentDesc()
        {
            return $"【名称：{FEnvironmentName},编号：{FEnvironmentCode}】";
        }
    }
}