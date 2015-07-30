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
using System.IO;
using Microsoft.Reporting.WebForms;

namespace SignetSSRProject.Controllers
{
    public class ReportsController : Controller
    {
        private Signet_SSR_DatabaseEntities db = new Signet_SSR_DatabaseEntities();
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

            var distinctJobStatus = db.Jobs.Select(j => new { j.Status })
                            .Distinct();

            var jobStatusList = from m in distinctJobStatus
                                select m.Status;

            var distinctMonths = db.HoursWorkeds.Select(h => new
            {
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


            ViewBag.RatesSet = db.Rates;
            ViewBag.EmployeesSet = db.Employees;
            ViewBag.JobsSet = db.Jobs;
            ViewBag.Status = jobStatusList;
            //ViewBag.Status = new SelectList(jobStatusList);
            ViewBag.CostOption = new SelectList(returnCostOption(), "Value", "Text");
            ViewBag.Month = new SelectList(month);
            ViewBag.Year = new SelectList(year);

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt1ProjectHoursByJobClass(ReportViewModel viewModel)
        {
            List<int> rateID = viewModel.RateID;
            var strRateIDS = String.Join(",", rateID.ToArray());
            string rptname = "Total Project Hours Worked By Job Classification";
            string beginDate = viewModel.rpt1BeginDate;
            string endDate = viewModel.rpt1EndDate;
            string viewOrDownload = viewModel.VieworDownload;
            return Redirect("../Reports/Master RVC.aspx?JobType=" + strRateIDS + "&BeginDate=" + beginDate + "&EndDate=" + endDate + "&Reportname=" + rptname + "&Viewdownload=" + viewOrDownload);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt2ProjectHoursWeekly(ReportViewModel viewModel)
        {
            string rptname = "Project hours worked weely";
            string date = viewModel.rpt2Date;
            string viewOrDownload = viewModel.VieworDownload;
            return Redirect("../Reports/Master RVC.aspx?Date=" + date + "&Reportname=" + rptname + "&Viewdownload=" + viewOrDownload);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt3ProjectHoursMonth(ReportViewModel viewModel)
        {
            string rptname = "Total Project Hours Worked on a given Month";
            string month = viewModel.month;
            int year = viewModel.year;
            string viewOrDownload = viewModel.VieworDownload;
            return Redirect("../Reports/Master RVC.aspx?YEAR=" + year + "&Month=" + month + "&Reportname=" + rptname + "&Viewdownload=" + viewOrDownload);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt4HoursWorkedByEmployee(ReportViewModel viewModel)
        {
            string rptname = "Hours Worked by Employee";
            List<int> employeeID = viewModel.EmployeeID;
            var strEmployeeIDS = String.Join(",", employeeID.ToArray());
            string beginDate = viewModel.rpt4BeginDate;
            string endDate = viewModel.rpt4EndDate;
            string viewOrDownload = viewModel.VieworDownload;
            return Redirect("../Reports/Master RVC.aspx?EmployeeID=" + strEmployeeIDS + "&BeginDate=" + beginDate + "&EndDate=" + endDate + "&Reportname=" + rptname +"&Viewdownload="+viewOrDownload);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt5EmployeeHoursWeekly(ReportViewModel viewModel)
        {
            string rptname = "Employee Hours Worked Weekly";
            bool contractLaborer = viewModel.ContractLaborer;
            string date = viewModel.rpt5Date;
            string viewOrDownload = viewModel.VieworDownload;
            return Redirect("../Reports/Master RVC.aspx?ContractLaborer=" + contractLaborer + "&Date=" + date + "&Reportname=" + rptname + "&Viewdownload=" + viewOrDownload);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt6ProfitSummary(ReportViewModel viewModel)
        {
            string rptname = "ProfitSummary";
            List<int> jobID = viewModel.JobID;
            var strJobIDS = String.Join(",", jobID.ToArray());
            int costOption = viewModel.CostOption;
            List<string> status = viewModel.Status;
            var strStatus = String.Join(",", status.ToArray());
            string beginDate = viewModel.rpt6BeginDate;
            string endDate = viewModel.rpt6EndDate;
            string viewOrDownload = viewModel.VieworDownload;
            return Redirect("../Reports/Master RVC.aspx?JobID=" + strJobIDS + "&CostOption=" + costOption + "&Status=" + strStatus + "&BeginDate=" + beginDate + "&EndDate=" + endDate + "&Reportname=" + rptname + "&Viewdownload=" + viewOrDownload);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt7MaterialsExpense(ReportViewModel viewModel)
        {
            string rptname = "Materials Expense Details";
            List<int> jobID = viewModel.Rpt7JobID;
            var strJobIDS = String.Join(",", jobID.ToArray());
            string beginDate = viewModel.rpt7BeginDate;
            string endDate = viewModel.rpt7EndDate;
            string viewOrDownload = viewModel.VieworDownload;
            return Redirect("../Reports/Master RVC.aspx?JobID=" + strJobIDS + "&BeginDate=" + beginDate + "&EndDate=" + endDate + "&Reportname=" + rptname + "&Viewdownload=" + viewOrDownload);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rpt8AbsenceAndTardiness(ReportViewModel viewModel)
        {
            string rptname = "Specific Employee Absences and Tardiness Report";
            List<int> employeeID = viewModel.Rpt8EmployeeID;
            var strEmployeeIDS = String.Join(",", employeeID.ToArray());
            string beginDate = viewModel.rpt8BeginDate;
            string endDate = viewModel.rpt8EndDate;
            string viewOrDownload = viewModel.VieworDownload;
            return Redirect("../Reports/Master RVC.aspx?EmployeeID=" + strEmployeeIDS + "&BeginDate=" + beginDate + "&EndDate=" + endDate + "&Reportname=" + rptname + "&Viewdownload=" + viewOrDownload);
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

