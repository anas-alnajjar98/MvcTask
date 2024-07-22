using System.Web;
using System.Web.Mvc;

namespace mvcTask_7_22_2024_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
