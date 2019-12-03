﻿using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository
{
    class LocationRepository : Repository<Location>, ILocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LocationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetLocationListForDropDown()
        {
            return _db.Location.Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.Name
            });
        }

        public void Update(Location location)
        {
            var objFromDb = _db.Location.FirstOrDefault(s => s.Id == location.Id);

            objFromDb.Name = location.Name;
            objFromDb.Street = location.Street;
            objFromDb.City = location.City;
            objFromDb.Zip = location.Zip;
            objFromDb.PhoneNumber = location.PhoneNumber;
            objFromDb.Email = location.Email;
            objFromDb.ImageUrl = location.ImageUrl;
            objFromDb.Capacity = location.Capacity;
            objFromDb.EventId = location.EventId;


            _db.SaveChanges();
        }
    }
}
