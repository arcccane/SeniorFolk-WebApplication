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
    public class EditAccountDetailsModel : PageModel
    {
        private readonly UserService _svc;

        public EditAccountDetailsModel(UserService service)
        {
            _svc = service;
        }

        [BindProperty]
        public User MyUser { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyUser = _svc.GetUserById(id);

            if(MyUser == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_svc.UpdateUser(MyUser) == true)
                {
                    return RedirectToPage("./RetrieveAccounts");
                }
               

                return Page();
            }
            else
            {
                return BadRequest();
            }
        }

        

    }
}


