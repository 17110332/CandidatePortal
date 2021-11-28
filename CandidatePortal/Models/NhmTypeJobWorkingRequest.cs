using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmTypeJobWorkingRequest 
    {
        [Key]
        public string TypeJobWCode { get; set; }
        public string TypeJobWName { get; set; }
      //  public string TypeJobWName2 { get; set; }
    }
}
