using OnlineUserToDoList.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace OnlineUserToDoList.Data.Handlers
{
    /// <summary>
    /// Summary description for ToDoListHandler
    /// </summary>
    public class ToDoListHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var ToDoList = new ToDoListRepository().GetList();
            var result = new {
                iTotalRecords = ToDoList.Count,
                iTotalDisplayRecords = ToDoList.Count,
                aaData = ToDoList
            };
            JavaScriptSerializer jss = new JavaScriptSerializer();
            context.Response.Write(jss.Serialize(result));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}