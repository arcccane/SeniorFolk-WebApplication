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
    public class CreateVolunteerModel : PageModel
    {
        private readonly Services.VolunteerService _svc;

        public CreateVolunteerModel(Services.VolunteerService service)
        {
            _svc = service;
        }

        [BindProperty]
        public Volunteer MyVolunteer { get; set; }

        [BindProperty]
        public string MyMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost(IFormFile image)
        {
            if (ModelState.IsValid)
            {

                if (_svc.AddVolunteer(MyVolunteer, image))
                {
                    ////Create Session
                    //HttpContext.Session.SetString("VName", MyVolunteer.OrganisationName);

                    MyMessage = "Voluntary created!";

                    return RedirectToPage("/AdminHome");
                }
                else
                {
                    MyMessage = "Voluntary already exist!";
                    return Page();
                }
            }
            return Page();

        }
    }
}
