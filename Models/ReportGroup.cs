using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Models
{
    public class ReportGroup
    {
        public string ReportedNo { get; set; }
        [Required, Key, MinLength(5, ErrorMessage = "Enter at least 5 characters")]

        public string UserId { get; set; }

        [Required, MinLength(5, ErrorMessage = "Enter at least 5 characters")]
        public string ReportedGrpid { set; get; }

        [Required, MinLength(20, ErrorMessage = "Enter at least 20 characters")]
        public string ReportGrpReason { set; get; }

    }
}
