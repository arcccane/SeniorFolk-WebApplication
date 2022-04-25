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
    public class CommentsModel : PageModel
    {
        private readonly ContentService _csvc;
        public CommentsModel(ContentService cService)
        {
            _csvc = cService;
        }

        [BindProperty]
        public Content MyContent { get; set; }

        [BindProperty]
        public List<Comments> viewComments { get; set; }

        [BindProperty]
        public Comments MyComment { get; set; }

        public IActionResult OnGet(int id)
        {
            MyContent = _csvc.GetContentById(id);
            viewComments = _csvc.GetAllCommentsById(id);
            if (MyContent == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostComment()
        {
            string userId = HttpContext.Session.GetString("UserAccount");

            if (userId != null)
            {
                if (_csvc.AddComment(MyComment, userId))
                {
                    return RedirectToPage("./Comments");
                }
            }
            return NotFound();
        }
    }
}
