using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ts = Timesheet.Data.Entities;

namespace Timesheet.Data.Repositories
{
    public class EmployeeRepository
    {
        private ts.TimesheetDBContext DBContext { get { return new ts.TimesheetDBContext(); } }
        public List<ts.Employee> GetList()
        {
            ts.TimesheetDBContext db = DBContext;
            var lst= db.Employee.OrderBy(x=>x.Name).ToList();
            return lst;
        }
        public List<int> GetMonthList()
        {
            List<int> lst = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                lst.Add(i + 1);
            }
            return lst;
        }
        public void AddTempEmployees()
        {
            ts.TimesheetDBContext db = DBContext;
            if (!db.Employee.Any(x => x.EmployeeNumber == 1))
            {
                db.Employee.Add(new ts.Employee() { EmployeeNumber = 1, Name = "Ahmed Mohamed" });
            }
            if (!db.Employee.Any(x => x.EmployeeNumber == 2))
            {
                db.Employee.Add(new ts.Employee() { EmployeeNumber = 2, Name = "Mostafa Salah" });
            }
            if (!db.Employee.Any(x => x.EmployeeNumber == 3))
            {
                db.Employee.Add(new ts.Employee() { EmployeeNumber = 3, Name = "Samy Reda" });
            }
            if (!db.Employee.Any(x => x.EmployeeNumber == 4))
            {
                db.Employee.Add(new ts.Employee() { EmployeeNumber = 4, Name = "Said Fahmy" });
            }
            if (!db.Employee.Any(x => x.EmployeeNumber == 5))
            {
                db.Employee.Add(new ts.Employee() { EmployeeNumber = 5, Name = "Ramy Nagy" });
            }
            if (!db.Employee.Any(x => x.EmployeeNumber == 6))
            {
                db.Employee.Add(new ts.Employee() { EmployeeNumber = 6, Name = "Hady Shawky" });
            }
            db.SaveChanges();
        }

    }
}