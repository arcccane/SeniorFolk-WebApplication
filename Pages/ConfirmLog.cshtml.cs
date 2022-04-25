using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Seniorfolk.Pages
{
    public class ConfirmLogModel : PageModel
    {
        [BindProperty]
        public String PageMessageLog { get; set; }
        public IActionResult OnGet()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("SSWorkoutTitle")))
            {
                PageMessageLog = "Title: " + HttpContext.Session.GetString("SSWorkoutTitle") + " | Activity Log Has Been Added.";
                HttpContext.Session.Clear();
                return Page();
            }
            return Redirect("CTracker");
        }
    }
}
