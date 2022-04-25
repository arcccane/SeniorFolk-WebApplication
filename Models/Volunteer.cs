using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Models
{
    public class Volunteer
    {
        [Required, Key, MinLength(3, ErrorMessage = "Enter at least 3 characters")]
        public string Id { get; set; }

        [Required, MinLength(1, ErrorMessage = "Required")]
        public string OrganisationName { get; set; }

        [Required, MinLength(1, ErrorMessage = "Required")]
        public string Description { get; set; }

        [Required, MinLength(1, ErrorMessage = "Required")]
        public string Address { get; set; }

        [Required, DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required, DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        public string ImageName { get; set; }

        public string ImageType { get; set; }

        public byte[] Image { get; set; }

        //[Required]
        //public IFormFile File { get; set; }




    }
}
