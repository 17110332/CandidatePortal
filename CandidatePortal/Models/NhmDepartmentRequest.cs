using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CandidatePortal.Models
{
    public class NhmDepartmentRequest
    {
        [Key]
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
