using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmWard
    {
        public NhmWard()
        {
            NhmApplicants = new HashSet<NhmApplicant>();
            NhmEmployees = new HashSet<NhmEmployee>();
        }

        public string WardCode { get; set; }
        public string WardName { get; set; }
        public string WardName2 { get; set; }
        public string DistrictCode { get; set; }

        public virtual NhmDistrict DistrictCodeNavigation { get; set; }
        public virtual ICollection<NhmApplicant> NhmApplicants { get; set; }
        public virtual ICollection<NhmEmployee> NhmEmployees { get; set; }
    }
}
