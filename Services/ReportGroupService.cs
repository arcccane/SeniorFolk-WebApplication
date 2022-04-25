using Microsoft.EntityFrameworkCore;
using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Services
{
    public class ReportGroupService
    {
        private SeniorFolkDBContext _context;

        public ReportGroupService(SeniorFolkDBContext context)
        {
            _context = context;
        }


        public List<ReportGroup> GetAllReports()
        {
            List<ReportGroup> Allreports = new List<ReportGroup>();
            Allreports = _context.GroupAdmin.ToList();
            return Allreports;
        }


        private bool RGroupExist(string id)
        {
            return _context.GroupAdmin.Any(g => g.ReportedNo == id);
        }


        public bool AddGroupReport(ReportGroup newgroupreport)
        {
            if (RGroupExist(newgroupreport.ReportedNo))
            {
                return false;
            }
            _context.Add(newgroupreport);
            _context.SaveChanges();
            return true;
        }


        public ReportGroup GetUserById(String id)
        {
            ReportGroup theReport = _context.GroupAdmin.Where(g => g.ReportedNo == id).FirstOrDefault();
            return theReport;
        }


        public bool DeleteGroup(ReportGroup delgroup)
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
                if (!RGroupExist(delgroup.ReportedNo))
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
