using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Seniorfolk.Services
{
    public class VolunteerService
    {
        //public iformfile photos { get; set; }

        private SeniorFolkDBContext _context;
        public VolunteerService(SeniorFolkDBContext context)
        {
            _context = context;
        }

        public List<Volunteer> GetAllVolunteers()
        {
            List<Volunteer> Allvolunteers = new List<Volunteer>();
            Allvolunteers = _context.Volunteers.ToList();
            return Allvolunteers;
        }


        private bool VolunteerExist(string id)
        {
            return _context.Volunteers.Any(v => v.Id == id);
        }
        public bool AddVolunteer(Volunteer newvolunteer, IFormFile image)
        {
            if (VolunteerExist(newvolunteer.Id))
            {
                return false;
            }

            if (image != null)
            {
                var imageName = Path.GetFileName(image.FileName);
                var extension = Path.GetExtension(imageName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\voluntaryimg", imageName);

                newvolunteer.ImageName = imageName;
                newvolunteer.ImageType = extension;

                using (FileStream fs = new FileStream(imagePath, FileMode.Create))
                {
                    image.CopyTo(fs);
                }

                using MemoryStream ms = new MemoryStream();
                image.CopyTo(ms);
                newvolunteer.Image = ms.ToArray();
            }

            _context.Add(newvolunteer);
            _context.SaveChanges();
            return true;

        }
        //public iactionresult onpost(iformfile photos)
        //{
        //    if (photos != null)
        //    {
        //        if (photos.length > 0)
        //        {
        //            var photoname = path.getfilename(photos.filename);
        //            var photoextension = path.getextension(photoname);
        //            var newphotoname = string.concat(convert.tostring(guid.newguid()), photoextension);
        //            var objphotos = new volunteer()
        //            {
        //                id = myvolunteer.id,
        //                organisationname = newphotoname,
        //                filetype = photoextension,
        //                createoon = datetime.now
        //            };
        //            using (var target = new memorystream())
        //            {
        //                photos.copyto(target);
        //                objphotos.datafiles = target.toarray();
        //            }
        //            _context.volunteers.add(objphotos);
        //            _context.savechanges();

        //        }
        //    }


        //    return page();
        //}





        public Volunteer GetVolunteerById(string id)
        {
            Volunteer theVolunteer = _context.Volunteers.Where(v => v.Id == id).FirstOrDefault();
            return theVolunteer;
        }


        public bool UpdateVolunteer(Volunteer updatethevolunteer, IFormFile image)
        {
            bool updated = true;

            if (image != null)
            {
                var imageName = Path.GetFileName(image.FileName);
                var extension = Path.GetExtension(imageName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\voluntary", imageName);

                updatethevolunteer.ImageName = imageName;
                updatethevolunteer.ImageType = extension;

                using (FileStream fs = new FileStream(imagePath, FileMode.Create))
                {
                    image.CopyTo(fs);
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    image.CopyTo(ms);
                    updatethevolunteer.Image = ms.ToArray();
                }
                
            }


            _context.Attach(updatethevolunteer).State = EntityState.Modified;

            try
            {
                //_context.update(updatethevolunteer);
                _context.SaveChanges();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!VolunteerExist(updatethevolunteer.Id))
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


        public bool DeleteVolunteer(Volunteer delthevolunteer)
        {
            bool deleted = true;

            try
            {
                _context.Remove(delthevolunteer);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolunteerExist(delthevolunteer.Id))
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


