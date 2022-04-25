using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Seniorfolk.Models;

namespace Seniorfolk.Pages
{
    public class EHealthModel : PageModel
    {
        private readonly Services.HealthService _svc;

        public EHealthModel(Services.HealthService service)
        {
            _svc = service;
        }

        [BindProperty]
        public Health MyHealth { get; set; }
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyHealth = _svc.GetHealthById(id);
            if (MyHealth == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_svc.UpdateHealth(MyHealth) == true)
            {
                return RedirectToPage("VHealth");
            }
            else
                return BadRequest();
        }
    }
}
