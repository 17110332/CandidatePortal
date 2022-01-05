using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatePortal.Models
{
    public class ApplicantRequestHR
    {
        [Key]
        [Column(Order = 1)]
        public string ApplicantCode { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ProvinceCode { get; set; }
        public string DistrictCode { get; set; }
        public string WardCode { get; set; }
        public string StreetName { get; set; }
        public byte[] Avatar { get; set; }
        public byte[] CVApplicant { get; set; }
        public int? Gender { get; set; }
        public int? Married { get; set; }
        public string TitleDoc { get; set; }
        public string IntroduceYourself { get; set; }
        public int? Level { get; set; }
        public string School { get; set; }
        public int? Graduated { get; set; }
        public double? Exp { get; set; }
        public string WorkProgress { get; set; }
        public string Skill { get; set; }
        public string SkillOther { get; set; }
        public string FileName { get; set; }
        [Key]
        [Column(Order = 2)]
        public int RecruitID { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Status { get; set; }
        public string JobWName { get; set; }
        public string TypeJobWName { get; set; }
        public string DepartmentName { get; set; }
        public string ProvinceName { get; set; }
    }
}
