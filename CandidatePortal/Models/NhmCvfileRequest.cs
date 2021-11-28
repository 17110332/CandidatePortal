using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public class NhmCvfileRequest
    {

        public int CVFileID { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public byte[] CVFile { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
