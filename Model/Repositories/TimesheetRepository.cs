using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Timesheet.Models;
using ts = Timesheet.Data.Entities;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using System.Data;

namespace Timesheet.Data.Repositories
{
    public class TimesheetRepository
    {
        private ts.TimesheetDBContext DBContext { get { return new ts.TimesheetDBContext(); } }
        public List<ts.TimesheetListItem> GetList()
        {
            ts.TimesheetDBContext db = DBContext;
            List<ts.TimesheetListItem> data = new List<ts.TimesheetListItem>();
            var lst = from t in db.Timesheet join e in db.Employee on t.EmployeeNumber equals e.EmployeeNumber
                      select new { t.EmployeeNumber, t.Month, t.WorkingHours, e.Name };
            foreach (var item in lst)
            {
                data.Add(new ts.TimesheetListItem() {
                    EmployeeNumber = item.EmployeeNumber,
                    Name = item.Name,
                    Month = item.Month,
                    WorkingHours = item.WorkingHours
                });
            }
            return data;
        }
        public void AddUpdate(AddTimesheetViewModel vm)
        {
            if (vm != null && vm.EmployeeNumber > 0 && vm.SelectedMonth > 0 && vm.WorkingHours > 0)
            {
                ts.TimesheetDBContext db = DBContext;
                var ts = db.Timesheet.Where(x => x.EmployeeNumber == vm.EmployeeNumber && x.Month == vm.SelectedMonth).FirstOrDefault();
                if (ts != null && ts.EmployeeNumber > 0)
                {
                    ts.WorkingHours = vm.WorkingHours;
                }
                else
                {
                    db.Timesheet.Add(new Data.Entities.Timesheet() { EmployeeNumber = vm.EmployeeNumber, Month = vm.SelectedMonth, WorkingHours = vm.WorkingHours });
                }
                db.SaveChanges();
            }
        }
        public void AddTempTimesheet()
        {
            ts.TimesheetDBContext db = DBContext;
            if (!db.Timesheet.Any(x => x.EmployeeNumber == 1 && x.Month == 1))
            {
                db.Timesheet.Add(new ts.Timesheet() { EmployeeNumber = 1, Month = 1, WorkingHours = 7 });
            }
            if (!db.Timesheet.Any(x => x.EmployeeNumber == 2 && x.Month == 1))
            {
                db.Timesheet.Add(new ts.Timesheet() { EmployeeNumber = 2, Month = 1, WorkingHours = 8 });
            }
            if (!db.Timesheet.Any(x => x.EmployeeNumber == 3 && x.Month == 1))
            {
                db.Timesheet.Add(new ts.Timesheet() { EmployeeNumber = 3, Month = 1, WorkingHours = 9 });
            }
            db.SaveChanges();
        }
        public void ImportTimesheetBulk(HttpPostedFileBase fb)
        {
            DataTable dt = GetDataTableFromSpreadsheet(fb.InputStream, false);
            ts.TimesheetDBContext db = DBContext;
            foreach (DataRow dr in dt.Rows)
            {
                int EmployeeNumber = int.Parse(dr[0].ToString());
                int Month = int.Parse(dr[1].ToString());
                float WorkingHours = float.Parse(dr[2].ToString());
                if (db.Employee.Any(x=>x.EmployeeNumber == EmployeeNumber))
                {
                    var sheet = db.Timesheet.Where(x => x.EmployeeNumber == EmployeeNumber && x.Month == Month).FirstOrDefault();
                    if (sheet != null && sheet.EmployeeNumber > 0)
                    {
                        sheet.WorkingHours = WorkingHours;
                    }
                    else
                    {
                        db.Timesheet.Add(new ts.Timesheet() { EmployeeNumber = EmployeeNumber, Month = Month, WorkingHours = WorkingHours });
                    }
                }
            }
            db.SaveChanges();
        }
        public static DataTable GetDataTableFromSpreadsheet(Stream MyExcelStream, bool ReadOnly)
        {
            DataTable dt = new DataTable();
            using (SpreadsheetDocument sDoc = SpreadsheetDocument.Open(MyExcelStream, ReadOnly))
            {
                WorkbookPart workbookPart = sDoc.WorkbookPart;
                IEnumerable<Sheet> sheets = sDoc.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                string relationshipId = sheets.First().Id.Value;
                WorksheetPart worksheetPart = (WorksheetPart)sDoc.WorkbookPart.GetPartById(relationshipId);
                Worksheet workSheet = worksheetPart.Worksheet;
                SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                IEnumerable<Row> rows = sheetData.Descendants<Row>();
                foreach (Cell cell in rows.ElementAt(0))
                {
                    dt.Columns.Add(GetCellValue(sDoc, cell));
                }
                foreach (Row row in rows) //this will also include your header row...
                {
                    DataRow tempRow = dt.NewRow();
                    for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                    {
                        tempRow[i] = GetCellValue(sDoc, row.Descendants<Cell>().ElementAt(i));
                    }
                    dt.Rows.Add(tempRow);
                }
            }
            dt.Rows.RemoveAt(0);
            return dt;
        }
        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }
    }
}