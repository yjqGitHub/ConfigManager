namespace ConfigManager.TransDto.QueryWhereDto
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ApplicationQueryWhereDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：应用分页查询条件
    /// 创建标识：yjq 2017/8/9 9:22:41
    /// </summary>
    public class ApplicationQueryWhereDto : BasePageQueryDto
    {
        /// <summary>
        /// 所属环境ID
        /// </summary>
        public int? EnvironmentID { get; set; }

        /// <summary>
        /// 应用编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 应用名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 应用版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 是否启用(1表示启用)
        /// </summary>
        public bool? FIsEnabled { get; set; }
    }
}