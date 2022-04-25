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
    public class CreateGroupModel : PageModel
    {
        
        private readonly Services.GroupService _svc;

        public CreateGroupModel(Services.GroupService service)
        {
            _svc = service;
        }

        [BindProperty]
        public CreateGroup CreateGroup { get; set; }

        [BindProperty]
        public string AlertMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string userId = HttpContext.Session.GetString("UserAccount");

                if (userId != null)
                {
                    AlertMessage = "User Id non-existent!";
                    return Page();
                }

                if (_svc.AddGroup(CreateGroup))
                {
                    //Create Session
                    HttpContext.Session.SetString("SSName", CreateGroup.GroupName);

                    AlertMessage = "Group created!";

                    return RedirectToPage("RetrieveGroup");
                }
                else
                {
                    AlertMessage = "Group already exist!";
                    return Page();
                }
            }
            return Page();
        }
    }
}

