using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Seniorfolk.Services
{
    public class FriendService
    {
        private SeniorFolkDBContext _context;

        public FriendService(SeniorFolkDBContext context)
        {
            _context = context;
        }


        public List<Friend> GetAllFriends()
        {
            List<Friend> Allfriends = new List<Friend>();
            Allfriends = _context.Friends.ToList();
            return Allfriends;
        }


        private bool FriendExist(string id)
        {
            return _context.Groups.Any(g => g.GroupId == id);
        }


        public bool AddFriend(Friend newfriend)
        {
            if (FriendExist(newfriend.FriendId))
            {
                return false;
            }
            _context.Add(newfriend);
            _context.SaveChanges();
            return true;
        }


        public Friend GetUserById(String id)
        {
            Friend theFriend = _context.Friends.Where(g => g.FriendId == id).FirstOrDefault();
            return theFriend;
        }


        public bool UpdatedFriend(Friend updatefriend)
        {
            bool updated = true;
            _context.Attach(updatefriend).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!FriendExist(updatefriend.FriendId))
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


        public bool DeleteFriend(Friend delfriend)
        {
            bool deleted = true;

            try
            {
                _context.Remove(delfriend);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendExist(delfriend.FriendId))
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
