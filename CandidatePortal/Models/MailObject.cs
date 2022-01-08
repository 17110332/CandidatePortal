using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace CandidatePortal.Models
{
    public class MailObject
    {
        [Key]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
