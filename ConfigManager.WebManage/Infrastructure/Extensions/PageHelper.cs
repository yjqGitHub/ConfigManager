using JQ.Result.Page;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace ConfigManager.WebManage.Infrastructure
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：PageHelper.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：PageHelper
    /// 创建标识：yjq 2017/8/8 18:53:02
    /// </summary>
    public static class PageHelper
    {
        public static readonly int[] PageSizeList = new int[] { 10, 30, 50, 100 };

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="pageResult"></param>
        /// <param name="pageSizeList">分页每页长度列表</param>
        /// <returns></returns>
        public static MvcHtmlString SelfPager(this HtmlHelper htmlHelper, IPageResult pageResult, int[] pageSizeList = null)
        {
            int pageSize = pageResult.PageSize;
            int currentPage = pageResult.PageIndex;
            int totalCount = pageResult.TotalCount;
            int pageCount = pageResult.PageCount;
            int prevPage = currentPage - 1;
            prevPage = prevPage > 0 ? prevPage : 1;
            int nextPage = currentPage + 1;
            nextPage = nextPage > pageCount ? pageCount : nextPage;

            StringBuilder htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<div  class='pager-info'>");
            htmlBuilder.Append("每页<select name='PageSize' id='PageSize'>");
            pageSizeList = pageSizeList ?? PageSizeList;
            foreach (var pageSizeItem in pageSizeList)
            {
                htmlBuilder.AppendFormat("<option value='{0}' {1}>{0}</option>", pageSizeItem, pageSizeItem == pageSize ? "selected" : string.Empty);
            }

            htmlBuilder.AppendFormat("</select>条,显示{0}到{1},共{2}条", pageResult.CurrentMinPosition.ToString(), pageResult.CurrentMaxPosition.ToString(), pageResult.TotalCount.ToString());
            htmlBuilder.Append("</div>");

            #region 页面链接

            htmlBuilder.Append("<div class='pager'>");//页面链接
            if (pageCount >= 1)//显示页码
            {
                string routeUrl = htmlHelper.GetUrlFormat();

                htmlBuilder.Append(GetHrefInfo(1, "首页", currentPage == 1, routeUrl));//首页
                //上一页
                htmlBuilder.Append(GetHrefInfo(prevPage, "上一页", currentPage == 1, routeUrl));//上一页

                //中间页码条 前4后5
                int startPageIndex = currentPage - 4;
                int endPageIndex = currentPage + 5;
                if (startPageIndex > 1)
                {
                    htmlBuilder.Append(GetHrefInfo(1, "...", true, routeUrl));
                }
                for (int i = startPageIndex; i < endPageIndex; i++)
                {
                    if (i > 0 && i <= pageCount)
                    {
                        htmlBuilder.Append(GetHrefInfo(i, i.ToString(), i == currentPage, routeUrl, i == currentPage));
                    }
                }
                if (endPageIndex < pageCount)
                {
                    htmlBuilder.Append(GetHrefInfo(1, "...", true, routeUrl));
                }
                //下一页
                htmlBuilder.Append(GetHrefInfo(nextPage, "下一页", nextPage <= currentPage, routeUrl));//下一页
                //尾页
                htmlBuilder.Append(GetHrefInfo(pageCount, "尾页", currentPage == pageCount, routeUrl));//尾页
            }
            htmlBuilder.Append("</div>");

            #endregion 页面链接

            return MvcHtmlString.Create(htmlBuilder.ToString());
        }

        /// <summary>
        /// 获取地址参数信息
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns>地址参数信息</returns>
        public static string GetUrlFormat(this HtmlHelper htmlHelper)
        {
            RouteValueDictionary routeValueDic;
            if (htmlHelper.ViewContext.RouteData.Values != null)
            {
                routeValueDic = new RouteValueDictionary(htmlHelper.ViewContext.RouteData.Values);
            }
            else
            {
                routeValueDic = new RouteValueDictionary();
            }
            string pageIndexUrlPara = "page";
            var queryUrlString = htmlHelper.ViewContext.HttpContext.Request.QueryString;
            if (queryUrlString != null)
            {
                foreach (string urlParamKey in queryUrlString.Keys)
                {
                    if (!string.IsNullOrWhiteSpace(urlParamKey))
                    {
                        routeValueDic[urlParamKey] = queryUrlString[urlParamKey];
                    }
                }
            }
            var formUrlString = htmlHelper.ViewContext.HttpContext.Request.Form;
            if (formUrlString != null)
            {
                foreach (string urlParamKey in formUrlString.Keys)
                {
                    if (!string.IsNullOrWhiteSpace(urlParamKey))
                    {
                        routeValueDic[urlParamKey] = formUrlString[urlParamKey];
                    }
                }
            }
            routeValueDic[pageIndexUrlPara] = "99919";//先给个默认页面，后面好批量替换
            UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var routeUrl = urlHelper.RouteUrl(routeValueDic);
            return routeUrl.Replace("99919", "{0}"); ;
        }

        /// <summary>
        /// 获取链接信息
        /// </summary>
        /// <param name="pageIndex">当前页面id</param>
        /// <param name="desc">显示内容</param>
        /// <param name="isDisabled">是否无效(不能点击)</param>
        /// <param name="routeUrlFormat">路由信息</param>
        /// <returns>链接信息</returns>
        private static string GetHrefInfo(int pageIndex, string desc, bool isDisabled, string routeUrlFormat, bool isCurrent = false)
        {
            if (isDisabled)
            {
                return string.Format("<a class='pager-button {0}'>{1}</a>", isCurrent ? "current" : "disabled", desc);
            }
            else
            {
                string url = string.Format(routeUrlFormat, pageIndex.ToString());
                return string.Format("<a class='pager-button' title='转到第{0}页' href='{1}'>{2}</a>", pageIndex.ToString(), url, desc);
            }
        }
    }
}