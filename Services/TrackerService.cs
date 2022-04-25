using Microsoft.EntityFrameworkCore;
using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Services
{
    public class TrackerService
    {

        //Add contructor for db
        private SeniorFolkDBContext _context;

        public TrackerService(SeniorFolkDBContext context)
        {
            _context = context;
        }

        public List<Tracker> GetAllTrackers()
        {
            List<Tracker> AllTrackers = new List<Tracker>();
            AllTrackers = _context.Trackers.ToList();
            return AllTrackers;
        }

        private bool TrackerExists(string id)
        {
            return _context.Trackers.Any(e => e.Idtracker == id);
        }

        public bool AddTracker(Tracker newtracker)
        {
            if (TrackerExists(newtracker.Idtracker))
            {
                return false;
            }
            _context.Add(newtracker);
            _context.SaveChanges();
            return true;
        }

        public Tracker GetTrackerById(string id)
        {
            Tracker theTracker = _context.Trackers.Where(e => e.Idtracker == id).FirstOrDefault();
            return theTracker;
        }

        public bool UpdateTracker(Tracker thetracker)
        {
            bool updated = true;
            _context.Attach(thetracker).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackerExists(thetracker.Idtracker))
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

        public bool DeleteTracker(Tracker thetracker)
        {
            bool deleted = true;

            try
            {
                _context.Remove(thetracker);
                _context.SaveChanges();
                deleted = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackerExists(thetracker.Idtracker))
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

        // previous

        //List<Tracker> AllTrackers = new List<Tracker>
        //{
        //    new Tracker {Idtracker = "A01", WorkoutTitle = "Light Exercises", ActivityDate = DateTime.Parse("20/01/2022"), StartTime = DateTime.Parse("7:30 AM"), EndTime = DateTime.Parse("8:30 AM"), Activities = "Walks, Stretches", Remarks = "Ankle pain"}
        //};

        //public List<Tracker> GetAllTrackers()
        //{
        //    return AllTrackers;
        //}

        //public Tracker GetTrackerById(String id)
        //{
        //    Tracker tracker = null;
        //    foreach (Tracker item in AllTrackers)
        //    {
        //        if (item.Idtracker == id)
        //        {
        //            tracker = item;
        //        }
        //    }
        //    return tracker;
        //}
    }
}
