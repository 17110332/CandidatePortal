using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmCvfile
    {
        public NhmCvfile()
        {
            NhmApplicants = new HashSet<NhmApplicant>();
        }

        public int CVFileID { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public byte[] CVFile { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<NhmApplicant> NhmApplicants { get; set; }
    }
}
