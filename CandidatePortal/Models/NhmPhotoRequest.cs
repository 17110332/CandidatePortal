using System;
using System.Collections.Generic;

#nullable disable

namespace CandidatePortal.Models
{
    public class NhmPhotoRequest
    {
        public int PhotoID { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
