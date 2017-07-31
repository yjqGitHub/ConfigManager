namespace JQ.Web.Result
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AjaxState.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：Ajax返回值枚举
    /// 创建标识：yjq 2017/7/31 13:31:35
    /// </summary>
    public enum AjaxState
    {
        /// <summary>
        /// 失败
        /// </summary>
        Failed = 0,

        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,

        /// <summary>
        /// 未登录
        /// </summary>
        NoLogin = 1000
    }
}