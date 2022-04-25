using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Seniorfolk.Models;
using Seniorfolk.Services;

namespace Seniorfolk.Pages
{
    public class RetrievePreferenceModel : PageModel
    {
        [BindProperty]
        public Preference Preference { get; set; }

        [BindProperty]
        public List<Preference> Allpreference { get; set; }
        [BindProperty]
        public string Id { get; set; }

        private readonly ILogger<RetrievePreferenceAdminModel> _logger;
        private readonly PreferenceService _svc;

        public RetrievePreferenceModel(ILogger<RetrievePreferenceModel> logger, PreferenceService service)
        {
            _logger = (ILogger<RetrievePreferenceAdminModel>)logger;
            _svc = service;

        }
        public void OnGet()
        {
            Allpreference = _svc.GetAllPreferences();
        }

        public IActionResult OnPost()
        {
            Preference = _svc.GetUserById(Id);
            if (_svc.DeletePreference(Preference) == true)
            {

            }
            return RedirectToPage("RetrievePreference");
        }
    }
}
