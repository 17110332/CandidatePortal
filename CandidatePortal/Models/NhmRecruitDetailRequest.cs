using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatePortal.Models
{
    public class NhmRecruitDetailRequest
    {
        [Key]
        public int RecruitID { get; set; }
        public string TypeJobWCode { get; set; }
        public string DepartmentCode { get; set; }
        public string JobWCode { get; set; }
        public int Quantity { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool IsActive { get; set; }
        public byte[] Photo { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string Jobdescription { get; set; }
        public string Benefits { get; set; }
        public string Required { get; set; }
        public string Language { get; set; }
        public double Exp { get; set; }
        public int View {get;set;}
        public string JobWName { get; set; }
        public string FromSalary { get; set; }
        public bool IsAgree { get; set; }
        public string RealSalary { get; set; }
        public string ToSalary { get; set; }
        public string TypeJobWName { get; set; }
        public string DepartmentName { get; set; }
        public string LocationCode { get; set; }
        public string ProvinceName { get; set; }
    }
}
