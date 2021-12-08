using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace CandidatePortal.Models
{
    public class NhmWardRequest
    {
        [Key]
        public string WardCode { get; set; }
        public string WardName { get; set; }
    }
}
