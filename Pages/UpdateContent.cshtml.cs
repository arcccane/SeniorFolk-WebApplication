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
    public class UpdateContentModel : PageModel
    {
        private readonly ContentService _csvc;
        public UpdateContentModel(ContentService cService)
        {
            _csvc = cService;
        }

        [BindProperty]
        public Content MyContent { get; set; }

        public IActionResult OnGet(int id)
        {
            MyContent = _csvc.GetContentById(id);
            if (MyContent == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (_csvc.UpdateContent(MyContent, file) == true)
                {
                    return RedirectToPage("./ViewContent");
                }
                else
                    return BadRequest();
            }
            return Page();
        }
    }
}
