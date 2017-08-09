using ConfigManager.Constant.EnumCollection;
using System;
using System.Collections.Generic;

namespace ConfigManager.TransDto.TransDto
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ConfigMapDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：配置Key信息传输对象
    /// 创建标识：yjq 2017/8/9 18:55:43
    /// </summary>
    public class ConfigMapDto
    {
        /// <summary>
        /// 记录ID(主键、自增)
        /// </summary>
        public int FID { get; set; }

        /// <summary>
        /// 所属环境
        /// </summary>
        public int FEnvironmentID { get; set; }

        /// <summary>
        /// 配置所属类型
        /// </summary>
        public ConfigBelongType FBelongType { get; set; }

        /// <summary>
        /// 所属ID
        /// </summary>
        public int FBelongID { get; set; }

        /// <summary>
        /// 配置Key(同一环境下，相同的应用或配置组不能重复)
        /// </summary>
        public string FKey { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string FComment { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime FLastModifyTime { get; set; }

        /// <summary>
        /// 配置列表
        /// </summary>
        public List<ConfigDto> ConfigList { get; set; }

        public void AddConfig(ConfigDto configDto)
        {
            if (configDto == null)
            {
                return;
            }
            if (ConfigList == null)
            {
                ConfigList = new List<TransDto.ConfigDto>();
            }
            ConfigList.Add(configDto);
        }
    }
}