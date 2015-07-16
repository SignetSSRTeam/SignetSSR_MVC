using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SignetSSRProject.Models
{
    
    public class ReportViewModel
    {
        //Declare properties of Models
        public SignetSSRProject.Models.Rate rateModel = new SignetSSRProject.Models.Rate();
        public SignetSSRProject.Models.Employee employeeModel = new SignetSSRProject.Models.Employee();
        public SignetSSRProject.Models.Job jobModel = new SignetSSRProject.Models.Job();

        //Declare report parameter properties
        public int RateID { get; set; }
        public int EmployeeID { get; set; }
        public int JobID { get; set; }

        public string Status { get; set; }
        public int CostOption { get; set; }

        public bool ContractLaborer { get; set; }

        public string month { get; set; }
        public int year { get; set; }

        public string rptBeginDate { get; set; }
        public string rptEndDate { get; set; }
        public string rptDate { get; set; }

        
    }

}