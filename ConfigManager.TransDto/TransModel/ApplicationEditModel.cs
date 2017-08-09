using System.ComponentModel.DataAnnotations;

namespace ConfigManager.TransDto.TransModel
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ApplicationEditModel.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：应用编辑信息
    /// 创建标识：yjq 2017/8/9 11:03:24
    /// </summary>
    public class ApplicationEditModel
    {
        /// <summary>
        /// 配置组ID
        /// </summary>
        public int FID { get; set; }

        /// <summary>
        /// 配置组名字
        /// </summary>
        [Required(ErrorMessage = "名字不能为空")]
        [StringLength(50, ErrorMessage = "名字最长为50")]
        public string FName { get; set; }

        /// <summary>
        /// 编码（环境中唯一）
        /// </summary>
        [Required(ErrorMessage = "编码不能为空")]
        [StringLength(50, ErrorMessage = "编码最长为50")]
        public string FCode { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [StringLength(15, ErrorMessage = "版本号最长为15")]
        public string FVersion { get; set; }

        /// <summary>
        /// 是否启用(1表示启用)
        /// </summary>
        public bool FIsEnabled { get; set; }

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
        [StringLength(50, ErrorMessage = "备注最长为50")]
        public string FComment { get; set; }

        /// <summary>
        /// 创建配置组信息
        /// </summary>
        /// <param name="environmentID">环境ID</param>
        /// <param name="environmentName">环境名称</param>
        /// <param name="environmentCode">环境编号</param>
        /// <returns></returns>
        public static ApplicationEditModel Create(int environmentID, string environmentName, string environmentCode)
        {
            return new ApplicationEditModel
            {
                FEnvironmentName = environmentName,
                FEnvironmentCode = environmentCode,
                FEnvironmentID = environmentID
            };
        }
    }
}