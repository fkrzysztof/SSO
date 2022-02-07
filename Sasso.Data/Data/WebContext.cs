﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sasso.Data.Data.Data;

namespace Sasso.Data.Data
{
    public class WebContext : IdentityDbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {
        }
    
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<ProjectsPage> ProjectsPages { get; set; }
        public DbSet<Partners> Partners { get; set; }
        public DbSet<File> Files { get; set; }
    }
}
