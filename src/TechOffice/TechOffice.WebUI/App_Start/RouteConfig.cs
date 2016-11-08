using System.Web.Mvc;
using System.Web.Routing;
using AnThinhPhat.Utilities;

namespace AnThinhPhat.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(UrlLink.TRANGCHU, UrlLink.TRANGCHU,
                new {controller = "Home", action = "Index", id = UrlParameter.Optional});

            routes.MapRoute(UrlLink.HISTORY, UrlLink.HISTORY,
                new {controller = "Intro", action = "Index", id = UrlParameter.Optional});

            routes.MapRoute(UrlLink.CHART, UrlLink.CHART,
                new {controller = "Intro", action = "Chart", id = UrlParameter.Optional});

            routes.MapRoute(UrlLink.VANBAN, UrlLink.VANBAN,
                new {controller = "VanBan", action = "Index", id = UrlParameter.Optional});

            routes.MapRoute(UrlLink.THUTUC, UrlLink.THUTUC,
                new {controller = "ThuTuc", action = "Index", id = UrlParameter.Optional});

            routes.MapRoute(UrlLink.TACNGHIEP, UrlLink.TACNGHIEP,
                new {controller = "TacNghiep", action = "Index", id = UrlParameter.Optional});

            routes.MapRoute(UrlLink.CONGVIEC, UrlLink.CONGVIEC,
                new {controller = "CongViec", action = "Index", id = UrlParameter.Optional});

            routes.MapRoute(UrlLink.TINTUC, UrlLink.TINTUC,
                new {controller = "Home", action = "Article", id = UrlParameter.Optional});

            routes.MapRoute(UrlLink.LIENHE, UrlLink.LIENHE, new {controller = "Home", action = "Contact"});

            //Error
            routes.MapRoute("error", "error/internalserver",
                new {controller = "Error", action = "InternalServer", id = UrlParameter.Optional});

            routes.MapRoute("ErrorNotFound404", "error/notfound",
                new {controller = "Error", action = "NotFound", id = UrlParameter.Optional});

            routes.MapRoute("ErrorNotFound405", "error/notfound",
                new {controller = "Error", action = "NotFound405", id = UrlParameter.Optional});

            routes.MapRoute("ErrorUnauthorized", "error/unauthorized",
                new {controller = "Error", action = "Unauthorized", id = UrlParameter.Optional});

            routes.MapRoute("ErrorForbidenaccess", "error/forbidenaccess",
                new {controller = "Error", action = "ForbidenAccess", id = UrlParameter.Optional});

            //End Error

            //===========================================CRUD DATA=======================================//
            routes.MapRoute("chucvu", "chucvu",
                new {controller = "ChucVu", action = "Index", id = UrlParameter.Optional});
            //===========================================CRUD DATA=======================================//

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional});
        }
    }
}