using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatePortal.Models
{
    public class FileRequest
    {
        [Key]
        public int  FileID { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }
        public byte[] File { get; set; }
        public string FileBase64 { get; set; }
    }
}
