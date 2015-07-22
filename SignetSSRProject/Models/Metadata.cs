using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SignetSSRProject.Models
{
    public class EmployeeMetadata
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName;

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName;

        [Required]
        [StringLength(30)]
        [Display(Name = "Job Title")]
        public string JobTitle;

        [Required]
        public Nullable<bool> Supervisor;

        [Required]
        public Nullable<bool> ContractLabor;

        [Required]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "{0} must be a Number.")]
        public Nullable<decimal> WageRateRT;

        [Required]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "{0} must be a Number.")]
        public Nullable<decimal> WageRateOT;
    }

    public class CustomerMetadata
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName;

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName;

    }

    public class JobMetadata
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Job Number")]
        public string JobNumber;

        [Required]
        [StringLength(100)]
        [Display(Name = "Vessel Name")]
        public string VesselName;

        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        [Display(Name = "Item Number")]
        public string ItemNumber;

    }

    public class RateMetadata
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Job Type")]
        public string JobType;
                
        [Required]
        public Nullable<bool> Supervisor;
        
        [Required]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "{0} must be a Number.")]
        public Nullable<decimal> RateRT;

        [Required]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "{0} must be a Number.")]
        public Nullable<decimal> RateOT;
    }

    public class AttendanceMetadata
    {
        [Required]
        public string Date;

        
    }
}