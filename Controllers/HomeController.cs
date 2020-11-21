using Timesheet.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Timesheet.Models;
using System.Data;

namespace Timesheet.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Home page
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            return View();
        }
        /// <summary>
        /// Gets employees timesheet
        /// </summary>
        /// <returns></returns>
        public JsonResult GetList()
        {
            return Json(new TimesheetRepository().GetList(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Gets add/update partial view
        /// </summary>
        /// <returns></returns>
        public PartialViewResult AddPV()
        {
            return PartialView(new AddTimesheetViewModel() { EmployeeList = new EmployeeRepository().GetList(), MonthList = new EmployeeRepository().GetMonthList() });
        }
        [HttpPost]
        public ActionResult AddPV(AddTimesheetViewModel vm)
        {
            new TimesheetRepository().AddUpdate(vm);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Gets import timesheet from excel partial view
        /// </summary>
        /// <returns></returns>
        public PartialViewResult ImportFromExcelPV()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ImportFromExcelPV(ImportFromExcelViewModel vm)
        {
            new TimesheetRepository().ImportTimesheetBulk(vm.ExcelFile);
            return RedirectToAction("Index");
        }
    }
}