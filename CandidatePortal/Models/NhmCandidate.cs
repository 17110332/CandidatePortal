using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmCandidate
    {
        public int ID { get; set; }
        public string ApplicantCode { get; set; }
        public int? RecruitID { get; set; }
        public DateTime? ApplyDate { get; set; }
        public int? ApplyStatus { get; set; }
        public string Salary { get; set; }

        public virtual NhmApplicant ApplicantCodeNavigation { get; set; }
        public virtual NhmRecruit Recruit { get; set; }
    }
}
