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
        public List<int> RateID { get; set; }
        public List<int> EmployeeID { get; set; }
        public List<int> JobID { get; set; }

        public List<string> Status { get; set; }
        public int CostOption { get; set; }

        public string VieworDownload { get; set; }
        
        public bool ContractLaborer { get; set; }

        public string month { get; set; }
        public int year { get; set; }

        public string rpt1BeginDate { get; set; }
        public string rpt1EndDate { get; set; }
        public string rpt2Date { get; set; }
        public string rpt4BeginDate { get; set; }
        public string rpt4EndDate { get; set; }
        public string rpt5Date { get; set; }
        public string rpt6BeginDate { get; set; }
        public string rpt6EndDate { get; set; }
        public string rpt7BeginDate { get; set; }
        public string rpt7EndDate { get; set; }
        public string rpt8BeginDate { get; set; }
        public string rpt8EndDate { get; set; }

        
    }

}