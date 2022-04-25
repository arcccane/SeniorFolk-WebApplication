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
    public class RetrieveFriendModel : PageModel
    {
        [BindProperty]
        public Friend Friend { get; set; }

        [BindProperty]
        public List<Friend> Allfriends{ get; set; }
        [BindProperty]
        public string Id { get; set; }

        private readonly ILogger<RetrieveFriendModel> _logger;
        private readonly FriendService _svc;

        public RetrieveFriendModel(ILogger<RetrieveFriendModel> logger, FriendService service)
        {
            _logger = logger;
            _svc = service;

        }
        public void OnGet()
        {
            Allfriends = _svc.GetAllFriends();
        }

        public IActionResult OnPost()
        {
            Friend = _svc.GetUserById(Id);
            if (_svc.DeleteFriend(Friend) == true)
            {

            }
            return RedirectToPage("RetrieveFriend");
        }
    }
}
