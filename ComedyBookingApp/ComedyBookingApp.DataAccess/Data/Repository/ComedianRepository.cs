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

        public IEnumerable<SelectListItem> GetOneComedianForDropDown(int id)
        {
            var idString = id.ToString();
            return new List<SelectListItem>()
            {
                new SelectListItem(){ Value = idString, Text = "Comedian Selected"}
            };
        }


        public void Update(Comedian comedian)
        {
            var objFromDb = _db.Comedian.FirstOrDefault(s => s.Id == comedian.Id);

            objFromDb.FirstName = comedian.FirstName;
            objFromDb.LastName = comedian.LastName;
            objFromDb.PhoneNumber = comedian.PhoneNumber;
            objFromDb.Email = comedian.Email;
            objFromDb.ExperienceYears = comedian.ExperienceYears;
            objFromDb.ImageUrl = comedian.ImageUrl;
            objFromDb.State = comedian.State;
            objFromDb.City = comedian.City;
            objFromDb.AgentId = comedian.AgentId;

            _db.SaveChanges();
        }
    }
}
