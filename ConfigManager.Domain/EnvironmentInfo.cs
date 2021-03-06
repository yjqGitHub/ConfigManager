﻿using System;

namespace ConfigManager.Domain
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：EnvironmentInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：环境信息
    /// 创建标识：template 2017-07-30 22:11:56
    /// </summary>
    public sealed class EnvironmentInfo
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
        /// 排列顺序
        /// </summary>
        public int FOrderIndex { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime FCreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int FCreateUserID { get; set; }

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

        public string GetDescription()
        {
            string idText = FID > 0 ? "FID:" + FID.ToString() : string.Empty;
            return $"环境【{idText}名称：{FName},编号：{FCode}】";
        }
    }
}