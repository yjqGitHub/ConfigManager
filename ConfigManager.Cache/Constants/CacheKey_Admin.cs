namespace ConfigManager.Cache
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：CacheKey_Admin.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：缓存的Key
    /// 创建标识：yjq 2017/7/31 16:06:54
    /// </summary>
    public partial class CacheKey
    {
        /// <summary>
        /// 用户尝试登录次数的Key
        /// </summary>
        public const string CAHCE_KEY_ADMIN_LOGIN_COUNT = "Admin_Login_{0}";

        /// <summary>
        /// 管理员信息Key
        /// </summary>
        public const string CAHCE_KEY_ADMIN_INFO = "AdminInfo";
    }
}