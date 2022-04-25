using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Seniorfolk.Services
{
    public class PreferenceService
    {
        private SeniorFolkDBContext _context;
        public PreferenceService(SeniorFolkDBContext context)
        {
            _context = context;
        }


        public List<Preference> GetAllPreferences()
        {
            List<Preference> Allpreference = new List<Preference>();
            Allpreference = _context.Preference.ToList();
            return Allpreference;
        }


        private bool PreferenceExist(string id)
        {
            return _context.Preference.Any(g => g.PreferenceId == id);
        }


        public bool AddPreference(Preference newpreference)
        {
            if (PreferenceExist(newpreference.PreferenceId))
            {
                return false;
            }
            _context.Add(newpreference);
            _context.SaveChanges();
            return true;
        }


        public Preference GetUserById(String id)
        {
            Preference thePreference  = _context.Preference.Where(g => g.PreferenceId == id).FirstOrDefault();
            return thePreference;
        }


        public bool UpdatedPreference(Preference updatepreference)
        {
            bool updated = true;
            _context.Attach(updatepreference).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!PreferenceExist(updatepreference.PreferenceId))
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


        public bool DeletePreference(Preference delpreference)
        {
            bool deleted = true;

            try
            {
                _context.Remove(delpreference);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreferenceExist(delpreference.PreferenceId))
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
    }
}
