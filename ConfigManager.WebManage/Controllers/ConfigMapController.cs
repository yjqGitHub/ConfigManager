using ConfigManager.Constant.EnumCollection;
using ConfigManager.TransDto.QueryWhereDto;
using ConfigManager.TransDto.TransModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConfigManager.WebManage.Controllers
{
    public class ConfigMapController : Controller
    {
        public ActionResult Index(ConfigMapQueryWhereDto queryWhereDto)
        {
            if (queryWhereDto == null || queryWhereDto.BelongType == null)
            {
                return View("~/Views/Shared/NotFind.cshtml");
            }
            ViewBag.ConfigMapQueryWhereDto = queryWhereDto;
            ViewBag.BelongType = (int)queryWhereDto.BelongType.Value;
            ViewBag.BelongID = queryWhereDto.BelongID;
            return View();
        }

        /// <summary>
        /// 展示添加配置页面
        /// </summary>
        /// <param name="belongType">配置所属类型</param>
        /// <param name="belongID">配置所属ID</param>
        /// <returns>添加配置页面</returns>
        [HttpGet]
        public ActionResult AddConfig(ConfigBelongType belongType, int belongID)
        {
            var model = new ConfigEditModel()
            {
                FBelongType = belongType,
                FBelongID = belongID
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult AddConfigDetail()
        {

            return View();
        }
    }
}