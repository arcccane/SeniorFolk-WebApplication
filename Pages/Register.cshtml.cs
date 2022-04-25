using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Seniorfolk.Models;

namespace Seniorfolk.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly Services.UserService _svc;

        public RegisterModel(Services.UserService service)
        {
            _svc = service;
        }

        [BindProperty]
        public User MyUser { get; set; }

        [BindProperty]
        public string MyMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_svc.AddUser(MyUser))
                {
                    //Create Session
                    HttpContext.Session.SetString("SSName", MyUser.Name);

                    MyMessage = "Account created! Please Login";

                    return RedirectToPage("Index");
                }
                else
                {
                    MyMessage = "Username already exist!";
                    return Page();
                }
                
            }
            return Page();
        }
    }
}
