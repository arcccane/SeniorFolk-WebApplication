using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Models
{
    public class ReportUser
    {
        public string ReportedNo { get; set; }
        [Required, Key, MinLength(5, ErrorMessage = "Enter at least 5 characters")]

        public string UserId { get; set; }

        [Required, MinLength(5, ErrorMessage = "Enter at least 5 characters")]
        public string ReportedUserid { set; get; }

        [Required, MinLength(20, ErrorMessage = "Enter at least 20 characters")]
        public string ReportUserReason { set; get; }

    }
}

