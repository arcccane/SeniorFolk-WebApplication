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
    public class ViewReportedUserAdminModel : PageModel
    {
        [BindProperty]
        public ReportUser ReportUser { get; set; }

        [BindProperty]
        public List<ReportUser> allreportedgroups { get; set; }
        [BindProperty]
        public string Id { get; set; }

        private readonly ILogger<ViewReportedUserAdminModel> _logger;
        private readonly ReportUserService _svc;

        public ViewReportedUserAdminModel(ILogger<ViewReportedUserAdminModel> logger, ReportUserService service)
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
            ReportUser = _svc.GetUserById(Id);
            if (_svc.DeleteGroup(ReportUser) == true)
            {

            }
            return RedirectToPage("RetrieveGroup");
        }
    }
}
