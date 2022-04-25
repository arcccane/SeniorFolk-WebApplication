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
    public class RetrieveVolunteersModel : PageModel
    {
        [BindProperty]
        public List<Volunteer> allvolunteers { get; set; }

        [BindProperty]
        public Volunteer MyVolunteer { get; set; }

        public String Id;

        private readonly ILogger<RetrieveVolunteersModel> _logger;
        private readonly VolunteerService _svc;

        public RetrieveVolunteersModel(ILogger<RetrieveVolunteersModel> logger, VolunteerService service)
        {
            _logger = logger;
            _svc = service;

        }
        public void OnGet()
        {
            allvolunteers = _svc.GetAllVolunteers();
            Id = HttpContext.Session.GetString("Id");
        }
    }
}
