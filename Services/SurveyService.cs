using Microsoft.EntityFrameworkCore;
using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Services
{
    public class SurveyService
    {
        private SeniorFolkDBContext _context;

        public SurveyService(SeniorFolkDBContext context)
        {
            _context = context;
        }

        public List<Survey> GetAllSurveys()
        {
            List<Survey> AllSurveys = new List<Survey>();
            AllSurveys = _context.Surveys.ToList();
            return AllSurveys;
        }

        private bool SurveyExists(string id)
        {
            return _context.Surveys.Any(e => e.Surveyid == id);
        }

        public bool AddSurvey(Survey newsurvey)
        {
            if (SurveyExists(newsurvey.Surveyid))
            {
                return false;
            }
            _context.Add(newsurvey);
            _context.SaveChanges();
            return true;
        }

        public Survey GetSurveyById(string id)
        {
            Survey theSurvey = _context.Surveys.Where(e => e.Surveyid == id).FirstOrDefault();
            return theSurvey;
        }

        public bool DeleteSurvey(Survey thesurvey)
        {
            bool deleted = true;

            try
            {
                _context.Remove(thesurvey);
                _context.SaveChanges();
                deleted = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyExists(thesurvey.Surveyid))
                {
                    deleted = false;
                }
                else
                {
                    throw;
                }
            }
            return deleted;
        }

        //List<Survey> AllSurveys = new List<Survey>
        //{
        //    new Survey {Surveyid = "S01", Title = "Bored", Suggestions = "More exciting content"},
        //    new Survey {Surveyid = "S02", Title = "Insulted", Suggestions = "blah blah blah"},
        //    new Survey {Surveyid = "S03", Title = "Bug in website", Suggestions = "Blah blah blah blah"},
        //};

        //public List<Survey> GetAllSurveys()
        //{
        //    return AllSurveys;
        //}

        //public Survey GetSurveyById(string id)
        //{
        //    Survey survey = null;
        //    foreach (Survey item in AllSurveys)
        //    {
        //        if (item.Surveyid == id)
        //        {
        //            survey = item;
        //        }
        //    }
        //    return survey;
        //}

    }
}
