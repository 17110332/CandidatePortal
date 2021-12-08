using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CandidatePortal.Models
{
    public class NhmLoginRequest
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public string SessionLogin { get; set; }
    }
}
