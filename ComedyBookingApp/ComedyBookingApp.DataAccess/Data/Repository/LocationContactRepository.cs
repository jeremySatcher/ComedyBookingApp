using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository
{
    class LocationContactRepository : Repository<LocationContact>, ILocationContactRepository
    {
        private readonly ApplicationDbContext _db;
        public LocationContactRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetLocationContactListForDropDown()
        {
            return _db.LocationContact.Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.FName + " " + i.LName
            });
        }

        public void Update(LocationContact locationContact)
        {
            var objFromDb = _db.LocationContact.FirstOrDefault(s => s.Id == locationContact.Id);

            objFromDb.FName = locationContact.FName;
            objFromDb.LName = locationContact.LName;
            objFromDb.Email = locationContact.Email;
            objFromDb.PhoneNumber = locationContact.PhoneNumber;
            objFromDb.Location = locationContact.Location;


            _db.SaveChanges();
        }
    }
}
