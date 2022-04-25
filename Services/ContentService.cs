using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Seniorfolk.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Services
{
    public class ContentService
    {
        private readonly SeniorFolkDBContext _context;

        public ContentService(SeniorFolkDBContext context)
        {
            _context = context;
        }

        private bool ContentExists(int id)
        {
            return _context.Contents.Any(e => e.ContentId == id);
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }

        public bool AddContent(Content newContent, string userId, IFormFile file)
        {
            if (ContentExists(newContent.ContentId))
            {
                return false;
            }
            else
            {
                newContent.UserId = userId;

                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var extension = Path.GetExtension(fileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\contents", fileName);

                    newContent.FileName = fileName;
                    newContent.FileType = extension;

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                    }

                    using MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    newContent.File = ms.ToArray();
                }

                _context.Add(newContent);
                _context.SaveChanges();
                return true;
            }
        }

        public bool AddComment(Comments comment, string userId)
        {
            if (CommentExists(comment.CommentId))
            {
                return false;
            }

            comment.UserId = userId;
            comment.CreatedOn = DateTime.Now;

            _context.Add(comment);
            _context.SaveChanges();
            return true;
        }

        public List<Content> GetAllContent()
        {
            List<Content> AllContents = _context.Contents.ToList();
            return AllContents;
        }

        public List<Content> GetAllContentByUserId(string userId)
        {
            List<Content> AllContentsByUserId = _context.Contents.Where(e => e.UserId == userId).ToList();
            return AllContentsByUserId;
        }

        public Content GetContentById(int id)
        {
            Content theContent = _context.Contents.Where(e => e.ContentId == id).FirstOrDefault();
            return theContent;
        }

        public List<Comments> GetAllCommentsById(int id)
        {
            List<Comments> AllCommentsById = _context.Comments.Where(e => e.ContentId == id).ToList();
            return AllCommentsById;
        }

        public bool UpdateContent(Content theContent, IFormFile file)
        {

            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var extension = Path.GetExtension(fileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\contents", fileName);

                theContent.FileName = fileName;
                theContent.FileType = extension;

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fs);
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    theContent.File = ms.ToArray();
                }
            }
            _context.Attach(theContent).State = EntityState.Modified;

            bool updated;
            try
            {
                _context.SaveChanges();
                updated = true;
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!ContentExists(theContent.ContentId))
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

        public bool DeleteContent(Content theContent, List<Comments> comments)
        {
            bool deleted;
            try
            {
                _context.Remove(theContent);

                foreach (Comments comment in comments)
                {
                    _context.Remove(comment);
                }

                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentExists(theContent.ContentId))
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
