using ConfigManager.Constant.EnumCollection;
using System;

namespace ConfigManager.Domain
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AdminInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员信息
    /// 创建标识：template 2017-07-30 22:11:49
    /// </summary>
    public sealed class AdminInfo
    {
        /// <summary>
        /// 管理员ID(主键、自增)
        /// </summary>
        public int FID { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string FUserName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string FEmail { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string FMobile { get; set; }

        /// <summary>
        /// 密码盐值
        /// </summary>
        public string FPwdSalt { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string FPwd { get; set; }

        /// <summary>
        /// 是否为超级管理员
        /// </summary>
        public bool FIsSuperAdmin { get; set; }

        /// <summary>
        /// 用户状态(0:正常,1:禁用)
        /// </summary>
        public AdminState FState { get; set; }

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
    }
}