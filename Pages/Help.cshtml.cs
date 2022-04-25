using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Seniorfolk.Models;
using Seniorfolk.Services;

namespace Seniorfolk.Pages
{
    public class HelpModel : PageModel
    {
        private readonly HelpService _hsvc;
        private readonly UserService _usvc;

        public HelpModel(HelpService hService, UserService uService)
        {
            _hsvc = hService;
            _usvc = uService;
        }

        [BindProperty]
        public Help MyHelp { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string userId = HttpContext.Session.GetString("UserAccount");

                if (userId != null)
                {
                    string email = _usvc.GetUserById(userId).Email;
                    string mobile = _usvc.GetUserById(userId).Mobile;

                    if (_hsvc.AddHelp(MyHelp, userId, email, mobile))
                    {
                        return RedirectToPage("./Index");

                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            return NotFound();
        }

        public void OnGet()
        {
        }
    }
}
