using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Seniorfolk.Models;
using Seniorfolk.Services;

namespace Seniorfolk.Pages
{
    public class ViewContentModel : PageModel
    {
        [BindProperty]
        public List<Content> viewContent { get; set; }

        private readonly ILogger<ContentModel> _logger;

        private readonly ContentService _csvc;

        public ViewContentModel(ILogger<ContentModel> logger, ContentService service)
        {
            _logger = logger;
            _csvc = service;
        }

        [BindProperty]
        public Content MyContent { get; set; }

        [BindProperty]
        public List<Comments> MyComments { get; set; }

        public void OnGet()
        {
            string userId = HttpContext.Session.GetString("UserAccount");
            if (userId != null)
            {
                viewContent = _csvc.GetAllContentByUserId(userId);
            }
        }

        public IActionResult OnPostDelete(int id)
        {
            MyContent = _csvc.GetContentById(id);
            MyComments = _csvc.GetAllCommentsById(id);

            if (MyContent != null)
            {
                if (_csvc.DeleteContent(MyContent, MyComments) == true)
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
