using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Models
{
    public class Help
    {
        public int HelpId { get; set; }

        public string UserId { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        [Required, MaxLength(300, ErrorMessage = "Message is too long!")]
        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
