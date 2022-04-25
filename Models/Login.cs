using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Seniorfolk.Models
{
    public class Login
    {
        [Required(ErrorMessage = "User ID required")]
        public string Id { get; set; }

        [DataType(DataType.Password)]

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}
