using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignetSSRProject.Models
{
    public partial class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public bool? Supervisor { get; set; }
        public bool? ContractLabor { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Notes { get; set; }
        public decimal WageRateRT { get; set; }
        public decimal WageRateOT { get; set; }
    }
}