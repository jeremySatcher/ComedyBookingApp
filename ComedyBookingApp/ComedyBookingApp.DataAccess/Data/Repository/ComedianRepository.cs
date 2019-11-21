using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository
{
    class ComedianRepository : Repository<Comedian>, IComedianRepository
    {
        private readonly ApplicationDbContext _db;

        public ComedianRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetComedianListForDropDown()
        {
            return _db.Comedian.Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.FirstName + " " + i.LastName
            });
        }

        public void Update(Comedian agent)
        {
            var objFromDb = _db.Comedian.FirstOrDefault(s => s.Id == agent.Id);

            objFromDb.FirstName = agent.FirstName;
            objFromDb.LastName = agent.LastName;
            objFromDb.PhoneNumber = agent.PhoneNumber;
            objFromDb.Email = agent.Email;
            objFromDb.ExperienceYears = agent.ExperienceYears;
            objFromDb.ImageUrl = agent.ImageUrl;
            objFromDb.State = agent.State;
            objFromDb.City = agent.City;

            _db.SaveChanges();
        }
    }
}
