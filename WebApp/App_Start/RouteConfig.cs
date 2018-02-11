using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "DangNhap",
                url: "auth/login",
                defaults: new { controller = "Auth", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "WebApp.Controllers" }
            );
            routes.MapRoute(
              name: "DangKy",
              url: "auth/register",
              defaults: new { controller = "Auth", action = "Register", id = UrlParameter.Optional },
              namespaces: new[] { "WebApp.Controllers" }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
