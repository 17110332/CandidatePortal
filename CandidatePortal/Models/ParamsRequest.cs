using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatePortal.Models
{
    public class ParamsRequest
    {
        [Key]
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public string ApplicantCode { get; set; }
    }
}
