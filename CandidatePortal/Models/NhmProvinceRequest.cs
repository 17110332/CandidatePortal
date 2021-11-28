using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CandidatePortal.Models
{
    public class NhmProvinceRequest
    {
        [Key]
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
    }
}
