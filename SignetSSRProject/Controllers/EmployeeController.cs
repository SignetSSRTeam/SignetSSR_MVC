﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SignetSSRProject.Models;
using System.Web.Script.Serialization;
using System.Data.Entity.SqlServer;

namespace SignetSSRProject.Controllers
{
    public class EmployeeController : Controller
    {
        private Signet_SSR_DatabaseEntities db = new Signet_SSR_DatabaseEntities();

        // GET: /Employee/
        public ActionResult Index(string FirstName, string LastName)
        {
            List<Employee> employees = db.Employees.ToList();
            List<WageHistory> wageHistory = db.WageHistories.ToList();

            //return View(db.Employees.SqlQuery("SELECT DBO.Employee.EmployeeID,DBO.Employee.FirstName,DBO.Employee.LastName,DBO.Employee.JobTitle,DBO.Employee.Supervisor,DBO.Employee.ContractLabor,DBO.WageHistory.WageRT as WageRateRT,DBO.WageHistory.WageOT as WageRateOT,dbo.Employee.HomePhone,DBO.Employee.CellPhone,DBO.Employee.Address,DBO.Employee.EmailAddress,DBO.Employee.Notes FROM dbo.Employee,dbo.WageHistory WHERE DBO.Employee.EmployeeID=DBO.WageHistory.EmployeeID AND DBO.WageHistory.IsCurrent=1;").ToList());

            var result = from employee in employees
                         join wages in wageHistory on employee.EmployeeID equals wages.EmployeeID
                         where (wages.IsCurrent)
                         select new EmployeeViewModel
                         {
                             EmployeeID = employee.EmployeeID,
                             FirstName = employee.FirstName,
                             LastName = employee.LastName,
                             JobTitle = employee.JobTitle,
                             Supervisor = employee.Supervisor,
                             ContractLabor = employee.ContractLabor,
                             WageRateRT = wages.WageRT,
                             WageRateOT = wages.WageOT,
                             HomePhone = employee.HomePhone,
                             CellPhone = employee.CellPhone,
                             EmailAddress = employee.EmailAddress,
                             Address = employee.Address,
                             Notes = employee.Notes
                         };

            if (!String.IsNullOrEmpty(FirstName))
            {
                result = result.Where(X => X.FirstName.Contains(FirstName));
            }
            if (!String.IsNullOrEmpty(LastName))
            {
                result = result.Where(X => X.LastName.Contains(LastName));
            }

            return View(result.ToList());
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            //Find Employee
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            //Obtain current wage detail
            WageHistory currentWageHistory = db.WageHistories
                                               .Where(wh => wh.EmployeeID == id && wh.IsCurrent)
                                               .FirstOrDefault();

            //Create employeeViewModel with employee detail
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.EmployeeID = employee.EmployeeID;
            employeeViewModel.FirstName = employee.FirstName;
            employeeViewModel.LastName = employee.LastName;
            employeeViewModel.JobTitle = employee.JobTitle;
            employeeViewModel.Supervisor = employee.Supervisor;
            employeeViewModel.ContractLabor = employee.ContractLabor;
            employeeViewModel.WageRateRT = currentWageHistory.WageRT;
            employeeViewModel.WageRateOT = currentWageHistory.WageOT;
            employeeViewModel.HomePhone = employee.HomePhone;
            employeeViewModel.CellPhone = employee.CellPhone;
            employeeViewModel.EmailAddress = employee.EmailAddress;
            employeeViewModel.Address = employee.Address;
            employeeViewModel.Notes = employee.Notes;
            
            return View(employeeViewModel);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EmployeeID,FirstName,LastName,JobTitle,Supervisor,ContractLabor,WageRateRT,WageRateOT,HomePhone,CellPhone,Address,EmailAddress,Notes")] EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                // save data into the employee table based on the information in the EmployeeViewModel
                Employee employee = new Employee();
                employee.EmployeeID = employeeViewModel.EmployeeID;
                employee.FirstName = employeeViewModel.FirstName;
                employee.LastName = employeeViewModel.LastName;
                employee.JobTitle = employeeViewModel.JobTitle;
                employee.Supervisor = employeeViewModel.Supervisor;
                employee.ContractLabor = employeeViewModel.ContractLabor;
                employee.HomePhone = employeeViewModel.HomePhone;
                employee.CellPhone = employeeViewModel.CellPhone;
                employee.Address = employeeViewModel.Address;
                employee.EmailAddress = employeeViewModel.EmailAddress;
                employee.Notes = employeeViewModel.Notes;

                db.Employees.Add(employee);
                db.SaveChanges();
                
                int employeeCount = db.Employees.ToList().Count();
                int EmployeeId = db.Employees.ToList()[employeeCount - 1].EmployeeID;
                WageHistory wageHistory = new WageHistory();
                wageHistory.EmployeeID = EmployeeId;
                wageHistory.WageOT = employeeViewModel.WageRateOT;
                wageHistory.WageRT = employeeViewModel.WageRateRT;
                wageHistory.IsCurrent = true;
                wageHistory.DateStart = DateTime.Now.Date;
                
                db.WageHistories.Add(wageHistory);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(employeeViewModel);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            // Get the current wage of the employee
            List<WageHistory> wageHistory = db.WageHistories.Where(x => x.EmployeeID == id && x.IsCurrent).ToList();
            WageHistory wh = wageHistory[0];

            // Create an employeeviewmodel and populate it with the employee details
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            
            employeeViewModel.EmployeeID = employee.EmployeeID;
            employeeViewModel.FirstName = employee.FirstName;
            employeeViewModel.LastName = employee.LastName;
            employeeViewModel.JobTitle = employee.JobTitle;
            employeeViewModel.Supervisor = employee.Supervisor;
            employeeViewModel.ContractLabor = employee.ContractLabor;
            employeeViewModel.HomePhone = employee.HomePhone;
            employeeViewModel.CellPhone = employee.CellPhone;
            employeeViewModel.Address = employee.Address;
            employeeViewModel.EmailAddress = employee.EmailAddress;
            employeeViewModel.Notes = employee.Notes;
            employeeViewModel.WageRateOT = wh.WageOT;
            employeeViewModel.WageRateRT = wh.WageRT;
           
            return View(employeeViewModel);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EmployeeID,FirstName,LastName,JobTitle,Supervisor,ContractLabor,HomePhone,CellPhone,Address,EmailAddress,Notes")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            // Get the current wage of the employee
            WageHistory wageHistory = db.WageHistories.Where(x => x.EmployeeID == id && x.IsCurrent).FirstOrDefault();            

            // Create an employeeviewmodel and populate it with the employee details
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            employeeViewModel.EmployeeID = employee.EmployeeID;
            employeeViewModel.FirstName = employee.FirstName;
            employeeViewModel.LastName = employee.LastName;
            employeeViewModel.JobTitle = employee.JobTitle;
            employeeViewModel.Supervisor = employee.Supervisor;
            employeeViewModel.ContractLabor = employee.ContractLabor;
            employeeViewModel.HomePhone = employee.HomePhone;
            employeeViewModel.CellPhone = employee.CellPhone;
            employeeViewModel.Address = employee.Address;
            employeeViewModel.EmailAddress = employee.EmailAddress;
            employeeViewModel.Notes = employee.Notes;
            employeeViewModel.WageRateOT = wageHistory.WageOT;
            employeeViewModel.WageRateRT = wageHistory.WageRT;

            return View(employeeViewModel);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            // Remove all wage history records associated with this employee
            List<WageHistory> wageHistories = db.WageHistories.Where(x => x.EmployeeID == id && x.IsCurrent).ToList();
            foreach (WageHistory wageHistory in wageHistories)
            {
                db.WageHistories.Remove(wageHistory);
            }
            db.SaveChanges();
            
            // Delete Employee Record
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult getWageHistory(int? id )
        {            
            ViewBag.employeeID = id;

            List<WageHistory> list=db.WageHistories.Include(x => x.Employee).Where(x => x.EmployeeID == id).ToList();
            WageHistory w = list[0];
            
            return PartialView("_getWageHistory",w);
        }

        /*[HttpPost]
        public ActionResult saveWageHistory(WageHistory wageHistory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(wageHistory).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true });
                }

                catch(Exception e) {

                    ModelState.AddModelError("", e.Message);
                }
            
            }

            return PartialView("_getWageHistory",wageHistory);
            //return RedirectToAction("Edit", new { Id = wageHistory.EmployeeID, @target="parent"});

        }*/

        // GET: /Employee/WageHistoryData
        [HttpGet]
        public ContentResult WageHistoryData(int? employeeID)
        {
            var wageHistory = db.WageHistories;
            var wageHistoryData = (from wh in wageHistory
                                   where wh.EmployeeID == employeeID
                                 select new
                                 {
                                     wh.WageHistoryID,
                                     wh.WageRT,
                                     wh.WageOT,
                                     DateStart = wh.DateStart == null ? null: SqlFunctions.DateName("mm", wh.DateStart) + " " + SqlFunctions.DateName("day", wh.DateStart) + ", " + SqlFunctions.DateName("year", wh.DateStart),
                                     DateEnd = wh.DateEnd == null ? null : SqlFunctions.DateName("mm", wh.DateEnd) + " " + SqlFunctions.DateName("day", wh.DateEnd) + ", " + SqlFunctions.DateName("year", wh.DateEnd),
                                     wh.IsCurrent
                                 }).ToList();
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(wageHistoryData);
            return Content(output, "application/json");
        }

        // POST: /Employee/InsertWageHistoryData
        [HttpPost]
        public ContentResult InsertWageHistoryData(WageHistory wageHistory)
        {
                        
            if (ModelState.IsValid)
            {
                db.WageHistories.Add(wageHistory);
                db.SaveChanges();
            }
            else
            {
                string error = "";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError err in modelState.Errors)
                    {
                        error = error + " \n" + err.ErrorMessage;
                    }
                }
                return Content("", "application/json");
            }

