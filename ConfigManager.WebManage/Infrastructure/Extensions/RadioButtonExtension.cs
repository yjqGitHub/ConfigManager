using JQ.Utils;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using JQ.Extensions;

namespace ConfigManager.WebManage.Infrastructure
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：RadioButtonExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：RadioButtonExtension
    /// 创建标识：yjq 2017/8/10 13:27:35
    /// </summary>
    public static class RadioButtonExtension
    {
        /// <summary>
        /// 列出枚举单选列表
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">表达式</param>
        /// <returns>枚举单选列表</returns>
        public static MvcHtmlString EnumRadioButtionFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var type = expression?.ReturnType.GetTrueType();
            if (type != null && type.IsEnum)
            {
                var enumValues = EnumUtil.GetDesc(type);
                StringBuilder htmlBuilder = new StringBuilder();
                foreach (var item in enumValues)
                {
                    htmlBuilder.AppendFormat("{0} {1} ", htmlHelper.RadioButtonFor(expression, Enum.Parse(type, item.Key)), item.Value);
                }
                return MvcHtmlString.Create(htmlBuilder.ToString());
            }
            return MvcHtmlString.Create(string.Empty);
        }

        /// <summary>
        /// 列出枚举单选列表
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">表达式</param>
        /// <param name="htmlAttributes">样式</param>
        /// <returns>枚举单选列表</returns>
        public static MvcHtmlString EnumRadioButtionFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var type = expression?.ReturnType.GetTrueType();
            if (type != null && type.IsEnum)
            {
                var enumValues = EnumUtil.GetDesc(type);
                StringBuilder htmlBuilder = new StringBuilder();
                foreach (var item in enumValues)
                {
                    htmlBuilder.AppendFormat("{0} {1} ", htmlHelper.RadioButtonFor(expression, Enum.Parse(type, item.Key), htmlAttributes: htmlAttributes), item.Value);
                }
                return MvcHtmlString.Create(htmlBuilder.ToString());
            }
            return MvcHtmlString.Create(string.Empty);
        }
    }
}