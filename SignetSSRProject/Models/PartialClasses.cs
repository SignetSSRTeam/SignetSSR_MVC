using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SignetSSRProject.Models
{
    [MetadataType(typeof(EmployeeViewModelMetadata))]
    public partial class EmployeeViewModel
    {
    }

    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {
    }

    [MetadataType(typeof(JobMetadata))]
    public partial class Job
    {
    }

    [MetadataType(typeof(RateMetadata))]
    public partial class Rate
    {
    }

    [MetadataType(typeof(AttendanceMetadata))]
    public partial class Attendance
    {
    }
}