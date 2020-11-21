using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Timesheet.Data.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeNumber { get; set; }
        public string Name { get; set; }
        public ICollection<Timesheet> Timesheets { get; set; }
    }
}