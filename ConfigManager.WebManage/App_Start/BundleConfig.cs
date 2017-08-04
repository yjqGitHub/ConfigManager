using System.Web.Optimization;

namespace ConfigManager.WebManage
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BindCommonToolJs(bundles);
            BindListJsAndCss(bundles);
        }

        private static void BindListJsAndCss(BundleCollection bundles)
        {
            //list母版页公共js
            bundles.Add(new ScriptBundle("~/ListLayout/js").Include(
                        "~/Content/lib/jquery/1.9.1/jquery.min.js",
                        "~/Content/lib/layer/3.0.3/layer.js",
                        "~/Content/static/h-ui/js/H-ui.min.js",
                        "~/Content/static/h-ui.admin/js/H-ui.admin.js",
                        "~/Content/JS/CommonJs/DialogJs.js",
                        "~/Content/JS/CommonJs/ToolJs.js",
                        "~/Content/JS/CommonJs/tableHeadFixer.js"));
            //list母版页公共css
            bundles.Add(new StyleBundle("~/ListLayout/css").Include(
                      "~/Content/static/h-ui/css/H-ui.min.css",
                      "~/Content/static/h-ui.admin/css/H-ui.admin.cs",
                      "~/Content/lib/Hui-iconfont/1.0.8/iconfont.css",
                      "~/Content/static/h-ui.admin/skin/blue/skin.css",
                      "~/Content/static/h-ui.admin/css/style.css"));
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