﻿using System.Web;
using System.Web.Mvc;

namespace MvcTask_7_25_2024_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
