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
    public class RetrieveHelpModel : PageModel
    {
        [BindProperty]
        public List<Help> allRequests { get; set; }

        private readonly ILogger<RetrieveHelpModel> _logger;

        private readonly HelpService _svc;

        public RetrieveHelpModel(ILogger<RetrieveHelpModel> logger, HelpService service)
        {
            _logger = logger;
            _svc = service;
        }
        public IActionResult OnGet()
        {

            allRequests = _svc.GetAllHelp();
            return Page();

        }

        [BindProperty]
        public Help MyRequest { get; set; }

        public IActionResult OnPostDelete(int id)
        {
            MyRequest = _svc.GetRequestById(id);

            if (MyRequest != null)
            {
                if (_svc.DeleteRequest(MyRequest) == true)
                {
                    return RedirectToPage("./RetrieveHelp");
                }
                else
                    return BadRequest();
            }
            return Page();
        }
    }
}
