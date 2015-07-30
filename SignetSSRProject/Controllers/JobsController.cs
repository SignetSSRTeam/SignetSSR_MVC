using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SignetSSRProject.Models;

namespace SignetSSRProject.Controllers
{
    public class JobsController : Controller
    {
        private Signet_SSR_DatabaseEntities db = new Signet_SSR_DatabaseEntities();

        // GET: Jobs
        public ActionResult Index(string JobNumber, string VesselName, string jobID)
        {
            //JobNumber	 VesselName	 Priority	 Status	 Description	 StartDate	 EndDate	
            var jobs = from j in db.Jobs.Include(j => j.Customer).Include(j => j.Rate)
                       select j;
            if (!String.IsNullOrEmpty(JobNumber))
            {
                jobs = jobs.Where(x => x.JobNumber.Equals(JobNumber));
            }
            if (!String.IsNullOrEmpty(VesselName))
            {
                jobs = jobs.Where(x => x.VesselName.Contains(VesselName));
            }


            return View(jobs.ToList());
        }


        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.RateID = new SelectList(db.Rates, "RateID", "JobType");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobID,JobNumber,CustomerID,RateID,VesselName,Priority,Status,Description,StartDate,EndDate")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", job.CustomerID);
            ViewBag.RateID = new SelectList(db.Rates, "RateID", "JobType", job.RateID);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", job.CustomerID);
            ViewBag.RateID = new SelectList(db.Rates, "RateID", "JobType", job.RateID);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobID,JobNumber,CustomerID,RateID,VesselName,Priority,Status,Description,StartDate,EndDate")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", job.CustomerID);
            ViewBag.RateID = new SelectList(db.Rates, "RateID", "JobType", job.RateID);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
    }
}
