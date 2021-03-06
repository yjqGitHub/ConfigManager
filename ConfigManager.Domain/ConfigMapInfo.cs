﻿using ConfigManager.Constant.EnumCollection;
using System;

namespace ConfigManager.Domain
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：ConfigMapInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：环境、项目公共配置组与配置关系
    /// 创建标识：template 2017-07-30 22:11:55
    /// </summary>
    public sealed class ConfigMapInfo
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
        /// 创建人
        /// </summary>
        public int FCreateUserID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime FCreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? FLastModifyTime { get; set; }

        /// <summary>
        /// 最后修改人`
        /// </summary>
        public int? FLaseModifyUserID { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool FIsDeleted { get; set; }
    }
}