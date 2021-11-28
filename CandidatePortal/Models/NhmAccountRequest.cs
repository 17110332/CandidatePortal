using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CandidatePortal.Models
{
    public class NhmAccountRequest
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [Key]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
