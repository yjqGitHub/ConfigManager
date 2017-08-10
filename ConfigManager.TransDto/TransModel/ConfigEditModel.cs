using ConfigManager.Constant.EnumCollection;
using System.Collections.Generic;

namespace ConfigManager.TransDto.TransModel
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ConfigEditModel.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：配置编辑信息
    /// 创建标识：yjq 2017/8/10 10:32:05
    /// </summary>
    public class ConfigEditModel
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
        /// 环境名称
        /// </summary>
        public string FEnvironmentName { get; set; }

        /// <summary>
        /// 环境编号
        /// </summary>
        public string FEnvironmentCode { get; set; }

        /// <summary>
        /// 配置所属类型
        /// </summary>
        public ConfigBelongType FBelongType { get; set; }

        /// <summary>
        /// 所属名字
        /// </summary>
        public string FBelongName { get; set; }

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
        /// 配置列表
        /// </summary>
        public List<ConfigDeatilModel> ConfigList { get; set; } = new List<ConfigDeatilModel>();

        /// <summary>
        /// 添加配置信息
        /// </summary>
        /// <param name="configDto"></param>
        public void AddConfig(ConfigDeatilModel configDto)
        {
            if (configDto == null)
            {
                return;
            }
            if (ConfigList == null)
            {
                ConfigList = new List<ConfigDeatilModel>();
            }
            ConfigList.Add(configDto);
        }
    }
}