            var wageHistories = db.WageHistories;
            var wageHistoryData = (from wh in wageHistories
                                   where wh.WageHistoryID == wageHistory.WageHistoryID
                                   select new
                                   {
                                       wh.WageHistoryID,
                                       wh.WageRT,
                                       wh.WageOT,
                                       DateStart = wh.DateStart == null ? null : SqlFunctions.DateName("mm", wh.DateStart) + " " + SqlFunctions.DateName("day", wh.DateStart) + ", " + SqlFunctions.DateName("year", wh.DateStart),
                                       DateEnd = wh.DateEnd == null ? null : SqlFunctions.DateName("mm", wh.DateEnd) + " " + SqlFunctions.DateName("day", wh.DateEnd) + ", " + SqlFunctions.DateName("year", wh.DateEnd),
                                       wh.IsCurrent
                                   }).SingleOrDefault();

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(wageHistoryData);
            return Content(output, "application/json");
        }

        // POST: /Employee/UpdateWageHistoryData
        [HttpPost]
        public ContentResult UpdateWageHistoryData(WageHistory wageHistory)
        {

            if (ModelState.IsValid)
            {
                db.Entry(wageHistory).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                string error = "";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError err in modelState.Errors)
                    {
                        error = error + " \n" + err.ErrorMessage;
                    }
                }
                return Content("", "application/json");
            }

            var wageHistories = db.WageHistories;
            var wageHistoryData = (from wh in wageHistories
                                   where wh.WageHistoryID == wageHistory.WageHistoryID
                                   select new
                                   {
                                       wh.WageHistoryID,
                                       wh.WageRT,
                                       wh.WageOT,
                                       DateStart = wh.DateStart == null ? null : SqlFunctions.DateName("mm", wh.DateStart) + " " + SqlFunctions.DateName("day", wh.DateStart) + ", " + SqlFunctions.DateName("year", wh.DateStart),
                                       DateEnd = wh.DateEnd == null ? null : SqlFunctions.DateName("mm", wh.DateEnd) + " " + SqlFunctions.DateName("day", wh.DateEnd) + ", " + SqlFunctions.DateName("year", wh.DateEnd),
                                       wh.IsCurrent
                                   }).SingleOrDefault();

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(wageHistoryData);
            return Content(output, "application/json");
        }

        // POST: /Employee/DeleteWageHistoryData
        [HttpPost]
        public ContentResult DeleteWageHistoryData(WageHistory wageHistory)
        {
            var wageHistoryData = db.WageHistories;
            WageHistory removeWageHistory = db.WageHistories.Find(wageHistory.WageHistoryID);

            if (ModelState.IsValid)
            {
                db.WageHistories.Remove(removeWageHistory);
                db.SaveChanges();
            }
            else
            {
                string error = "";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError err in modelState.Errors)
                    {
                        error = error + " \n" + err.ErrorMessage;
                    }
                }
                return Content("", "application/json");
            }
            
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(removeWageHistory);
            return Content(output, "application/json");
        }

    }
}
