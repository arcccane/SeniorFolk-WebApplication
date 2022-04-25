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
    public class ViewAccountDetailsModel : PageModel
    {
        [BindProperty]
        public User MyUser { get; set; }

        private UserService _svc;

        public ViewAccountDetailsModel(UserService service)
        {
            _svc = service;
        }

            

        public void OnGet(string id)
        {
            if (id != null)
            {
                int a = 1;
                MyUser = _svc.GetUserById(id);
                a = a + 1;
            }
        }

        public IActionResult OnPost()
        {
            //var errors = ModelState.Where(a => a.Value.Errors.Count > 0)
            //    .Select(b => new { b.Key, b.Value.Errors })
            //    .ToArray();

            //foreach (var modelStateErrors in errors)
            //{
            //    System.Diagnostics.Debug.WriteLine("...Errored When Binding.", modelStateErrors.Key.ToString());
            //    System.Diagnostics.Debug.WriteLine("...Errored When Binding.", modelStateErrors.Errors[0].ToString());
            //}

            //string validationErrors = string.Join(",",
            //        ModelState.Values.Where(E => E.Errors.Count > 0)
            //        .SelectMany(E => E.Errors)
            //        .Select(E => E.ErrorMessage)
            //        .ToArray());

            //System.Diagnostics.Debug.WriteLine("...Errored When Binding.", validationErrors);

            if (_svc.DeleteUser(MyUser) == true)
            {
                return RedirectToPage("./RetrieveAccounts");
            }
            return Page();

            //if (ModelState.IsValid)
            //{
            //    if (_svc.DeleteUser(MyUser) == true)
            //    {
            //        return RedirectToPage("./RetrieveAccounts");
            //    }
            //    return Page();
            //}
            //else
            //{
            //    return BadRequest();
            //}
        }
    }
}
