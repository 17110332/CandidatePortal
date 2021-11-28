using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public class NhmLoginRequest
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public string SessionLogin { get; set; }
    }
}
