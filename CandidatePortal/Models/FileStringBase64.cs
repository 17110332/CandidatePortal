using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace CandidatePortal.Models
{
    public class FileStringBase64
    {
        [Key]
        public string FileBase64String { get; set; }
        // public IFormFile FileUpload { get; set; }
        //   public List<IFormFile> ListFileUpload { get; set; }
    }
}
