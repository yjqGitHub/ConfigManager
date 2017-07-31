using JQ.Extensions;
using System;

namespace JQ.Web
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：WebTool.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：公共帮助类
    /// 创建标识：yjq 2017/7/31 13:28:01
    /// </summary>
    public static class WebTool
    {
        #region 验证码

        /// <summary>
        /// 设置验证码
        /// </summary>
        /// <param name="codeValue">验证码值</param>
        /// <param name="cookieKey">验证码的Key</param>
        /// <param name="salt">验证码加密盐值</param>
        public static void SetCode(string codeValue, string cookieKey, string salt)
        {
            CookieUtil.SetCookie(cookieKey, (codeValue + salt).ToMd5(), DateTime.Now.AddMinutes(2));
        }

        /// <summary>
        /// 检验验证码是否正确
        /// </summary>
        /// <param name="codeValue">验证码值</param>
        /// <param name="cookieKey">验证码的Key</param>
        /// <param name="salt">验证码加密盐值</param>
        /// <returns>正确返回true</returns>
        public static bool CheckCode(string codeValue, string cookieKey, string salt)
        {
            string savedCodeValue = CookieUtil.GetCookieValue(cookieKey);
            if (codeValue.IsNullOrEmptyWhiteSpace())
            {
                return false;
            }
            return string.Equals(savedCodeValue, (codeValue + salt).ToMd5());
        }

        #endregion 验证码
    }
}