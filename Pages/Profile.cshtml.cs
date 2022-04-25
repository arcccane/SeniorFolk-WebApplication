using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Seniorfolk.Models;
using Seniorfolk.Services;

namespace Seniorfolk.Pages
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public User MyUser { get; set; }

        private UserService _svc;

        public ProfileModel(UserService service)
        {
            _svc = service;
        }
        public void OnGet(string id)
        {
            if (id != null)
            {
                int a = 1;
                MyUser = _svc.GetUserById(id);
                a = a + 1;
            }
        }
    }
}
