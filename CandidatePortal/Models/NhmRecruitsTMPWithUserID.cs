using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace CandidatePortal.Models
{
    public class NhmRecruitsTMPWithUserID
    {
        [Key]
        public string ApplicantCode { get; set; }

        public int RecruitID { get; set; }
        public bool Islike { get; set; } // xác định là like hay apply
        public int Status { get; set; } // 0: like job, 1: chờ duyệt,2: chờ phỏng vấn, 3: đậu pv, 4: xác nhận làm việc, 5: từ chối nhận việc, 6 rớt pv
        //public bool LikeStatus { get; set; } // xác định 1: like hay 0:unlike
    }
}
