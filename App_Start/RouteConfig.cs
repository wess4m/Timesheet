using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineUserToDoList
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "GetAddItem",
                url: "getadditem/",
                defaults: new { controller = "ToDoList", action = "AddPV" }
            );
            routes.MapRoute(
                name: "AddItem",
                url: "additem/",
                defaults: new { controller = "ToDoList", action = "AddPV" }
            );
            routes.MapRoute(
                name: "GetList",
                url: "getlist/",
                defaults: new { controller = "ToDoList", action = "GetList" }
            );
            routes.MapRoute(
                name: "MarkDone",
                url: "markdone/",
                defaults: new { controller = "ToDoList", action = "MarkDone" }
            );
            routes.MapRoute(
                name: "Delete",
                url: "delete/",
                defaults: new { controller = "ToDoList", action = "Delete" }
            );
            routes.MapRoute(
                name: "GetUpdateItem",
                url: "getupdateitem/{Id}/",
                defaults: new { controller = "ToDoList", action = "UpdatePV" }
            );
            routes.MapRoute(
                name: "UpdateItem",
                url: "updateitem/",
                defaults: new { controller = "ToDoList", action = "UpdatePV" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
