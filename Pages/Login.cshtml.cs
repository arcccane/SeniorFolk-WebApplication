using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using Seniorfolk.Models;

namespace Seniorfolk.Pages
{
    public class LoginModel : PageModel
    {
        //[BindProperty]
        //public Login LoginUser { get; set; }

        [BindProperty]
        public User MyUser { get; set; }

        [BindProperty]
        public string Id { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Msg { get; set; }


        private readonly Services.UserService _svc;

        public LoginModel(Services.UserService service)
        {
            _svc = service;
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Id");
            return Page();
        }

        public IActionResult OnPost()
        {
            User userid = _svc.GetUserById(Id);
            User userpw = _svc.GetUserByPassword(Password);
            if (userid != null)
            {
                if (userpw != null)
                {
                    if (userid.Id.Contains("Admin"))
                    {
                        HttpContext.Session.SetString("UserAccount", userid.Id);
                        return Redirect("AdminHome");
                    }
                    else
                    {
                        HttpContext.Session.SetString("UserAccount", userid.Id);
                        return Redirect("Content");
                    }
                }
                else
                {
                    Msg = "User ID or password is incorrect";
                }

                //if (userpw != null)
                //{
                //    //if (userid.Id.Contains("Admin"))
                //    //{
                //    //    HttpContext.Session.SetString("UserAccount", userid.Id);
                //    //    return Redirect("CreateVolunteer");

                //    //}

                //    HttpContext.Session.SetString("UserAccount", userid.Id);
                //    return Redirect("Index");
                //}


            }
            else {
                Msg = "Account not found!";
            }
            return Page();
        }

        //public IActionResult OnPost()
        //{
        //    if (Id.Equals("abc") && Password.Equals("123"))
        //    {
        //        HttpContext.Session.SetString("Id", Id);
        //        return RedirectToPage("Index");
        //    }
        //    else if (Id.Equals("admin1") && Password.Equals("123"))
        //    {
        //        HttpContext.Session.SetString("Id", Id);
        //        return RedirectToPage("RetrieveAccounts");
        //    }
        //    else
        //    {
        //        Msg = "Incorrect password or user id";

        //        return Page();
        //    }
        //}

        //public IActionResult OnPost()
        //{

        //    DataTable dtbl = new DataTable();
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ToString());



        //    //SqlConnection conn = new SqlConnection(MYDBConnectionString);
        //    //string query = string.Format("SELECT * from Register WHERE Email = '{0}'", loginemail_tb.Text.Trim());
        //    //SqlDataAdapter sda = new SqlDataAdapter(query, conn);
        //    //DataTable dtbl = new DataTable();
        //    //sda.Fill(dtbl);


        //}
    }
}
