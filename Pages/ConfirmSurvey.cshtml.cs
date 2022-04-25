using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Seniorfolk.Pages
{
    public class ConfirmSurveyModel : PageModel
    {
        [BindProperty]
        public string SurveyPageMessage { get; set; }
        public IActionResult OnGet()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("STitle")))
            {
                SurveyPageMessage = "Title: " + HttpContext.Session.GetString("STitle") + " | Feedback has been submitted";
                HttpContext.Session.Clear();
                return Page();
            }
            return Redirect("CSurvey");
        }
    }
}
