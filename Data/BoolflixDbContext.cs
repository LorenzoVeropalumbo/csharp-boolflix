﻿using Boolflix.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Boolflix.Data
{
    public class BoolflixDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<SerieTV> SerieTVs { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Content> Contents { get; set; }

        public BoolflixDbContext(DbContextOptions<BoolflixDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
