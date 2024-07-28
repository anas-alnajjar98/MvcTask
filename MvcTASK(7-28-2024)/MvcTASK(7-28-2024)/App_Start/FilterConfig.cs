using System.Web;
using System.Web.Mvc;

namespace MvcTASK_7_28_2024_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
