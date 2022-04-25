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
    public class EditVolunteerModel : PageModel
    {
        private readonly VolunteerService _svc;

        public EditVolunteerModel(VolunteerService service)
        {
            _svc = service;
        }

        [BindProperty]
        public Volunteer MyVolunteer { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyVolunteer = _svc.GetVolunteerById(id);

            if (MyVolunteer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(IFormFile image)
        {
            
           

            if (ModelState.IsValid)
            {
                if (_svc.UpdateVolunteer(MyVolunteer,image) == true)
                {
                    return RedirectToPage("./RetrieveVolunteerAdmin");
                }

                if (_svc.DeleteVolunteer(MyVolunteer) == true)
                {
                    return RedirectToPage("./RetrieveVolunteerAdmin");
                }



            }

            else
            {
                return BadRequest();
            }

            return Page();
        }

    }
}
