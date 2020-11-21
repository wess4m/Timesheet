using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Timesheet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "GetAddItem",
                url: "getadditem/",
                defaults: new { controller = "Home", action = "AddPV" }
            );
            routes.MapRoute(
                name: "AddItem",
                url: "additem/",
                defaults: new { controller = "Home", action = "AddPV" }
            );
            routes.MapRoute(
                name: "GetList",
                url: "getlist/",
                defaults: new { controller = "Home", action = "GetList" }
            );
            routes.MapRoute(
                name: "MarkDone",
                url: "markdone/",
                defaults: new { controller = "Home", action = "MarkDone" }
            );
            routes.MapRoute(
                name: "GetImport",
                url: "getimport/",
                defaults: new { controller = "Home", action = "ImportFromExcelPV" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
