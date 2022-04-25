using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Seniorfolk.Services
{
    public class ApplicationService
    {
        private SeniorFolkDBContext _context;
        public ApplicationService(SeniorFolkDBContext context)
        {
            _context = context;
        }


        public List<Application> GetAllApplications()
        {
            List<Application> Allapplications = new List<Application>();
            Allapplications = _context.Application.ToList();
            return Allapplications;
        }


        private bool ApplicationExist(string id)
        {
            return _context.Application.Any(a => a.Id == id);
        }


        public bool AddApplication(Application newapplication)
        {
            if (ApplicationExist(newapplication.Id))
            {
                return false;
            }
            _context.Add(newapplication);
            _context.SaveChanges();
            return true;
        }


        public Application GetApplicationById(String id)
        {
            Application theApplication = _context.Application.Where(a => a.Id == id).FirstOrDefault();

            return theApplication;
        }





        public bool UpdateApplication(Application updatetheapplication)
        {
            bool updated = true;
            _context.Attach(updatetheapplication).State = EntityState.Modified;

            try
            {
                //_context.Update(updatetheuser);
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!ApplicationExist(updatetheapplication.Id))
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


        public bool DeleteApplication(Application deltheapplication)
        {
            bool deleted = true;

            try
            {
                _context.Remove(deltheapplication);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExist(deltheapplication.Id))
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
