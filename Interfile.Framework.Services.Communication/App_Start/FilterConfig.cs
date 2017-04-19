using System.Web;
using System.Web.Mvc;

namespace Interfile.Framework.Services.Communication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
