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
    public class CSurveyModel : PageModel
    {
        private readonly Services.SurveyService _svc;

        public CSurveyModel(Services.SurveyService service)
        {
            _svc = service;
        }

        [BindProperty]
        public Survey MySurvey { get; set; }
        [BindProperty]
        public string MySMessage { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_svc.AddSurvey(MySurvey))
                {
                    HttpContext.Session.SetString("STitle", MySurvey.Title);
                    return RedirectToPage("ConfirmSurvey");
                }
                else
                {
                    MySMessage = "Survey ID already exists!";
                    return Page();
                }
            }
            return Page();
        }
    }
}
