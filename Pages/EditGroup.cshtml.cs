using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Seniorfolk.Models;
using Seniorfolk.Services;


namespace Seniorfolk.Pages
{
    public class EditGroupModel : PageModel
    {
        [BindProperty]
        public CreateGroup CreateGroup { get; set; }


        private GroupService _svc;

        public EditGroupModel(GroupService service)
        {

            _svc = service;


        }
        public void OnGet(string id)
        {
            if (id != null)
            {
                int a = 1;
                CreateGroup = _svc.GetUserById(id);
                a = a + 1;
            }
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_svc.UpdatedGroup(CreateGroup))
            {
                return RedirectToPage("RetrieveGroup");
            }

            else
            {
                return BadRequest();
            }

        }
    }
}
