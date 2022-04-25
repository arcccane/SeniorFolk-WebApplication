using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Seniorfolk.Models
{
    public class CreateGroup
    {
        [Required, Key, MinLength(5, ErrorMessage = "Enter at least 5 characters")]

        public string GroupId { get; set; }

        [Required, MinLength(1, ErrorMessage = "The Group Name field is required"), MaxLength(26)]
        public string GroupName { set; get; }

        [Required, MinLength(5, ErrorMessage = "Enter at least 5 characters")]
        public string Description { set; get; }

        [Required]
        public string User { set; get; }

        [Required, MinLength(5, ErrorMessage = "Enter at least 5 characters")]
        public string Hashtag { set; get; }

        
    }
}
