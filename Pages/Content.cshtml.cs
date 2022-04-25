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
    public class ContentModel : PageModel
    {
        [BindProperty]
        public List<Content> allContent { get; set; }

        private readonly ILogger<ContentModel> _logger;

        private readonly ContentService _svc;

        public ContentModel(ILogger<ContentModel> logger, ContentService service)
        {
            _logger = logger;
            _svc = service;
        }
        public IActionResult OnGet()
        {
            allContent = _svc.GetAllContent();
            return Page();
        }
    }
}
