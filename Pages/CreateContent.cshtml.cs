using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Seniorfolk.Models;
using Seniorfolk.Services;

namespace Seniorfolk.Pages
{
    public class CreateContentModel : PageModel
    {
        private readonly ContentService _csvc;
        public CreateContentModel(ContentService cService)
        {
            _csvc = cService;
        }

        [BindProperty]
        public Content MyContent { get; set; }

        public IActionResult OnPost(IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string userId = HttpContext.Session.GetString("UserAccount");

                if (userId != null)
                {
                    if (_csvc.AddContent(MyContent, userId, file))
                    {
                        return RedirectToPage("Content");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }

            return Page();
        }
        public void OnGet()
        {
        }
    }
}
