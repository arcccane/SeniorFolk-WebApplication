using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Seniorfolk.Models;
using Seniorfolk.Services;

namespace Seniorfolk.Pages
{
    public class RetrieveApplicationModel : PageModel
    {
        [BindProperty]
        public List<Application> allapplications { get; set; }

        [BindProperty]
        public Application MyApplication { get; set; }

        public String Id;

        private readonly ILogger<RetrieveApplicationModel> _logger;
        private readonly ApplicationService _svc;

        public RetrieveApplicationModel(ILogger<RetrieveApplicationModel> logger, ApplicationService service)
        {
            _logger = logger;
            _svc = service;

        }

        public void OnGet()
        {
            allapplications = _svc.GetAllApplications();
            Id = HttpContext.Session.GetString("Id");
        }

        public IActionResult OnPost(string id)
        {
            if (_svc.DeleteApplication(MyApplication) == true)
            {
                return RedirectToPage("./RetrieveApplications");
            }
            return Page();
        }
    }
}
