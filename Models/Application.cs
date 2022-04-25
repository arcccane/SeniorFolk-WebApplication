using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Models
{
    public class Application
    {
        [Required, Key, MinLength(5, ErrorMessage = "Enter at least 5 characters")]

        public string Id { get; set; }

        [Required, RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "invalid Email format")]
        public string Email { set; get; }

        [Required]
        public string Gender { set; get; }


        [Required, MinLength(1, ErrorMessage = "The Name field is required"), MaxLength(26)]
        public string Name { set; get; }

        [Required, DataType(DataType.Date)]
        public DateTime Date { set; get; }


        [Required, MinLength(8, ErrorMessage = "Must have a minimum length of 8 characters"), DataType(DataType.PhoneNumber)]
        public string Mobile { set; get; }

        [Required]
        public string OrgName { set; get; }

        [Required]
        public string Status { set; get; }

    }
}
