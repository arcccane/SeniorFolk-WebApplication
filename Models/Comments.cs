using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string UserId { get; set; }
        public int ContentId { get; set; }

        [Required, MaxLength(200, ErrorMessage = "Comment is too long!")]
        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
