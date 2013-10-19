using System.Web;
using System.Web.Mvc;

namespace _03.CustomRouteConstraint
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
