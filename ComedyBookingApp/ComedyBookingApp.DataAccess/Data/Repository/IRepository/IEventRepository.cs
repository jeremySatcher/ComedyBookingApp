using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository.IRepository
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<SelectListItem> GetEventListForDropDown();

        IEnumerable<SelectListItem> GetOneEventForDropDown(int id);

        void Update(Event showevent);
    }
}
