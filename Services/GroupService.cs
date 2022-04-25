using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Seniorfolk.Services
{
    public class GroupService
    {
        private SeniorFolkDBContext _context;
        public GroupService(SeniorFolkDBContext context)
        {
            _context = context;
        }


        public List<CreateGroup> GetAllGroups()
        {
            List<CreateGroup> Allgroups = new List<CreateGroup>();
            Allgroups = _context.Groups.ToList();
            return Allgroups;
        }


        private bool GroupExist(string id)
        {
            return _context.Groups.Any(g => g.GroupId == id);
        }


        public bool AddGroup(CreateGroup newgroup)
        {
            if (GroupExist(newgroup.GroupId))
            {
                return false;
            }
            _context.Add(newgroup);
            _context.SaveChanges();
            return true;
        }


        public CreateGroup GetUserById(String id)
        {
            CreateGroup theGroup = _context.Groups.Where(g => g.GroupId == id).FirstOrDefault();
            return theGroup;
        }


        public bool UpdatedGroup(CreateGroup updategroup)
        {
            bool updated = true;
            _context.Attach(updategroup).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!GroupExist(updategroup.GroupId))
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


        public bool DeleteGroup(CreateGroup delgroup)
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
                if (!GroupExist(delgroup.GroupId))
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
