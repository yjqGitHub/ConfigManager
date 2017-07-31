using System.Web.Optimization;

namespace ConfigManage.WebManage
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：BundleConfig.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：BundleConfig
    /// 创建标识：yjq 2017/7/30 20:19:55
    /// </summary>
    public sealed class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BindCommonToolJs(bundles);
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }

        private static void BindCommonToolJs(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/CommonTool").Include(
                        "~/Content/lib/layer/3.0.3/layer.js",
                        "~/Content/JS/CommonJs/DialogJs.js",
                        "~/Content/JS/CommonJs/ToolJs.js",
                        "~/Content/JS/CommonJs/Validator.js"));
        }
    }
}