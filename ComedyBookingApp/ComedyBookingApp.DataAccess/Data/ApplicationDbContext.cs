using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ComedyBookingApp.Models;

namespace ComedyBookingApp.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<Comedian> Comedian {get; set;}
        public DbSet <Agent> Agent {get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<LocationContact> LocationContact {get; set;}

        public DbSet<ComedianShow> ComedianShow { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Comedian>().HasOne(t => t.Agent).WithMany(c => c.Comedian);
            builder.Entity<LocationContact>().HasOne(t => t.Location).WithOne(l => l.LocationContact);
            builder.Entity<Event>().HasOne(t => t.Location).WithMany(e => e.Event);
            builder.Entity<Event>().HasMany(t => t.ComedianShows).WithOne(e => e.Event);
            builder.Entity<Comedian>().HasMany(t => t.ComedianShow).WithOne(c => c.Comedian);
        }

    }
}
