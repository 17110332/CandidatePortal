using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmChangePassword
    {

        public int ID { get; set; }
        public string UserName { get; set; }
        public string PasswordOld { get; set; }
        public string PasswordNew { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
