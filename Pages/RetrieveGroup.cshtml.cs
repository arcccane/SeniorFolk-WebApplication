using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Seniorfolk.Models;
using Seniorfolk.Services;

namespace Seniorfolk.Pages
{
    public class RetrieveGroupModel : PageModel
    {
        [BindProperty]
        public CreateGroup CreateGroup { get; set; }

        [BindProperty]
        public List<CreateGroup> allgroups { get; set; }
        [BindProperty]
        public string Id { get; set; }

        private readonly ILogger<RetrieveGroupModel> _logger;
        private readonly GroupService _svc;

        public RetrieveGroupModel(ILogger<RetrieveGroupModel> logger, GroupService service)
        {
            _logger = logger;
            _svc = service;

        }
        public void OnGet()
        {
            allgroups = _svc.GetAllGroups();
        }

        public IActionResult OnPost()
        {
            CreateGroup = _svc.GetUserById(Id);
            if (_svc.DeleteGroup(CreateGroup) == true)
            {
                
            }
            return RedirectToPage("RetrieveGroup");
        }
    }
}
