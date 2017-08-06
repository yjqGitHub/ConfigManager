using JQ.Web.Extensions;
using JQ.Web.Result;
using System;
using System.Web.Mvc;

namespace ConfigManager.WebManage.Infrastructure
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：LoginAttribute.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：LoginAttribute
    /// 创建标识：yjq 2017/7/31 22:13:47
    /// </summary>
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 用MVC系统自带的功能 获取当前方法上的特性名称
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(NoNeedLoginAttribute), inherit: true)
                                     || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(NoNeedLoginAttribute), inherit: true);
            if (skipAuthorization)
            {
                return;
            }

            if (PublicUtil.GetCurrentAdminID() <= 0)
            {
                if (filterContext.IsAjaxRequest())
                {
                    filterContext.Result = ResultUtil.NoLogin("/Account/Login");
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Account/Login", true);
                }
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class NoNeedLoginAttribute : Attribute
    {
    }
}