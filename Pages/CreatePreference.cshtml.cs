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
    public class CreatePreferenceModel : PageModel
    {
        private readonly PreferenceService _svc;

        public CreatePreferenceModel(PreferenceService service)
        {
            _svc = service;
        }

        [BindProperty]
        public Preference Preference { get; set; }

        [BindProperty]
        public string AlertMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string userId = HttpContext.Session.GetString("UserAccount");

                if (userId != null)
                {
                    AlertMessage = "User Id non-existent!";
                    return Page();
                }

                if (_svc.AddPreference(Preference))
                {
                    //Create Session
                    HttpContext.Session.SetString("SSPreference", Preference.PreferenceId);

                    AlertMessage = "Preference created!";

                    return RedirectToPage("RetrievePreference");
                }
                else
                {
                    AlertMessage = "Preference already exist!";
                    return Page();
                }
            }
            return Page();
        }
    }
}

