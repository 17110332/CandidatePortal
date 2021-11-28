using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmRecruit
    {
        public NhmRecruit()
        {
            NhmCandidates = new HashSet<NhmCandidate>();
        }

        public int RecruitID { get; set; }
        public string TypeJobWCode { get; set; }
        public string DepartmentCode { get; set; }
        public string JobWCode { get; set; }
        public int? Quantity { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsActive { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? ModifiedBy { get; set; }

        public virtual NhmDepartment DepartmentCodeNavigation { get; set; }
        public virtual NhmJobWorking JobWcodeNavigation { get; set; }
        public virtual NhmTypeJobWorking TypeJobWcodeNavigation { get; set; }
        public virtual ICollection<NhmCandidate> NhmCandidates { get; set; }
    }
}
