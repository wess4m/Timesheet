using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Timesheet.Data.Entities;

namespace Timesheet.Models
{
    public class AddTimesheetViewModel
    {
        [Required]
        [Display(Name = "Employee")]
        public int EmployeeNumber { get; set; }
        public List<Employee> EmployeeList { get; set; }
        [Required]
        [Display(Name = "Month")]
        public int SelectedMonth { get; set; }
        public List<int> MonthList { get; set; }
        [Required]
        [Display(Name = "Working Hours")]
        public float WorkingHours { get; set; }

    }
}