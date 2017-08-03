using System;

namespace ConfigManager.TransDto.TransDto
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：EnvironmentDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：环境传输对象
    /// 创建标识：yjq 2017/8/3 20:55:32
    /// </summary>
    public class EnvironmentDto
    {
        /// <summary>
        /// 环境ID(主键、自增)
        /// </summary>
        public int FID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// 编码(全局唯一)
        /// </summary>
        public string FCode { get; set; }

        /// <summary>
        /// 配置访问密钥
        /// </summary>
        public string FSecret { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string FComment { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? FLastModifyTime { get; set; }
    }
}