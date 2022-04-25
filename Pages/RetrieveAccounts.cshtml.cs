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
    public class RetrieveAccountsModel : PageModel
    {
         [BindProperty]
        public string PageMessage { get; set; }

        [BindProperty]
        public List<User> allusers { get; set; }

        public string Id;

        private readonly ILogger<RetrieveAccountsModel> _logger;
        private readonly UserService _svc;

        public RetrieveAccountsModel(ILogger<RetrieveAccountsModel> logger, UserService service)
        {
            _logger = logger;
            _svc = service;

        }
        public void OnGet()
        {
            allusers = _svc.GetAllUsers();
            Id = HttpContext.Session.GetString("Id");

        }

        public void OnPost()
        {

        }
    }
}
