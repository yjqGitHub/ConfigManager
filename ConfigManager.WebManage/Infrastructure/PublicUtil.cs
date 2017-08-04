using JQ.Web;

namespace ConfigManager.WebManage.Infrastructure
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：PublicUtil.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：PublicUtil
    /// 创建标识：yjq 2017/7/31 22:03:01
    /// </summary>
    public static class PublicUtil
    {
        #region 当前管理员

        /// <summary>
        /// 当前用户的CookieKey
        /// </summary>
        private const string _CURRENT_ADMIN_COOKIE_KEY = "Admin";

        /// <summary>
        /// 用户签名盐值 TODO 动态配置
        /// </summary>
        private const string _CURRENT_ADMIN_SIGN_SALT = "7758258";

        /// <summary>
        /// 设置当前管理员
        /// </summary>
        /// <param name="adminID">用户ID</param>
        public static void SetCurrentAdmin(int adminID)
        {
            WebTool.SetCurrentAdmin(adminID, _CURRENT_ADMIN_COOKIE_KEY, _CURRENT_ADMIN_SIGN_SALT);
        }

        /// <summary>
        /// 获取当前管理员ID
        /// </summary>
        /// <returns>小于等于0表示未登录</returns>
        public static int GetCurrentAdminID()
        {
            return WebTool.GetCurrentAdminID(_CURRENT_ADMIN_COOKIE_KEY, _CURRENT_ADMIN_SIGN_SALT);
        }

        #endregion 当前管理员
    }
}