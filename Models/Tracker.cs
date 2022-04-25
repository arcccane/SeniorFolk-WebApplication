using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Seniorfolk.Models
{
    public class Tracker
    {
        [Required,Key, MinLength(3, ErrorMessage = "Enter atleast 3 characters")]
        public string Idtracker { get; set; }
        [Required]
        public string WorkoutTitle { get; set; }
        //[Required, DataType(DataType.DateTime)]
        //public DateTime ActivityDate { get; set; }
        [Required]
        public string Activities { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
        public string Remarks { get; set; }
    }
}
