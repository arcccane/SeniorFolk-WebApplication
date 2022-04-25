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
    public class CreateReportUserModel : PageModel
    {
        private readonly Services.ReportUserService _svc;

        public CreateReportUserModel(Services.ReportUserService service)
        {
            _svc = service;
        }

        [BindProperty]
        public ReportUser ReportUser { get; set; }

        [BindProperty]
        public string AlertMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                if (_svc.AddUserReport(ReportUser))
                {
                    //Create Session
                    HttpContext.Session.SetString("SSNo", ReportUser.ReportedNo);

                    AlertMessage = "Report created!";

                    return RedirectToPage("RetrieveFriend");
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

