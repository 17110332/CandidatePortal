using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmDistrict
    {
        public NhmDistrict()
        {
            NhmApplicants = new HashSet<NhmApplicant>();
            NhmEmployees = new HashSet<NhmEmployee>();
            NhmWards = new HashSet<NhmWard>();
        }

        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string DistrictName2 { get; set; }
        public string ProvinceCode { get; set; }

        public virtual NhmProvince ProvinceCodeNavigation { get; set; }
        public virtual ICollection<NhmApplicant> NhmApplicants { get; set; }
        public virtual ICollection<NhmEmployee> NhmEmployees { get; set; }
        public virtual ICollection<NhmWard> NhmWards { get; set; }
    }
}
