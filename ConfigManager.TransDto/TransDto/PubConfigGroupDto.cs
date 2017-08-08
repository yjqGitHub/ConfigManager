using System;

namespace ConfigManager.TransDto.TransDto
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：PubConfigGroupDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：公共配置组传输对象
    /// 创建标识：yjq 2017/8/8 15:40:59
    /// </summary>
    public class PubConfigGroupDto
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
        /// 备注
        /// </summary>
        public string FComment { get; set; }

        /// <summary>
        /// 是否启用(1表示启用)
        /// </summary>
        public bool FIsEnabled { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime FLastModifyTime { get; set; }

        public string GetEnvironmentDesc()
        {
            return $"【名称：{FEnvironmentName},编号：{FEnvironmentCode}】";
        }
    }
}