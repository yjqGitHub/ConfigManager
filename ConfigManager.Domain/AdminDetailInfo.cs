using ConfigManager.Constant.EnumCollection;
using System;

namespace ConfigManager.Domain
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AdminDetailInfo.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员详细信息
    /// 创建标识：template 2017-07-31 11:57:45
    /// </summary>
    public sealed class AdminDetailInfo
    {
        /// <summary>
        /// 管理员ID（管理员表主键）
        /// </summary>
        public int FAdminID { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? FLastLoginTime { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string FLastLoginIP { get; set; }

        /// <summary>
        /// 最后登录端口(1:后台,2:IOS,3:Android,4:Wechat,9:其它)
        /// </summary>
        public WebSitePort? FLastLoginPort { get; set; }

        /// <summary>
        /// 最后登录地址
        /// </summary>
        public string FLastLoginAddress { get; set; }

        /// <summary>
        /// 最后登录客户端信息
        /// </summary>
        public string FLastLoginUserAgent { get; set; }

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
        /// 最后修改人
        /// </summary>
        public int? FLaseModifyUserID { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool FIsDeleted { get; set; }
    }
}