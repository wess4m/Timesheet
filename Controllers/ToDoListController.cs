using OnlineUserToDoList.Data.Entities;
using OnlineUserToDoList.Data.Repositories;
using OnlineUserToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineUserToDoList.Controllers
{
    public class ToDoListController : Controller
    {
        public JsonResult GetList()
        {
            return Json(new ToDoListRepository().GetList(), JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult AddPV()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult AddPV(AddToDoListViewModel vm)
        {
            new ToDoListRepository().Add(new Data.Entities.ToDoList() { TodoTitle = vm.TodoTitle, DueDate = vm.DueDate, IsDone = false });
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult UpdatePV(int Id)
        {
            return PartialView(new ToDoListRepository().GetById(Id));
        }
        [HttpPost]
        public JsonResult UpdatePV(ToDoList vm)
        {
            new ToDoListRepository().Update(new Data.Entities.ToDoList() { Id = vm.Id, TodoTitle = vm.TodoTitle, DueDate = vm.DueDate, IsDone = false });
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MarkDone(int Id)
        {
            new ToDoListRepository().SetIsDone(Id, true);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int Id)
        {
            new ToDoListRepository().Delete(Id);
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}