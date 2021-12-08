using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatePortal.Models
{
    public class ApplicantPersonalRequest
    {

        [Key]
        public string ApplicantCode { get; set; }
        public byte[] Avatar { get; set; }
        public byte[] CVApplicant { get; set; }
        public int? Gender { get; set; }
        public int? Married { get; set; }
        public string TitleDoc { get; set; }
        public string IntroduceYourself { get; set; }
        public int? Level { get; set; }
        public string School { get; set; }
        public int? Graduated { get; set; }
        public float? Exp { get; set; }
        public string WorkProgress { get; set; }
        public string Skill { get; set; }
        public string SkillOther { get; set; }
    }
}
