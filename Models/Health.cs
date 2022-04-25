using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Models
{
    public class Health
    {
        [Required(ErrorMessage = "ID is required!"), MinLength(3, ErrorMessage = "Minimum 3 characters"), MaxLength(5), Key]
        public string Idhealth { get; set; }
        [Required(ErrorMessage = "Date and Time Required!"), DataType(DataType.DateTime)]
        public DateTime DateHealthLog { get; set; }
        [Required(ErrorMessage = "BMI is required!")]
        public string Bmi { get; set; }

        public string SystolicBp { get; set; }

        public string DiastolicBp { get; set; }

        public string BeatsPm { get; set; }

        public string BeforeBreakfast { get; set; }

        public string AfterBreakfast { get; set; }

        public string BeforeLunch { get; set; }

        public string AfterLunch { get; set; }

        public string BeforeDinner { get; set; }

        public string AfterDinner { get; set; }
    }
}
