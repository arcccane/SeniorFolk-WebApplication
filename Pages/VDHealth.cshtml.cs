using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Seniorfolk.Models;
using Seniorfolk.Services;

namespace Seniorfolk.Pages
{
    public class VDHealthModel : PageModel
    {
        [BindProperty]
        public string AnalyseSBP { get; set; }
        [BindProperty]
        public string AnalyseSBPbad { get; set; }
        [BindProperty]
        public string AnalyseDBP { get; set; }
        [BindProperty]
        public string AnalyseDBPbad { get; set; }

        [BindProperty]
        public string AnalyseBB { get; set; }
        [BindProperty]
        public string AnalyseBBbad { get; set; }
        [BindProperty]
        public string AnalyseAB { get; set; }
        [BindProperty]
        public string AnalyseABbad { get; set; }
        [BindProperty]
        public string AnalyseBL { get; set; }
        [BindProperty]
        public string AnalyseBLbad { get; set; }
        [BindProperty]
        public string AnalyseAL { get; set; }
        [BindProperty]
        public string AnalyseALbad { get; set; }
        [BindProperty]
        public string AnalyseBD { get; set; }
        [BindProperty]
        public string AnalyseBDbad { get; set; }
        [BindProperty]
        public string AnalyseAD { get; set; }
        [BindProperty]
        public string AnalyseADbad { get; set; }


        [BindProperty]
        public Health MyHealth { get; set; }

        private HealthService _svc;

