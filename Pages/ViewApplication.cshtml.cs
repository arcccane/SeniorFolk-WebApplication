using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Seniorfolk.Models;
using Seniorfolk.Services;

namespace Seniorfolk.Pages
{
    public class ViewApplicationModel : PageModel
    {

        [BindProperty]
        public Application MyApplication { get; set; }

        private ApplicationService _svc;

        public ViewApplicationModel(ApplicationService service)
        {
            _svc = service;
        }

        public void OnGet(string id)
        {
            if (id != null)
            {
                int a = 1;
                MyApplication = _svc.GetApplicationById(id);
                a = a + 1;
            }
        }

        public IActionResult OnPost()
        {
            if (_svc.DeleteApplication(MyApplication) == true)
            {
                return RedirectToPage("./RetrieveApplication");
            }
            return Page();
        }
    }
}
