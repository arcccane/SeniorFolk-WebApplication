using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Seniorfolk.Pages
{
    public class ConfirmHealthModel : PageModel
    {
        [BindProperty]
        public string HealthPageMessage { get; set; }
        public IActionResult OnGet()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("SHId")))
            {
                HealthPageMessage = "ID: " + HttpContext.Session.GetString("SHId") + " | Health log has been submitted";
                HttpContext.Session.Clear();
                return Page();
            }
            return Redirect("CHealth");
        }
    }
}
