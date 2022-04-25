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
    public class VDSurveyModel : PageModel
    {
        [BindProperty]
        public Survey MySurvey { get; set; }
        private SurveyService _svc;

        public VDSurveyModel(SurveyService service)
        {
            _svc = service;
        }
        public void OnGet(string id)
        {
            if (id != null)
            {
                MySurvey = _svc.GetSurveyById(id);
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("VSurvey");
        }
    }
}
