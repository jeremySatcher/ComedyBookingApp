using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository
{
    class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly ApplicationDbContext _db;

        public EventRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetEventListForDropDown()
        {
            return _db.Event.Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.Name
            });
        }

        public IEnumerable<SelectListItem> GetOneEventForDropDown(int id)
        {
            var idString = id.ToString();
            return new List<SelectListItem>()
            {
                new SelectListItem(){ Value = idString, Text = "Event Selected"}
            };
        }

        public void Update(Event showevent)
        {
            var objFromDb = _db.Event.FirstOrDefault(s => s.Id == showevent.Id);

            objFromDb.Name = showevent.Name;
            objFromDb.Price = showevent.Price;
            objFromDb.LongDesc = showevent.LongDesc;
            objFromDb.Date = showevent.Date;
            objFromDb.Time = showevent.Time;
            objFromDb.LocationId = showevent.LocationId;
            objFromDb.ImageUrl = showevent.ImageUrl;

            _db.SaveChanges();
        }
    }
}
