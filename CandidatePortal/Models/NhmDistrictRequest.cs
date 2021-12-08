using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CandidatePortal.Models
{
    public class NhmDistrictRequest
    {
        [Key]
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
    }
}
