using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace JQ.Extensions
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：DictionaryExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：字典扩展类
    /// 创建标识：yjq 2017/7/15 21:07:17
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// 将字典型转为ListItem[]
        /// </summary>
        /// <param name="dic">要转换的字典</param>
        /// <returns>List<ListItem></returns>
        public static ListItem[] ToListItems(this Dictionary<string, string> dic)
        {
            List<ListItem> itemList = new List<ListItem>();
            if (dic != null && dic.Any())
            {
                foreach (var item in dic)
                {
                    itemList.Add(new ListItem(item.Value, item.Key));
                }
            }
            return itemList.ToArray();
        }
    }
}