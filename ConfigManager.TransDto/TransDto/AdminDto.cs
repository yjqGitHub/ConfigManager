using ConfigManager.Constant.EnumCollection;
using ConfigManager.Domain;
using System;

namespace ConfigManager.TransDto.TransDto
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AdminDto.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员传输对象
    /// 创建标识：yjq 2017/7/31 14:41:10
    /// </summary>
    public class AdminDto
    {
        public AdminDto()
        {
        }

        public AdminDto(AdminInfo adminInfo, AdminDetailInfo detailInfo) : this()
        {
            FID = adminInfo.FID;
            FName = adminInfo.FName;
            FUserName = adminInfo.FUserName;
            FMobile = adminInfo.FMobile;
            FState = adminInfo.FState;
            FLastLoginTime = detailInfo?.FLastLoginTime;
            FLastLoginIP = detailInfo?.FLastLoginIP;
            FLastLoginUserAgent = detailInfo?.FLastLoginUserAgent;
            FLastLoginPort = detailInfo?.FLastLoginPort;
            FLastLoginAddress = detailInfo?.FLastLoginAddress;
        }

        /// <summary>
        /// 管理员ID,主键、自增
        /// </summary>
        public int FID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public string FUserName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string FMobile { get; set; }

        /// <summary>
        /// 是否为超级管理员
        /// </summary>
        public bool FIsSuperAdmin { get; set; }

        /// <summary>
        /// 状态用户状态(0：启用，10：禁用)
        /// </summary>
        public AdminState FState { get; set; }

        /// <summary>
		/// 登录时间
		/// </summary>
		public DateTime? FLastLoginTime { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        public string FLastLoginIP { get; set; }

        /// <summary>
        /// 客户端信息
        /// </summary>
        public string FLastLoginUserAgent { get; set; }

        /// <summary>
        /// 登录端口(1:后台,2:IOS,3:Android,4:Wechat,9:其它)
        /// </summary>
        public WebSitePort? FLastLoginPort { get; set; }

        /// <summary>
        /// 登录地址
        /// </summary>
        public string FLastLoginAddress { get; set; }
    }
}