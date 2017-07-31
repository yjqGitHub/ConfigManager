using JQ.Configurations;
using JQ.Redis.StackExchangeRedis;

namespace JQ.Redis
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：RedisConfigurationExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/15 20:34:01
    /// </summary>
    public static class RedisConfigurationExtension
    {
        /// <summary>
        /// 使用Redis
        /// </summary>
        /// <param name="config">配置信息</param>
        /// <returns></returns>
        public static Configuration UseRedis(this Configuration config)
        {
            config.AddUnInStallAction(() => ConnectionMultiplexerFactory.DisposeConn());
            return config;
        }
    }
}