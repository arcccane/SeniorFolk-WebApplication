using Microsoft.EntityFrameworkCore;
using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Services
{
    public class HealthService
    {

        private SeniorFolkDBContext _context;

        public HealthService(SeniorFolkDBContext context)
        {
            _context = context;
        }

        public List<Health> GetAllHealths()
        {
            List<Health> AllHealths = new List<Health>();
            AllHealths = _context.Healths.ToList();
            return AllHealths;
        }

        private bool HealthExists(string id)
        {
            return _context.Healths.Any(e => e.Idhealth == id);
        }

        public bool AddHealth(Health newhealth)
        {
            if (HealthExists(newhealth.Idhealth))
            {
                return false;
            }
            _context.Add(newhealth);
            _context.SaveChanges();
            return true;
        }

        public Health GetHealthById(string id)
        {
            Health theHealth = _context.Healths.Where(e => e.Idhealth == id).FirstOrDefault();
            return theHealth;
        }

        public bool UpdateHealth(Health thehealth)
        {
            bool updated = true;
            _context.Attach(thehealth).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthExists(thehealth.Idhealth))
                {
                    updated = false;
                }
                else
                {
                    throw;
                }
            }
            return updated;
        }

        public bool DeleteHealth(Health thehealth)
        {
            bool deleted = true;

            try
            {
                _context.Remove(thehealth);
                _context.SaveChanges();
                deleted = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthExists(thehealth.Idhealth))
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

        //List<Health> AllHealths = new List<Health>
        //{
        //    new Health {Idhealth = "H01", DateHealthLog = DateTime.Parse("11/11/2021"), Bmi = "20", SystolicBp = "120", DiastolicBp = "70", BeatsPm = "80",
        //        BeforeBreakfast = "2.2", AfterBreakfast = "3.2", BeforeLunch = "3.2", AfterLunch = "4.2", BeforeDinner = "4.2", AfterDinner = "5.2"},
        //    new Health {Idhealth = "H02", DateHealthLog = DateTime.Parse("12/11/2021"), Bmi = "21", SystolicBp = "121", DiastolicBp = "71", BeatsPm = "81",
        //        BeforeBreakfast = "2.4", AfterBreakfast = "3.4", BeforeLunch = "3.4", AfterLunch = "4.4", BeforeDinner = "4.4", AfterDinner = "5.4"},
        //};

        //public List<Health> GetAllHealths()
        //{
        //    return AllHealths;
        //}

        //public Health GetHealthById(String id)
        //{
        //    Health health = null;
        //    foreach (Health item in AllHealths)
        //    {
        //        if (item.Idhealth == id)
        //        {
        //            health = item;
        //        }
        //    }
        //    return health;
        //}
    }
}
