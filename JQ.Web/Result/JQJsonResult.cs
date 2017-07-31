using JQ.Extensions;
using System;
using System.Text;
using System.Web.Mvc;

namespace JQ.Web.Result
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：JQJsonResult.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：自定义JSON返回类
    /// 创建标识：yjq 2017/7/31 13:35:01
    /// </summary>
    public sealed class JQJsonResult : JsonResult
    {
        public JQJsonResult()
        {
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        public JQJsonResult(object data)
            : this()
        {
            Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var response = context.HttpContext.Response;

            response.ContentType = ContentType.IsNotNullAndNotEmptyWhiteSpace() ? ContentType : "application/json";
            ContentEncoding = Encoding.UTF8;
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                response.Write(ResultUtil.Failed("不支持Get请求"));
            }
            else if (Data != null)
            {
                response.Write(Data.ToJson());
            }
        }
    }
}