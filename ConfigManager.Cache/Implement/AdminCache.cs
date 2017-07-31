using ConfigManager.Repository;
using ConfigManager.TransDto.TransDto;
using JQ.Redis;
using System;
using System.Threading.Tasks;

namespace ConfigManager.Cache.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AdminCache.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员缓存
    /// 创建标识：yjq 2017/7/31 16:05:22
    /// </summary>
    public class AdminCache : RedisBaseRepository, IAdminCache
    {
        private readonly IAdminRepository _adminRepository;

        public AdminCache(IRedisDatabaseProvider databaseProvider, IAdminRepository adminRepository) : base(databaseProvider, CacheCommonUtil.GetRedisOption())
        {
            _adminRepository = adminRepository;
        }

        /// <summary>
        /// 异步设置登录失败次数
        /// </summary>
        /// <param name="userName">要设置的用户名</param>
        /// <returns></returns>
        public async Task<long> AddTryLoginCountAsync(string userName)
        {
            return await SetValueAsync(async () =>
            {
                string key = string.Format(CacheKey.CAHCE_KEY_ADMIN_LOGIN_COUNT, userName);
                var count = await RedisClient.StringIncrementAsync(key);
                await RedisClient.ExpireAsync(key, TimeSpan.FromMinutes(1));
                return count;
            }, 0, "AdminCache-AddLoginFailedCountAsync");
        }

        /// <summary>
        /// 异步获取登录失败次数
        /// </summary>
        /// <param name="userName">要获取的用户名</param>
        /// <returns>失败次数</returns>
        public Task<long> GetTryLoginCountAsync(string userName)
        {
            return GetValueAsync(() =>
            {
                return RedisClient.StringGetAsync<long>(string.Format(CacheKey.CAHCE_KEY_ADMIN_LOGIN_COUNT, userName));
            }, 0, memberName: "AdminCache-GetLoginFailedCountAsync");
        }

        /// <summary>
        /// 异步添加管理员信息缓存(1小时之内无访问则过期)
        /// </summary>
        /// <param name="adminInfo">管理员信息</param>
        /// <returns>异步，可等待</returns>
        public async Task AddAdminInfoAsync(AdminDto adminInfo)
        {
            if (adminInfo != null)
            {
                await SetValueAsync(async () =>
                {
                    await RedisClient.HashSetAsync(CacheKey.CAHCE_KEY_ADMIN_INFO, adminInfo.FID.ToString(), adminInfo);
                    await RedisClient.ExpireAsync(CacheKey.CAHCE_KEY_ADMIN_INFO, TimeSpan.FromHours(1));
                }, memberName: "AdminCache-AddAdminInfoAsync");
            }
        }

        /// <summary>
        /// 异步获取管理员信息
        /// </summary>
        /// <param name="adminId">管理员ID</param>
        /// <returns>管理员信息</returns>
        public async Task<AdminDto> GetAdminInfoAsync(int adminId)
        {
            return await GetValueWhenNotExitThenSetAsync(CacheKey.CAHCE_KEY_ADMIN_INFO, async (key) =>
            {
                var adminInfo = await RedisClient.HashGetAsync<AdminDto>(key, adminId.ToString());
                return adminInfo;
            }, async (key, value) =>
            {
                await RedisClient.HashSetAsync(key, value?.FID.ToString(), value);
                await RedisClient.ExpireAsync(key, TimeSpan.FromHours(1));
            }, async () =>
            {
                return await _adminRepository.GetAdminTransInfo(adminId);
            }
            , memberName: "AdminCache-GetAdminInfoAsync");
        }
    }
}