using System.Web.Mvc;

namespace JQ.Web.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：FilterContextExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：FilterContextExtension
    /// 创建标识：yjq 2017/7/31 22:41:36
    /// </summary>
    public static class FilterContextExtension
    {
        /// <summary>
        ///  确定指定的 HTTP 请求是否为 AJAX 请求。
        /// </summary>
        /// <param name="filterContext"></param>
        /// <exception cref=”System.ArgumentNullException”>抛出的异常情况</exception>
        /// <returns>如果指定的 HTTP 请求是 AJAX 请求，则为 true；否则为 false。</returns>
        public static bool IsAjaxRequest(this ControllerContext filterContext)
        {
            return filterContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}