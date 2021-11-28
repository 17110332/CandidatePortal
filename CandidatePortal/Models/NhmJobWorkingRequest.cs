using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmJobWorkingRequest
    {
        [Key]
        public string JobWCode { get; set; }
        public string JobWName { get; set; }
        //public string JobWName2 { get; set; }
        //public string RealSalary { get; set; }
        //public string FromSalary { get; set; }
        //public string ToSalary { get; set; }
        //public bool? IsAgree { get; set; }
    }
}
