using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Timesheet.Data.Entities
{
    public class TimesheetDBContext : DbContext
    {
        public DbSet<Timesheet> Timesheet { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}