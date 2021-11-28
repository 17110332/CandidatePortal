using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatePortal.Models
{
    public class Language
    {
        [Key]
        public long RowNum { get; set; }
        public string LanguageItem { get; set; }
    }
}
