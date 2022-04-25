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
    public class VTrackerModel : PageModel
    {
        [BindProperty]
        public Tracker Tracker { get; set; }

        [BindProperty]
        public List<Tracker> alltrackers { get; set; }
        [BindProperty]
        public string Id { get; set; }

        private readonly ILogger<VTrackerModel> _logger;
        private readonly Services.TrackerService _svc;

        public VTrackerModel(ILogger<VTrackerModel> logger, Services.TrackerService service)
        {
            _logger = logger;
            _svc = service;
        }
        public void OnGet()
        {
            alltrackers = _svc.GetAllTrackers();
        }

        public IActionResult OnPost()
        {
            Tracker = _svc.GetTrackerById(Id);

            if (_svc.DeleteTracker(Tracker) == true)
            {

            }
            return RedirectToPage("VTracker");
        }
    }
}
