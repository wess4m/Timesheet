using Microsoft.Owin;
using Owin;
using Timesheet.Data.Repositories;

[assembly: OwinStartupAttribute(typeof(Timesheet.Startup))]
namespace Timesheet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Adding temp data for testing
            new EmployeeRepository().AddTempEmployees();
            new TimesheetRepository().AddTempTimesheet();
        }
    }
}
