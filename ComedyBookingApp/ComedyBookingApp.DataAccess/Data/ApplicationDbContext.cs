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
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
