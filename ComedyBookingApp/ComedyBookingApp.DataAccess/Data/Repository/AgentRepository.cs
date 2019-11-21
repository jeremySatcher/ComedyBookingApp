using ComedyBookingApp.DataAccess.Data.Repository.IRepository;
using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository
{
    public class AgentRepository : Repository<Agent> , IAgentRepository
    {
        private readonly ApplicationDbContext _db;

        public AgentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetAgentListForDropDown()
        {
            return _db.Agent.Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.FirstName + " " + i.LastName 
            });
        }

        public void Update(Agent agent)
        {
            var objFromDb = _db.Agent.FirstOrDefault(s => s.Id == agent.Id);

            objFromDb.FirstName = agent.FirstName;
            objFromDb.LastName = agent.LastName; 
            objFromDb.PhoneNumber = agent.PhoneNumber;
            objFromDb.Email = agent.Email;
            objFromDb.Comedian = agent.Comedian;

            _db.SaveChanges();
        }
    }
}