        public VDHealthModel(HealthService service)
        {
            _svc = service;
        }
        public void OnGet(string id)
        {
            if (id != null)
            {
                MyHealth = _svc.GetHealthById(id);
            }
            
            if (MyHealth.SystolicBp == "120")
            {
                AnalyseSBP = "Systolic blood pressure is optimal for a healthy adult! (120 mmHg)";
            }
            else
            {
                AnalyseSBPbad = "Systolic blood pressure is not in the optimal 120 mmHg. If below 100 mmHg OR around 140 mmhg, monitor your health and check with a Doctor if needed.";
            }

            if (MyHealth.DiastolicBp == "80")
            {
                AnalyseDBP = "Diastolic blood pressure is optimal for a healthy adult! (80mmHg)";
            }
            else
            {
                AnalyseDBPbad = "Diastolic blood pressure is not in the optimal 80 mmHg. If below 70 mmHg OR around 90 mmhg, monitor your health and check with a Doctor if needed.";
            }

            var list = new string[] {"4", "4.0", "4.1", "4.2", "4.3", "4.4", "4.5", "4.6", "4.7", "4.8", "4.9", "5", "5.0", "5.1", "5.2", "5.3", "5.4", "5.5", "5.6", "5.7", "5.8", "5.9", "6", "6.0"};
            var list2 = new string[] {"6.1", "6.2", "6.3", "6.4", "6.5", "6.6", "6.7", "6.8", "6.9", "7", "7.0", "7.1", "7.2", "7.3", "7.4", "7.5", "7.6", "7.7", "7.8", "7.9", "8", "8.0" };
            var list3 = new string[] { "8.1", "8.2", "8.3", "8.4", "8.5", "8.6", "8.7", "8.8", "8.9", "9", "9.0", "9.1", "9.2", "9.3", "9.4", "9.5", "9.6", "9.7", "9.8", "9.9", "10", "10.0" };

            if (list.Contains(MyHealth.BeforeBreakfast))
            {
                AnalyseBB = "Your blood sugar level is in optimal range! (before breakfast)";
            }
            else if (list2.Contains(MyHealth.BeforeBreakfast))
            {
                AnalyseBB = "Your blood sugar is in a good range! (before breakfast)";
            }
            else if (list3.Contains(MyHealth.BeforeBreakfast))
            {
                AnalyseBB = "Your blood sugar is in acceptable range! (before breakfast)";
            }
            else
            {
                AnalyseBBbad = "Your blood sugar level is poor/bad! (before breakfast)";
            }

            if (list.Contains(MyHealth.BeforeLunch))
            {
                AnalyseBL = "Your blood sugar level is in optimal range! (before lunch)";
            }
            else if (list2.Contains(MyHealth.BeforeLunch))
            {
                AnalyseBL = "Your blood sugar is in a good range! (before lunch)";
            }
            else if (list3.Contains(MyHealth.BeforeLunch))
            {
                AnalyseBL = "Your blood sugar is in acceptable range! (before lunch)";
            }
            else
            {
                AnalyseBLbad = "Your blood sugar level is poor/bad! (before lunch)";
            }

            if (list.Contains(MyHealth.BeforeDinner))
            {
                AnalyseBD = "Your blood sugar level is in optimal range! (before dinner)";
            }
            else if (list2.Contains(MyHealth.BeforeDinner))
            {
                AnalyseBD = "Your blood sugar is in a good range! (before dinner)";
            }
            else if (list3.Contains(MyHealth.BeforeDinner))
            {
                AnalyseBD = "Your blood sugar is in acceptable range! (before dinner)";
            }
            else
            {
                AnalyseBDbad = "Your blood sugar level is poor/bad! (before dinner)";
            }

            var Alist = new string[] { "5", "5.0", "5.1", "5.2", "5.3", "5.4", "5.5", "5.6", "5.7", "5.8", "5.9", "6", "6.0", "6.1", "6.2", "6.3", "6.4", "6.5", "6.6", "6.7", "6.8", "6.9", "7", "7.0" };
            var Alist2 = new string[] {"7.1", "7.2", "7.3", "7.4", "7.5", "7.6", "7.7", "7.8", "7.9", "8", "8.0", "8.1", "8.2", "8.3", "8.4", "8.5", "8.6", "8.7", "8.8", "8.9", "9", "9.0", "9.1", "9.2", "9.3", "9.4", "9.5", "9.6", "9.7", "9.8", "9.9", "10", "10.0" };
            var Alist3 = new string[] { "10.1", "10.2", "10.3", "10.4", "10.5", "10.6", "10.7", "10.8", "10.9", "11", "11.0", "11.1", "11.2", "11.3", "11.4", "11.5", "11.6", "11.7", "11.8", "11.9", "12", "12.0", "12.1", "12.2", "12.3", "12.4", "12.5", "12.6", "12.7", "12.8", "12.9", "13", "13.0" };

            if (Alist.Contains(MyHealth.AfterBreakfast))
            {
                AnalyseAB = "Your blood sugar level is in optimal range! (after breakfast)";
            }
            else if (Alist2.Contains(MyHealth.AfterBreakfast))
            {
                AnalyseAB = "Your blood sugar is in a good range! (after breakfast)";
            }
            else if (Alist3.Contains(MyHealth.AfterBreakfast))
            {
                AnalyseAB = "Your blood sugar is in acceptable range! (after breakfast)";
            }
            else
            {
                AnalyseABbad = "Your blood sugar level is poor/bad! (after breakfast)";
            }

            if (Alist.Contains(MyHealth.AfterLunch))
            {
                AnalyseAL = "Your blood sugar level is in optimal range! (after lunch)";
            }
            else if (Alist2.Contains(MyHealth.AfterLunch))
            {
                AnalyseAL = "Your blood sugar is in a good range! (after lunch)";
            }
            else if (Alist3.Contains(MyHealth.AfterLunch))
            {
                AnalyseAL = "Your blood sugar is in acceptable range! (after lunch)";
            }
            else
            {
                AnalyseALbad = "Your blood sugar level is poor/bad! (after lunch)";
            }

            if (Alist.Contains(MyHealth.AfterDinner))
            {
                AnalyseAD = "Your blood sugar level is in optimal range! (after dinner)";
            }
            else if (Alist2.Contains(MyHealth.AfterDinner))
            {
                AnalyseAD = "Your blood sugar is in a good range! (after dinner)";
            }
            else if (Alist3.Contains(MyHealth.AfterDinner))
            {
                AnalyseAD = "Your blood sugar is in acceptable range! (after dinner)";
            }
            else
            {
                AnalyseADbad = "Your blood sugar level is poor/bad! (after dinner)";
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("VHealth");
        }
    }
}
