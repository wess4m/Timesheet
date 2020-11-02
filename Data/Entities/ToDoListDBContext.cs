using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineUserToDoList.Data.Entities
{
    public class ToDoListDBContext : DbContext
    {
        public DbSet<ToDoList> ToDoList { get; set; }
    }
}