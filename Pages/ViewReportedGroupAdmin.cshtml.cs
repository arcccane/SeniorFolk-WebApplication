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
    public class ViewReportedGroupAdminModel : PageModel
    {
        [BindProperty]
        public ReportGroup ReportGroup { get; set; }

        [BindProperty]
        public List<ReportGroup> allreportedgroups { get; set; }
        [BindProperty]
        public string Id { get; set; }

        private readonly ILogger<ViewReportedGroupAdminModel> _logger;
        private readonly ReportGroupService _svc;

        public ViewReportedGroupAdminModel(ILogger<ViewReportedGroupAdminModel> logger, ReportGroupService service)
        {
            _logger = logger;
            _svc = service;

        }
        public void OnGet()
        {
            allreportedgroups = _svc.GetAllReports();
        }

        public IActionResult OnPost()
        {
            ReportGroup = _svc.GetUserById(Id);
            if (_svc.DeleteGroup(ReportGroup) == true)
            {

            }
            return RedirectToPage("RetrieveGroup");
        }
    }
}
