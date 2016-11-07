using System.Web.Mvc;
using System.Web.Routing;

namespace AnThinhPhat.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "trangchu",
                url: "trangchu",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //Error
            routes.MapRoute(
                name: "error",
                url: "error/internalserver",
                defaults: new { controller = "Error", action = "InternalServer", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "ErrorNotFound404",
                url: "error/notfound",
                defaults: new { controller = "Error", action = "NotFound", id = UrlParameter.Optional }
                );

            routes.MapRoute(
              name: "ErrorNotFound405",
              url: "error/notfound",
              defaults: new { controller = "Error", action = "NotFound405", id = UrlParameter.Optional }
              );

            routes.MapRoute(
             name: "ErrorUnauthorized",
             url: "error/unauthorized",
             defaults: new { controller = "Error", action = "Unauthorized", id = UrlParameter.Optional }
             );

            routes.MapRoute(
            name: "ErrorForbidenaccess",
            url: "error/forbidenaccess",
            defaults: new { controller = "Error", action = "ForbidenAccess", id = UrlParameter.Optional }
            );

            //End Error
        }
    }
}
