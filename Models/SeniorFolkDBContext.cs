using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Models
{
    public class SeniorFolkDBContext: DbContext
    {
        private readonly IConfiguration _config;
        public SeniorFolkDBContext(IConfiguration configuration)
        {
            _config = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _config.GetConnectionString("MyConn");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Tracker> Trackers { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<CreateGroup> Groups { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Preference> Preference { get; set; }
        public DbSet<ReportGroup> GroupAdmin{ get; set; }
        public DbSet<ReportUser> FriendsAdmin { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Health> Healths { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Help> Helps { get; set; }
    }
    

    
}
