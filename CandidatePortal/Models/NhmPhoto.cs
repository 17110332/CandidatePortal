using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmPhoto
    {
        public NhmPhoto()
        {
            NhmApplicants = new HashSet<NhmApplicant>();
            NhmEmployees = new HashSet<NhmEmployee>();
        }

        public int PhotoID { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<NhmApplicant> NhmApplicants { get; set; }
        public virtual ICollection<NhmEmployee> NhmEmployees { get; set; }
    }
}
