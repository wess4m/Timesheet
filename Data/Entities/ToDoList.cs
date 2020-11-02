using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineUserToDoList.Data.Entities
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string TodoTitle { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
    }
}