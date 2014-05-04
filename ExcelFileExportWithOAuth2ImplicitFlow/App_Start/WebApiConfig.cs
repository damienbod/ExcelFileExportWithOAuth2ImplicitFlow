using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiContrib.Formatting.Xlsx;

namespace ExcelFileExportWithOAuth2ImplicitFlow
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Formatters.Add(new XlsxMediaTypeFormatter());

            return config;
        }
    }
}
