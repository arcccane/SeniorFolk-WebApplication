using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Seniorfolk.Models
{
    public class Content
    {
        public int ContentId { get; set; }

        public string UserId { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Title is too long!")]
        public string Title { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }

        public byte[] File { get; set; }

        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
