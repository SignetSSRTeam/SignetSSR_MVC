using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignetSSRProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Customer()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult JobDetail()
        {
           // ViewBag.Message = "Your Job Deatils.";

            return View();
        }

        public ActionResult Employee()
        {
            // ViewBag.Message = "Your Job Deatils.";

            return View();
        }
        public ActionResult Attendance()
        {
            // ViewBag.Message = "Your Job Deatils.";

            return View();
        }
       
        public ActionResult Rate()
        {
            // ViewBag.Message = "Your Job Deatils.";

            return View();
        }
    }
}