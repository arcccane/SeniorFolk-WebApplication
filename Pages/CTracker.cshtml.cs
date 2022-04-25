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
    public class CTrackerModel : PageModel
    {
        private readonly Services.TrackerService _svc;

        public CTrackerModel(Services.TrackerService service)
        {
            _svc = service;
        }

        [BindProperty]
        public Tracker MyTracker { get; set; }
        [BindProperty]
        public string MyMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_svc.AddTracker(MyTracker))
                {
                    HttpContext.Session.SetString("SSWorkoutTitle", MyTracker.WorkoutTitle);
                    return RedirectToPage("ConfirmLog");
                }
                else
                {
                    MyMessage = "Track Log ID already exist!";
                    return Page();
                }
            }
            return Page();
            //if (ModelState.IsValid)
            //{
            //    HttpContext.Session.SetString("SSWorkoutTitle", MyTracker.WorkoutTitle);
            //    return RedirectToPage("ConfirmLog");
            //}
            //return Page();
        }
    }
}
