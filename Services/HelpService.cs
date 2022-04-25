using Microsoft.EntityFrameworkCore;
using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Services
{
    public class HelpService
    {
        private readonly SeniorFolkDBContext _context;

        public HelpService(SeniorFolkDBContext context)
        {
            _context = context;
        }

        private bool HelpExists(int id)
        {
            return _context.Helps.Any(e => e.HelpId == id);
        }

        public bool AddHelp(Help newHelp, string userId, string email, string mobile)
        {
            if (HelpExists(newHelp.HelpId))
            {
                return false;
            }
            else
            {
                newHelp.UserId = userId;
                newHelp.Email = email;
                newHelp.Mobile = mobile;
                newHelp.CreatedOn = DateTime.Now;

                _context.Add(newHelp);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Help> GetAllHelp()
        {
            List<Help> AllHelp = _context.Helps.ToList();
            return AllHelp;
        }
        public Help GetRequestById(int id)
        {
            Help theRequest = _context.Helps.Where(e => e.HelpId == id).FirstOrDefault();
            return theRequest;
        }

        public bool DeleteRequest(Help theRequest)
        {
            bool deleted;
            try
            {
                _context.Remove(theRequest);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelpExists(theRequest.HelpId))
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
