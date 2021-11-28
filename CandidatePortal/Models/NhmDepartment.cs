using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmDepartment
    {
        public NhmDepartment()
        {
            NhmRecruits = new HashSet<NhmRecruit>();
        }

        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentName2 { get; set; }
        public string LocationCode { get; set; }

        public virtual NhmProvince LocationCodeNavigation { get; set; }
        public virtual ICollection<NhmRecruit> NhmRecruits { get; set; }
    }
}
