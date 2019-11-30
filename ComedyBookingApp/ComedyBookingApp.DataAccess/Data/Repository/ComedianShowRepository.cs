using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository
{
    public class ComedianShowRepository : Repository<ComedianShow>, IComedianShowRepository
    {
        private readonly ApplicationDbContext _db;

        public ComedianShowRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetComedianShowListForDropDown()
        {
            return _db.ComedianShow.Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.Id.ToString()
            });
        }

        public void Update(ComedianShow comedianshow)
        {
            var objFromDb = _db.ComedianShow.FirstOrDefault(s => s.Id == comedianshow.Id);

            objFromDb.Comedian = comedianshow.Comedian;
            objFromDb.Event = comedianshow.Event;

        }
    }
}
