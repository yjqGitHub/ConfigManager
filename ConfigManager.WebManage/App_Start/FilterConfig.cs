﻿using ConfigManager.WebManage.Infrastructure;
using System.Web.Mvc;

namespace ConfigManager.WebManage
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoginAttribute());
        }
    }
}