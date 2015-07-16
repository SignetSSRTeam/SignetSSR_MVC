using SignetSSRProject.Models;
using System.Data;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity.SqlServer;

namespace SignetSSRProject.Controllers
{
    public class ReportsController : Controller
    {
        private ISC567_SSRS_DatabaseEntities db = new ISC567_SSRS_DatabaseEntities();
        //
        // GET: /Reports/
        public ActionResult Index()
        {
            //ViewData["Message"] = "Welcome to ssrs";
                //return View();
            //}
            //public ActionResult ReportListing()
            //{
            //return Redirect("../Reports/ReportList.aspx");
                        
            var distinctJobStatus = db.Jobs.Select(j => new { j.Status})
                            .Distinct();

            var jobStatusList = from m in distinctJobStatus
                            select m.Status;

            var distinctMonths = db.HoursWorkeds.Select(h => new { 
                                                                    Month = SqlFunctions.DateName("mm", h.Date)
                                                                   }).Distinct();

            var month = from m in distinctMonths
                        select m.Month;

            var distinctYears = db.HoursWorkeds.Select(h => new
            {
                Year = SqlFunctions.DatePart("yy", h.Date)
            }).Distinct();

            var year = from y in distinctYears
                        select y.Year;


            ViewBag.RateID = new SelectList(db.Rates, "RateID", "JobType");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName");
            ViewBag.JobID = new SelectList(db.Jobs, "JobID", "VesselName");
            ViewBag.Status = new SelectList(jobStatusList);
            ViewBag.CostOption = new SelectList(returnCostOption(), "Value", "Text");
            ViewBag.Month = new SelectList(month);
            ViewBag.Year = new SelectList(year);
            
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt1ProjectHoursByJobClass(ReportViewModel viewModel)
        {
            //int jobType = viewModel.RateID;
            string jobType = "Billable Hour";
            string beginDate = viewModel.rptBeginDate;
            string endDate = viewModel.rptEndDate;
            return Redirect("../Reports/Reportweb.aspx?JobType=" + jobType+ "&BeginDate=" + beginDate + "&EndDate=" + endDate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt2ProjectHoursWeekly(ReportViewModel viewModel)
        {
            
            string date = viewModel.rptDate;
            return Redirect("../Reports/Reportweb.aspx?Date=" + date);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt3ProjectHoursMonth(ReportViewModel viewModel)
        {            
            int month = DateTime.ParseExact(viewModel.month, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month;
            int year = viewModel.year;
            return Redirect("../Reports/Reportweb.aspx?YEAR=" + year + "&Month=" + month );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt4HoursWorkedByEmployee(ReportViewModel viewModel)
        {            
            int employeeID = viewModel.EmployeeID;
            string beginDate = viewModel.rptBeginDate;
            string endDate = viewModel.rptEndDate;
            return Redirect("../Reports/Reportweb.aspx?JobType=" + employeeID + "&BeginDate=" + beginDate + "&EndDate=" + endDate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt5EmployeeHoursWeekly(ReportViewModel viewModel)
        {
            bool contractLaborer = viewModel.ContractLaborer;
            string date = viewModel.rptDate;
            return Redirect("../Reports/Reportweb.aspx?ContractLaborer=" + contractLaborer + "&Date=" + date );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt6ProfitSummary(ReportViewModel viewModel)
        {
            
            int jobID = viewModel.JobID;
            int costOption = viewModel.CostOption;
            string status = viewModel.Status;
            string beginDate = viewModel.rptBeginDate;
            string endDate = viewModel.rptEndDate;
            return Redirect("../Reports/Reportweb.aspx?JobID=" + jobID + "&CostOption=" + costOption + "&Status=" + status + "&BeginDate=" + beginDate + "&EndDate=" + endDate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt7MaterialsExpense(ReportViewModel viewModel)
        {
            int jobID = viewModel.JobID;
            string beginDate = viewModel.rptBeginDate;
            string endDate = viewModel.rptEndDate;
            return Redirect("../Reports/Reportweb.aspx?JobID=" + jobID + "&BeginDate=" + beginDate + "&EndDate=" + endDate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt8AbsenceAndTardiness(ReportViewModel viewModel)
        {
            int employeeID = viewModel.EmployeeID;
            string beginDate = viewModel.rptBeginDate;
            string endDate = viewModel.rptEndDate;
            return Redirect("../Reports/Reportweb.aspx?EmployeeID=" + employeeID + "&BeginDate=" + beginDate + "&EndDate=" + endDate);
        }

        private List<SelectListItem> returnCostOption() 
        {
            List<SelectListItem> costOption = new List<SelectListItem>();
            costOption.Add(new SelectListItem { Text = "Cost Option 1", Value = "1" });
            costOption.Add(new SelectListItem { Text = "Cost Option 2", Value = "2" });

            return costOption;
        }
    }
}
