using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QRTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Qr", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CustomQr",
                url: "{controller}/{action}/{customQrData}",
                defaults: new { controller = "CustomQr", action = "Index", customQrData = UrlParameter.Optional }
            );
        }
    }
}
