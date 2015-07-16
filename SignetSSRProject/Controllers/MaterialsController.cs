using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SignetSSRProject.Models;
using System.Web.Script.Serialization;

namespace SignetSSRProject.Controllers
{
    public class MaterialsController : Controller
    {
        private ISC567_SSRS_DatabaseEntities db = new ISC567_SSRS_DatabaseEntities();
        

        // GET: /Materials/
        public ActionResult Index()
        {
            var jobs = db.Jobs;
            var jobNum = (from j in jobs
                                 select new
                                 {
                                     j.JobID,
                                     j.JobNumber
                                 }).ToList();
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string jobNumbers = jsonSerializer.Serialize(jobNum);
            ViewBag.jobNumbers = jobNumbers;

            var materialsexpenses = db.MaterialsExpenses.Include(m => m.Job);
            
            return View(materialsexpenses.ToList());
        }

        // GET: /Materials/MaterialsData
        public ContentResult MaterialsData(MaterialsExpense filter)
        {
            var materialsExpenses = db.MaterialsExpenses.Include(m => m.Job);
            var materialsData = (from mat in materialsExpenses
                                 where (mat.ExpenseDescription.Contains(filter.ExpenseDescription) || string.IsNullOrEmpty(filter.ExpenseDescription))
                                    && (mat.Expense == filter.Expense || filter.Expense == 0)
                                    && (mat.Job.JobID == filter.JobID || filter.JobID == 0)
                                    && (mat.ItemNumber == filter.ItemNumber || (filter.ItemNumber == 0))
                                    && (mat.PONumber.Contains(filter.PONumber) || string.IsNullOrEmpty(filter.PONumber))
                                    && (mat.InvoiceNumber.Contains(filter.InvoiceNumber) || string.IsNullOrEmpty(filter.InvoiceNumber))
                                    && (mat.TaxPercentage == filter.TaxPercentage || filter.TaxPercentage == null)
                                    && (mat.MarkupPercentage == filter.MarkupPercentage || filter.MarkupPercentage == null)
                                 select new
                                 {
                                     mat.MaterialsExpenseID,
                                     mat.Expense,
                                     JobID = mat.Job.JobID,
                                     mat.ItemNumber,
                                     mat.ExpenseDescription,
                                     mat.PONumber,
                                     mat.InvoiceNumber,
                                     mat.TaxIncluded,
                                     mat.InvoiceReceived,
                                     mat.TaxPercentage,
                                     mat.MarkupPercentage
                                 }).ToList();
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(materialsData);
            return Content(output, "application/json");
        }

        //POST: /Materials/MaterialsData
        [HttpPost]
        public ContentResult InsertMaterialsData(MaterialsExpense materials)
        {
            var materialsExpenses = db.MaterialsExpenses.Include(m => m.Job);
            var job = db.Jobs;

            ModelState.Clear();
            TryValidateModel(materials); //Hack to ignore empty job fields 
            bool isValid = true;

            if (isValid)
            {
                db.MaterialsExpenses.Add(materials);
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
            string output = jsonSerializer.Serialize(materials);
            return Content(output, "application/json");

        }

        //POST: /Materials/UpdateMaterialsData
        [HttpPost]
        public ContentResult UpdateMaterialsData(MaterialsExpense materials)
        {

            ModelState.Clear();
            TryValidateModel(materials); //Hack to ignore empty employee and job fields 

            if (ModelState.IsValid)
            {
                db.Entry(materials).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                string error = "";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError err in modelState.Errors)
                    {
                        error = error + err;
                    }
                }
            }

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(materials);
            return Content(output, "application/json");

        }

        //POST: /Materials/MaterialsData
        [HttpPost]
        public ContentResult DeleteMaterialsData(MaterialsExpense materials)
        {
            var materialsExpenses = db.MaterialsExpenses.Include(m => m.Job);
            MaterialsExpense removeMaterials = db.MaterialsExpenses.Find(materials.MaterialsExpenseID);


            var isValid = true; //Work around to resolve error
            if (isValid)
            {
                db.MaterialsExpenses.Remove(removeMaterials);
                db.SaveChanges();
            }
            else
            {
                string error = "";
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError err in modelState.Errors)
                    {
                        error = error + err;
                    }
                }
            }

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string output = jsonSerializer.Serialize(materials);
            return Content(output, "application/json");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
