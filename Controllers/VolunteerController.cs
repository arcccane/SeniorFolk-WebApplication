//using System;
////using System.Collections.Generic;
////using System.Linq;
//using System.Threading.Tasks;
//using Seniorfolk.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
////using Microsoft.AspNetCore.Http;
//using System.IO;

//namespace Seniorfolk.Controllers
//{
//    public class VolunteerController : Controller
//    {
//        private readonly VolunteerDBContext _context;
//        private readonly IWebHostEnvironment webHostEnvironment;
//        public VolunteerController(VolunteerDBContext context,IWebHostEnvironment hostEnvironment)
//        {
//            _context = context;
//            webHostEnvironment = hostEnvironment;
//        }

//        public async Task<IActionResult> CreateVolunteers()
//        {
//            var volunteers = await _context.Volunteers.ToListAsync();
//            return View(volunteers);
//        }

//        public IActionResult New()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> New(Volunteer model)
//        {
//            if (ModelState.IsValid)
//            {
//                string uniqueFileName = UploadedFile(model);

//                Volunteer volunteer = new Volunteer
//                {
//                    Id = model.Id,
//                    OrganisationName = model.OrganisationName,

//                    ProfilePicture = uniqueFileName,
//                };
//                _context.Add(volunteer);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(CreateVolunteers));
//            }
//            return View();
//        }

//        private string UploadedFile(Volunteer model)
//        {
//            string uniqueFileName = null;

//            if (model.ProfilePicture != null)
//            {
//                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
//                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
//                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
//                using (var fileStream = new FileStream(filePath, FileMode.Create))
//                {
//                    model.ProfilePicture.CopyTo(fileStream);
//                }
//            }
//            return uniqueFileName;
//        }

//    }

//}
////    public class VolunteerController : Controller
////    {
////        private readonly VolunteerDBContext _context;

////        public VolunteerController(VolunteerDBContext context)
////        {
////            _context = context;
////        }

////        public IActionResult CreateVolunteers()
////        {
////            return View();
////        }

////        public IActionResult OnPost(IFormFile photos)
////        {
////            if (photos != null)
////            {
////                if (photos.Length > 0)
////                {
////                    var photoName = Path.GetFileName(photos.FileName);
////                    var photoExtension = Path.GetExtension(photoName);
////                    var newPhotoName = String.Concat(Convert.ToString(Guid.NewGuid()), photoExtension);
////                    var objPhotos = new Volunteer()
////                    {
////                        Id = "0",
////                        OrganisationName = newPhotoName,
////                        FileType = photoExtension,
////                        CreateoOn = DateTime.Now
////                    };
////                    using (var target = new MemoryStream())
////                    {
////                        photos.CopyTo(target);
////                        objPhotos.DataFiles = target.ToArray();
////                    }
////                    _context.Volunteers.Add(objPhotos);
////                    _context.SaveChanges();

////                }
////            }


////            return View();
////        }



////    }
////}
