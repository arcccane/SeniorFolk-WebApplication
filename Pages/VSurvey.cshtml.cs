using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Seniorfolk.Models;

namespace Seniorfolk.Pages
{
    public class VSurveyModel : PageModel
    {
        [BindProperty]
        public Survey Survey { get; set; }
        [BindProperty]
        public string Id { get; set; }

        [BindProperty]
        public List<Survey> allsurveys { get; set; }

        private readonly ILogger<VSurveyModel> _logger;
        private readonly Services.SurveyService _svc;

        public VSurveyModel(ILogger<VSurveyModel> logger, Services.SurveyService service)
        {
            _logger = logger;
            _svc = service;
        }
        public void OnGet()
        {
            allsurveys = _svc.GetAllSurveys();
        }

        public IActionResult OnPost()
        {
            Survey = _svc.GetSurveyById(Id);

            if (_svc.DeleteSurvey(Survey) == true)
            {

            }
            return RedirectToPage("VSurvey");
        }
    }
}
