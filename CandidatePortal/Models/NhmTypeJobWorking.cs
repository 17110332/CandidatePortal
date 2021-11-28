using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public partial class NhmTypeJobWorking
    {
        public NhmTypeJobWorking()
        {
            NhmRecruits = new HashSet<NhmRecruit>();
        }

        public string TypeJobWCode { get; set; }
        public string TypeJobWName { get; set; }
        public string TypeJobWName2 { get; set; }
        public string LocationCode { get; set; }

        public virtual NhmProvince LocationCodeNavigation { get; set; }
        public virtual ICollection<NhmRecruit> NhmRecruits { get; set; }
    }
}
