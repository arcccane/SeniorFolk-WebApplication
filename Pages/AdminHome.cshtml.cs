using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace Seniorfolk.Pages
{
    public class AdminHomeModel : PageModel
    {

            public string Id;
            //private readonly ILogger<IndexModel> _logger;
            //private UserService _svc;

            //public IndexModel(ILogger<IndexModel> logger, UserService service)
            //{
            //    _logger = logger;
            //    _svc = service;
            //}

            public void OnGet()
            {
                Id = HttpContext.Session.GetString("Id");
            }
        
    }
}
