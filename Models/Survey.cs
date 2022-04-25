using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Models
{
    public class Survey
    {
        [Required(ErrorMessage = "Survey id required"), MinLength(3, ErrorMessage = "Minimum 3 characters"), MaxLength(5), Key]
        public string Surveyid { get; set; }
        [Required(ErrorMessage = "Title required!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Suggestions required!")]
        public string Suggestions { get; set; }
    }
}
