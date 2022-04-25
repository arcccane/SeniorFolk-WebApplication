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
    public class UpdatePreferenceModel : PageModel
    {
        [BindProperty]
        public Preference Preference { get; set; }


        private PreferenceService _svc;

        public UpdatePreferenceModel(PreferenceService service)
        {

            _svc = service;


        }
        public void OnGet(string id)
        {
            if (id != null)
            {
                int a = 1;
                Preference = _svc.GetUserById(id);
                a = a + 1;
            }
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_svc.UpdatedPreference(Preference))
            {
                return RedirectToPage("RetrievePreference");
            }

            else
            {
                return BadRequest();
            }

        }
    }
}
