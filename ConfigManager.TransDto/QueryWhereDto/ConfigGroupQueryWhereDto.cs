namespace ConfigManager.TransDto.QueryWhereDto
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ConfigGroupQueryWhereDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：配置组查询条件对象
    /// 创建标识：yjq 2017/8/8 15:28:37
    /// </summary>
    public class ConfigGroupQueryWhereDto : BasePageQueryDto
    {
        /// <summary>
        /// 所属环境ID
        /// </summary>
        public int? EnvironmentID { get; set; }

        /// <summary>
        /// 配置组编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 配置组名字
        /// </summary>
        public string Name { get; set; }
    }
}