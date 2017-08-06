using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ConfigManager.WebManage.Infrastructure
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：LableExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：LableExtension
    /// 创建标识：yjq 2017/8/6 15:00:10
    /// </summary>
    public static class LableExtension
    {
        public static MvcHtmlString EditLable(this HtmlHelper html, string lableText, string expression = null, bool isRequired = false)
        {
            var builder = new TagBuilder("lable");
            builder.MergeAttribute("class", "form-label col-xs-4 col-sm-2");
            if (isRequired)
            {
                builder.InnerHtml = $"<span class='c-red'>*</span>{lableText}：";
            }
            else
            {
                builder.InnerHtml = lableText;
            }
            if (!string.IsNullOrWhiteSpace(expression))
            {
                builder.MergeAttribute("id", expression);
                builder.MergeAttribute("name", expression);
            }
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}
