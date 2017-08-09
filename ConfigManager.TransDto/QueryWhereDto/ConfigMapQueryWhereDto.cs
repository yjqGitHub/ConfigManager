using ConfigManager.Constant.EnumCollection;

namespace ConfigManager.TransDto.QueryWhereDto
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ConfigMapQueryWhereDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：配置值的查询条件
    /// 创建标识：yjq 2017/8/9 15:35:52
    /// </summary>
    public class ConfigMapQueryWhereDto
    {
        /// <summary>
        /// 所属类型
        /// </summary>
        public ConfigBelongType? BelongType { get; set; }

        /// <summary>
        /// 所属ID
        /// </summary>
        public int BelongID { get; set; }

        /// <summary>
        /// Key的名字
        /// </summary>
        public string KeyName { get; set; }
    }
}