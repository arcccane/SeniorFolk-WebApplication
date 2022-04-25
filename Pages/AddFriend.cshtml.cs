using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Seniorfolk.Models;


namespace Seniorfolk.Pages
{
    public class AddFriendModel : PageModel
    {

        private readonly Services.FriendService _svc;
        private readonly ILogger<RetrieveAccountsModel> _logger;
        private readonly Services.UserService _usvc;

        [BindProperty]
        public string PageMessage { get; set; }
        public string Id;

        public AddFriendModel(Services.FriendService service)
        {
            _svc = service;
        }

        public AddFriendModel(ILogger<RetrieveAccountsModel> logger, Services.UserService service)
        {
            _logger = logger;
            _usvc = service;

        }

        [BindProperty]
        public Friend Friend { get; set; }
        [BindProperty]
        public List<User> allusers { get; set; }

        [BindProperty]
        public string AlertMessage { get; set; }

        public void OnGet()
        {
            allusers = _usvc.GetAllUsers();
            Id = HttpContext.Session.GetString("Id");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string userId = HttpContext.Session.GetString("UserAccount");

                if (userId != null)
                {
                    AlertMessage = "User Id non-existent!";
                    return Page();
                }

                if (_svc.AddFriend(Friend))
                {
                    //Create Session
                    HttpContext.Session.SetString("SSName", Friend.FriendId);

                    AlertMessage = "Friend Added!";

                    return RedirectToPage("RetrieveFriend");
                }
                else
                {
                    AlertMessage = "Friend already exist!";
                    return Page();
                }
            }
            return Page();
        }
    }
}
