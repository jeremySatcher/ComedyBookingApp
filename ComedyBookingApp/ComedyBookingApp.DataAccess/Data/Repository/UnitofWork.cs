using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _db;

        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
            Agent = new AgentRepository(_db);
            Comedian = new ComedianRepository(_db);
            Event = new EventRepository(_db);
            Location = new LocationRepository(_db);
            ComedianShow = new ComedianShowRepository(_db);
            User = new UserRepository(_db);
        }

        public IAgentRepository Agent { get; private set; }
        public IComedianRepository Comedian { get; private set; }
        public IEventRepository Event { get; private set; }
        public ILocationRepository Location { get; private set; }

        public IComedianShowRepository ComedianShow { get; private set; }

        public IUserRepository User { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
