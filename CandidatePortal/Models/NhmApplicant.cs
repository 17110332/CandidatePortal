using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmApplicant
    {
        public NhmApplicant()
        {
            NhmCandidates = new HashSet<NhmCandidate>();
        }
        [Key]
        public string ApplicantCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDCardNo { get; set; }
        public string BirthDay { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ProvinceCode { get; set; }
        public string DistrictCode { get; set; }
        public string WardCode { get; set; }
        public string StreetName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? TypeUser { get; set; }
        public int? PhotoID { get; set; }
        public int? CVFileID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual NhmCvfile CVFile { get; set; }
        public virtual NhmDistrict DistrictCodeNavigation { get; set; }
        public virtual NhmPhoto Photo { get; set; }
        public virtual NhmProvince ProvinceCodeNavigation { get; set; }
        public virtual NhmWard WardCodeNavigation { get; set; }
        public virtual ICollection<NhmCandidate> NhmCandidates { get; set; }
    }
}
