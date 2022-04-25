using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Seniorfolk.Services
{
    public class UserService
    {
        private SeniorFolkDBContext _context;
        public UserService(SeniorFolkDBContext context)
        {
            _context = context;
        }
        

        public List<User> GetAllUsers()
        {
            List<User> Allusers = new List<User>();
            Allusers = _context.Users.ToList();
            return Allusers;
        }


        private bool UserExist(string id)
        {
            return _context.Users.Any(u => u.Id == id); 
        }


        public bool AddUser (User newuser)
        {
            if (UserExist(newuser.Id))
            {
                return false;
            }
            _context.Add(newuser);
            _context.SaveChanges();
            return true;
        }


        public User GetUserById(String id)
        {
            User theUser = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            
            return theUser;
        }

        public User GetUserByPassword(String password)
        {
            User userpassword = _context.Users.Where(u => u.Password == password).FirstOrDefault();
            return userpassword;
        }

        internal object GetAllFriends()
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User updatetheuser)
        {
            bool updated = true;
            _context.Attach(updatetheuser).State = EntityState.Modified;

            try
            {
                //_context.Update(updatetheuser);
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!UserExist(updatetheuser.Id))
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


        public bool DeleteUser(User deltheuser)
        {
            bool deleted = true;

            try
            {
                _context.Remove(deltheuser);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExist(deltheuser.Id))
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

        ////public User LoginAcc(String id, String password)
        ////{
        ////    User UserId = _context.Users.Where(u => u.Id == id).FirstOrDefault();
        ////    User UserPassword = _context.Users.Where(u => u.Password == password).FirstOrDefault();
            

        ////    return UserId;
            
        ////}

        //public User Authenticate( string loguser)
        //{
        //    var acc = _context.Users.Where(u => u.Id == id).FirstOrDefault();
        //    return theUser;
        //}


    }
}
