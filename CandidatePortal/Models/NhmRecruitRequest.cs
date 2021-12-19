using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmRecruitRequest
    {
        [Key]
        public int RecruitID { get; set; }
        public string TypeJobWCode { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public string JobWCode { get; set; }
        public int? Quantity { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool? IsActive { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? ModifiedBy { get; set; }
        public string JobWName { get; set; }
        public string TypeJobWName { get; set; }

        public bool IsAgree { get; set; }
        public string FromSalary { get; set; }
        public string ToSalary { get; set; }
        public int Liked { get; set; }
    }
}
