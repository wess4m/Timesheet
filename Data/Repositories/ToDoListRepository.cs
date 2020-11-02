using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineUserToDoList.Data.Entities;

namespace OnlineUserToDoList.Data.Repositories
{
    public class ToDoListRepository
    {
        private ToDoListDBContext DBContext { get { return new ToDoListDBContext(); } }
        public List<ToDoList> GetList()
        {
            ToDoListDBContext db = DBContext;
            return db.ToDoList.ToList();
        }
        public ToDoList GetById(int Id)
        {
            ToDoListDBContext db = DBContext;
            return db.ToDoList.Where(x=>x.Id == Id).FirstOrDefault();
        }
        public void Add(ToDoList toDoList)
        {
            ToDoListDBContext db = DBContext;
            var Itemslst = GetList();
            int maxId = Itemslst != null && Itemslst.Count > 0 ? Itemslst.Max(x=>x.Id) : 0;
            toDoList.Id = maxId + 1;
            db.ToDoList.Add(toDoList);
            db.SaveChanges();
        }
        public void Update(ToDoList toDoList)
        {
            ToDoListDBContext db = DBContext;
            var item = db.ToDoList.Where(x => x.Id == toDoList.Id).FirstOrDefault();
            item.TodoTitle = toDoList.TodoTitle;
            item.DueDate = toDoList.DueDate;
            db.SaveChanges();
        }
        public void SetIsDone(int Id, bool IsDone)
        {
            ToDoListDBContext db = DBContext;
            var item = db.ToDoList.Where(x => x.Id == Id).FirstOrDefault();
            item.IsDone = IsDone;
            db.SaveChanges();
        }
        public void Delete(int Id)
        {
            ToDoListDBContext db = DBContext;
            var item = db.ToDoList.Where(x => x.Id == Id).FirstOrDefault();
            db.ToDoList.Remove(item);
            db.SaveChanges();
        }
    }
}