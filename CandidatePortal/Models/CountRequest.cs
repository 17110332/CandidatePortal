using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatePortal.Models
{
    public class CountRequest
    {
      
        public string ApplicantCode { get;  set; }
        [Key]
        public bool Islike { get; set; }
        public int SL { get; set; }
    }
}
