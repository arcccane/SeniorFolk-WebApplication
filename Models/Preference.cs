using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Models
{
    public class Preference
    {
        [Required, Key, MinLength(5, ErrorMessage = "Enter at least 5 characters")]

        public string PreferenceId { get; set; }

        [Required, MinLength(5, ErrorMessage = "Enter at least 5 characters")]
        public string UserId { set; get; }

        [Required, MinLength(5, ErrorMessage = "Enter at least 5 characters")]
        public string PreferenceTag { set; get; }
    }
}
