using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Models
{
    public class Friend
    {
        public string FriendId { get; set; }
        public string UserId { get; set; }
        public string AliasName { set; get; }
    }
}
