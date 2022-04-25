using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Seniorfolk.Models;

namespace Seniorfolk.Pages
{
    public class ETrackerModel : PageModel
    {
        private readonly Services.TrackerService _svc;
        public ETrackerModel(Services.TrackerService service)
        {
            _svc = service;
        }

        [BindProperty]
        public Tracker MyTracker { get; set; }
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyTracker = _svc.GetTrackerById(id);
            if (MyTracker == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_svc.UpdateTracker(MyTracker) == true)
            {
                return RedirectToPage("VTracker");
            }
            else
                return BadRequest();
        }
    }
}
