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
    public class CreateReportGroupModel : PageModel
    {
        private readonly Services.ReportGroupService _svc;

        public CreateReportGroupModel(Services.ReportGroupService service)
        {
            _svc = service;
        }

        [BindProperty]
        public ReportGroup ReportGroup { get; set; }

        [BindProperty]
        public string AlertMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                if (_svc.AddGroupReport(ReportGroup))
                {
                    //Create Session
                    HttpContext.Session.SetString("SSNo", ReportGroup.ReportedNo);

                    AlertMessage = "Report created!";

                    return RedirectToPage("RetrieveGroup");
                }
                else
                {
                    AlertMessage = "Report already exist!";
                    return Page();
                }

            }
            return Page();
        }
    }
}
