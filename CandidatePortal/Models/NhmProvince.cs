using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmProvince
    {
        public NhmProvince()
        {
            NhmApplicants = new HashSet<NhmApplicant>();
            NhmDepartments = new HashSet<NhmDepartment>();
            NhmDistricts = new HashSet<NhmDistrict>();
            NhmEmployees = new HashSet<NhmEmployee>();
            NhmTypeJobWorkings = new HashSet<NhmTypeJobWorking>();
        }

        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceName2 { get; set; }

        public virtual ICollection<NhmApplicant> NhmApplicants { get; set; }
        public virtual ICollection<NhmDepartment> NhmDepartments { get; set; }
        public virtual ICollection<NhmDistrict> NhmDistricts { get; set; }
        public virtual ICollection<NhmEmployee> NhmEmployees { get; set; }
        public virtual ICollection<NhmTypeJobWorking> NhmTypeJobWorkings { get; set; }
    }
}
