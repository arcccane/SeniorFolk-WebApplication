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
    public class ViewVoluntaryModel : PageModel
    {
        [BindProperty]
        public Volunteer MyVolunteer { get; set; }

        private VolunteerService _svc;

        public ViewVoluntaryModel(VolunteerService service)
        {
            _svc = service;
        }
        public void OnGet(string id)
        {
            if (id != null)
            {
                int a = 1;
                MyVolunteer = _svc.GetVolunteerById(id);
                a = a + 1;
            }
        }
    }
}
