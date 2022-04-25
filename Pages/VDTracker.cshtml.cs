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
    public class VDTrackerModel : PageModel
    {
        [BindProperty]
        public Tracker MyTracker { get; set; }
        private TrackerService _svc;

        public VDTrackerModel(TrackerService service)
        {
            _svc = service;
        }
        public void OnGet(string id)
        {
            if (id != null)
            {
                MyTracker = _svc.GetTrackerById(id);
            }
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("VTracker");
        }
    }
}
