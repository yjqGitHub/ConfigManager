using JQ.Web.Extensions;
using JQ.Web.Result;
using System;
using System.Web.Mvc;

namespace ConfigManager.WebManage.Infrastructure
{
    /// <summary>
    /// Copyright (C) 2017 yjq ��Ȩ���С�
    /// ������LoginAttribute.cs
    /// �����ԣ������ࣨ�Ǿ�̬��
    /// �๦��������LoginAttribute
    /// ������ʶ��yjq 2017/7/31 22:13:47
    /// </summary>
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // ��MVCϵͳ�Դ��Ĺ��� ��ȡ��ǰ�����ϵ���������
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