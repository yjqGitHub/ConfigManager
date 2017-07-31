using ConfigManager.Cache;
using ConfigManager.Constant.EnumCollection;
using ConfigManager.Domain;
using ConfigManager.Repository;
using ConfigManager.TransDto.TransDto;
using JQ;
using JQ.Extensions;
using JQ.Utils;
using JQ.Web;
using System;
using System.Threading.Tasks;

namespace ConfigManager.DomainService.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AdminDomainService.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员信息业务逻辑处理
    /// 创建标识：template 2017-07-30 22:11:49
    /// </summary>
    public sealed class AdminDomainService : IAdminDomainService
    {
        private readonly IAdminCache _adminCache;
        private readonly IAdminRepository _adminRepository;
        private readonly IAdminDetailRepository _adminDetailRepository;
        private readonly IAdminOperateLogDomainService _adminOperateLogDomainService;

        public AdminDomainService(IAdminCache adminCache, IAdminRepository adminRepository, IAdminDetailRepository adminDetailRepository, IAdminOperateLogDomainService adminOperateLogDomainService)
        {
            _adminCache = adminCache;
            _adminRepository = adminRepository;
            _adminDetailRepository = adminDetailRepository;
            _adminOperateLogDomainService = adminOperateLogDomainService;
        }

        #region 登录校验

        /// <summary>
        /// 异步登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="sitePort">端口</param>
        /// <returns>用户信息</returns>
        public async Task<AdminDto> LoginAsync(string userName, string pwd, WebSitePort sitePort)
        {
            var adminInfo = await _adminRepository.GetInfoAsync(new { FUserName = userName, FIsDeleted = 0 });
            ParameterCheckUtil.NotNull(adminInfo, "账号或密码错误");
            await CheckCanLoginAsync(adminInfo);
            await CheckPwdAsync(adminInfo, pwd);
            var adminDetailInfo = await _adminDetailRepository.GetInfoAsync(new { FAdminID = adminInfo.FID, FIsDeleted = 0 });
            await ChangeLastLoginAsync(adminInfo, sitePort);//更改上次登录信息
            var adminDto = new AdminDto(adminInfo, adminDetailInfo);
            await _adminCache.AddAdminInfoAsync(adminDto);//添加至缓存
            _adminOperateLogDomainService.AddOperateLog(BizType.User, "后台登录", adminInfo.FID);
            return adminDto;
        }

        /// <summary>
        /// 异步校验是否可以登录
        /// </summary>
        /// <param name="adminInfo">管理员信息</param>
        /// <returns></returns>
        private async Task CheckCanLoginAsync(AdminInfo adminInfo)
        {
            switch (adminInfo.FState)
            {
                case AdminState.Disable:
                    throw new BizException("用户已被禁用,请联系管理员");
                default: break;
            }
            //获取尝试登录的失败次数
            var tryLoginErrorCount = await _adminCache.GetTryLoginCountAsync(adminInfo.FID.ToString());
            if (tryLoginErrorCount >= 5)
            {
                LogUtil.Info($"{adminInfo.FID}:尝试登录次数超限");
                throw new BizException("尝试登录次数超限,请一分钟后在尝试");
            }
        }

        /// <summary>
        /// 校验密码
        /// </summary>
        /// <param name="adminInfo">管理员信息</param>
        /// <param name="pwd">要校验的密码</param>
        /// <returns></returns>
        private async Task CheckPwdAsync(AdminInfo adminInfo, string pwd)
        {
            string loginPwd = string.Concat(pwd, adminInfo.FPwdSalt).ToMd5();
            if (!adminInfo.FPwd.Equals(loginPwd))
            {
                //设置尝试登录失败次数
                await _adminCache.AddTryLoginCountAsync(adminInfo.FID.ToString());
                throw new BizException("账号或密码错误");
            }
        }

        /// <summary>
        /// 更改上次登录信息
        /// </summary>
        /// <param name="adminInfo">管理员信息</param>
        /// <param name="sitePort">登录站点</param>
        /// <returns></returns>
        private async Task ChangeLastLoginAsync(AdminInfo adminInfo, WebSitePort sitePort)
        {
            string ip = WebUtil.GetRealIP();
            await _adminDetailRepository.UpdateAsync(new
            {
                FLastModifyTime = DateTime.Now,
                FLoginIP = ip,
                FLoginPort = sitePort,
                FLoginTime = DateTime.Now,
                FUserAgent = WebUtil.GetUserAgent(),
                FLoginAddress = IpDataHelper.SearchLocation(ip)?.ToString()
            }, new { FUserID = adminInfo.FID, FIsDeleted = 0 });
        }

        #endregion 登录校验
    }
}