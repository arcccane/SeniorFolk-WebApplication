using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Seniorfolk.Pages
{
    public class UserHomeModel : PageModel
    {
        [BindProperty]
        public String PageMessage { get; set; }
        public IActionResult OnGet()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("SSName")))

            {
                PageMessage = "Welcome Back, " + HttpContext.Session.GetString("SSName");

                HttpContext.Session.Clear();
                return Page();
            }

            return Redirect("Index");

        }
    }
}
