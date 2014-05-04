using System.Web;
using System.Web.Mvc;

namespace ExcelFileExportWithOAuth2ImplicitFlow
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
