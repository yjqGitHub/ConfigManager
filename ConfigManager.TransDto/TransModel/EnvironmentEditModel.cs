using System.ComponentModel.DataAnnotations;

namespace ConfigManager.TransDto.TransModel
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：EnvironmentAddModel.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：EnvironmentAddModel
    /// 创建标识：yjq 2017/8/6 15:27:06
    /// </summary>
    public class EnvironmentEditModel
    {
        /// <summary>
		/// 环境ID(主键、自增)
		/// </summary>
		public int FID { get; set; }

        /// <summary>
        /// 环境名称
        /// </summary>
        [Required(ErrorMessage = "环境名称不能为空")]
        [StringLength(50, ErrorMessage = "名称最长为50")]
        public string FName { get; set; }

        /// <summary>
        /// 编码(全局唯一)
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        [StringLength(50, ErrorMessage = "编码最长为50")]
        public string FCode { get; set; }

        /// <summary>
        /// 配置访问密钥
        /// </summary>
        [StringLength(50, ErrorMessage = "密钥最长为50")]
        public string FSecret { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string FComment { get; set; }
    }
}