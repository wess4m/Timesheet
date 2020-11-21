using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Timesheet.Data.Entities
{
    public class TimesheetListItem
    {
        public int EmployeeNumber { get; set; }
        public int Month { get; set; }
        public float WorkingHours { get; set; }
        public string Name { get; set; }
    }
}