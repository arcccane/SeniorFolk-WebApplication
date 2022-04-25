using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Seniorfolk.Services
{
    public class ReportUserService
    {
        private SeniorFolkDBContext _context;

        public ReportUserService(SeniorFolkDBContext context)
        {
            _context = context;
        }


        public List<ReportUser> GetAllReports()
        {
            List<ReportUser> Allreports = new List<ReportUser>();
            Allreports = _context.FriendsAdmin.ToList();
            return Allreports;
        }


        private bool ReportExist(string id)
        {
            return _context.GroupAdmin.Any(g => g.ReportedNo == id);
        }


        public bool AddUserReport(ReportUser newgroupreport)
        {
            if (ReportExist(newgroupreport.ReportedNo))
            {
                return false;
            }
            _context.Add(newgroupreport);
            _context.SaveChanges();
            return true;
        }


        public ReportUser GetUserById(String id)
        {
            ReportUser theReport = _context.FriendsAdmin.Where(g => g.ReportedNo == id).FirstOrDefault();
            return theReport;
        }


        public bool DeleteGroup(ReportUser delgroup)
        {
            bool deleted = true;

            try
            {
                _context.Remove(delgroup);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExist(delgroup.ReportedNo))
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
