using System;
#nullable disable

namespace CandidatePortal.Models
{
    public class NhmChangePasswordRequest
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
