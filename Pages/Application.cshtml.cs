using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Seniorfolk.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Text;
using System.Net.Http.Headers;

namespace Seniorfolk.Pages
{
    public class ApplicationModel : PageModel
    {
        private readonly Services.ApplicationService _svc;

        //private readonly Services.VolunteerService _vsvc;


        public ApplicationModel(Services.ApplicationService service)
        {
            _svc = service;
            //_vsvc = vservice;

        }

        //[BindProperty]
        //public List<Volunteer> allvolunteers { get; set; }

        //[BindProperty]
        //public Volunteer MyVolunteer { get; set; }

        [BindProperty]
        public Application MyApplication { get; set; }

        [BindProperty]
        public Email MyEmail { get; set; }

        [BindProperty]
        public string MyMessage { get; set; }


        [BindProperty]
        public string Orgname { get; set; }




        public void OnGet()
        {
            Orgname = HttpContext.Request.Query["name"].ToString();
            //allvolunteers = _vsvc.GetAllVolunteers();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            MyApplication.OrgName = HttpContext.Request.Query["name"].ToString();

            MyApplication.Status = "Unconfirmed";

            if (ModelState.IsValid)
            {
                if (_svc.AddApplication(MyApplication))
                {
                    //Orgname = HttpContext.Request.Query["name"].ToString();

                    //MyApplication.OrgName = HttpContext.Request.Query["name"].ToString();

                    //MyApplication.Status = "Unconfirmed";

                    var body = $"<p>Good day <b>{MyApplication.Name}</b>,</p><br/><p>We have received your application and will be in touch with you shortly!</p><br/><p><b>{MyApplication.OrgName}</b></p><br/><p><b>{MyApplication.Date}</b></p>"
                        ;
                    using(var smtp = new SmtpClient())
                    {
                        var googleCredential = new NetworkCredential
                        {
                            UserName = "SeniorFolk2022@gmail.com",
                            Password = "Abc@123456"

                        };
                        smtp.Credentials = googleCredential;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        var msg = new MailMessage();
                        msg.To.Add(MyApplication.Email);
                        msg.Subject = "Application Received";
                        msg.Body = body;
                        msg.IsBodyHtml = true;
                        msg.From = new MailAddress("monbebex1212@gmail.com");
                        await smtp.SendMailAsync(msg);
                    }

                    using (var httpClient = new HttpClient())
                    {
                        using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://studio.twilio.com/v2/Flows/FW0297fca571f0f57fde94b8770343a674/Executions"))
                        {
                            var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("AC790058ed37bdd3b07da2e6da810e377a:74ac205e735823dbc936588778b86932"));
                            request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                            var contentList = new List<string>();
                            contentList.Add($"To={Uri.EscapeDataString("+6591694392")}");
                            contentList.Add($"From={Uri.EscapeDataString("+18126248476")}");
                            contentList.Add($"Parameters={Uri.EscapeDataString("{\"org\":\"Willing Heart\",\"date\":\"15/5/2022\"}")}");
                            request.Content = new StringContent(string.Join("&", contentList));
                            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                            var response = await httpClient.SendAsync(request);
                        }
                    }



                    MyMessage = "Submit successfully";

                    return RedirectToPage("Successful");
                }
                else
                {
                    MyMessage = "Error!";
                    return Page();
                }

            }



            return Page();
        }

    }
}

