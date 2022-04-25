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
    public class CHealthModel : PageModel
    {
        private readonly Services.HealthService _svc;

        public CHealthModel(Services.HealthService service)
        {
            _svc = service;
        }
        [BindProperty]
        public Health MyHealth { get; set; }
        [BindProperty]
        public string MyHMessage { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_svc.AddHealth(MyHealth))
                {
                    HttpContext.Session.SetString("SHId", MyHealth.Idhealth);
                    return RedirectToPage("ConfirmHealth");
                }
                else
                {
                    MyHMessage = "Health Log ID exists!";
                    return Page();
                }
            }
            return Page();
        }
    }
}
