using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository.IRepository
{
    public interface ILocationContactRepository : IRepository<LocationContact>
    {
        IEnumerable<SelectListItem> GetLocationContactListForDropDown();

        void Update(LocationContact locationContact);
    }
}
