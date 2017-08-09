using System.Collections.Generic;
using System.Web.Mvc;

namespace JQ.Web
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：SelectItemTool.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/8/9 14:43:12
    /// </summary>
    public static class SelectItemTool
    {
        public const string DEFAULT_SELECTTEXT = "-请选择-";

        /// <summary>
        /// 获取是否启用禁用的下拉选择项
        /// </summary>
        /// <param name="defaultItem">默认文本</param>
        /// <returns>是否启用禁用的下拉选择项</returns>
        public static List<SelectListItem> GetIsEnabledItems(string defaultItem = DEFAULT_SELECTTEXT)
        {
            List<SelectListItem> itemList = new List<SelectListItem>();
            if (!string.IsNullOrWhiteSpace(defaultItem))
            {
                itemList.Add(new SelectListItem { Text = defaultItem, Value = "" });
            }
            itemList.Add(new SelectListItem { Text = "启用", Value = "true" });
            itemList.Add(new SelectListItem { Text = "禁用", Value = "false" });
            return itemList;
        }
    }
}