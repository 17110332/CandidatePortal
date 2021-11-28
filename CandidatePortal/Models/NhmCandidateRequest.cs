using System;

namespace CandidatePortal.Models
{
    public  class NhmCandidateRequest
    {
        public int ID { get; set; }
        public string ApplicantCode { get; set; }
        public int? RecruitID { get; set; }
        public DateTime? ApplyDate { get; set; }
        public int? ApplyStatus { get; set; }
        public string Salary { get; set; }
    }
}
