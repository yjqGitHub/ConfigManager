using System.Linq;
using System.Web.Mvc;

namespace JQ.Web.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ModelStateExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：ModelStateExtension
    /// 创建标识：yjq 2017/8/6 21:55:51
    /// </summary>
    public static class ModelStateExtension
    {
        /// <summary>
        /// 获取第一个错误信息
        /// </summary>
        /// <param name="modelState">绑定状态</param>
        /// <returns>第一个错误信息</returns>
        public static string GetFirstErrorMsg(this ModelStateDictionary modelState)
        {
            string errorMessage = string.Empty;
            if (modelState != null && (!modelState.IsValid))
            {
                foreach (var item in modelState.Values)
                {
                    if (item.Errors != null && item.Errors.Count > 0)
                    {
                        errorMessage = item.Errors.FirstOrDefault()?.ErrorMessage;
                        break;
                    }
                }
            }
            return errorMessage;
        }
    }
}