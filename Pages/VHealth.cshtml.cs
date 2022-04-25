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
    public class VHealthModel : PageModel
    {
        [BindProperty]
        public Health Health { get; set; }
        [BindProperty]
        public string Id { get; set; }


        [BindProperty]
        public List<Health> allhealths { get; set; }

        private readonly ILogger<VHealthModel> _logger;
        private readonly Services.HealthService _svc;

        public VHealthModel(ILogger<VHealthModel> logger, Services.HealthService service)
        {
            _logger = logger;
            _svc = service;
        }
        public void OnGet()
        {
            allhealths = _svc.GetAllHealths();
        }

        public IActionResult OnPost()
        {
            Health = _svc.GetHealthById(Id);

            if (_svc.DeleteHealth(Health) == true)
            {

            }
            return RedirectToPage("VHealth");
        }
    }
}
