using JQ.Redis;

namespace ConfigManager.Cache.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：CacheCommonUtil.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/31 15:37:55
    /// </summary>
    public static class CacheCommonUtil
    {
        public static RedisCacheOption GetRedisOption()
        {
            return new RedisCacheOption
            {
                ConnectionString = "localhost,password=yjq",
                DatabaseId = 2,
                Prefix = "ConfigManager"
            };
        }
    }
}