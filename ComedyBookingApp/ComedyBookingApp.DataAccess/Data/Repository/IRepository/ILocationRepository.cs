﻿using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository.IRepository
{
    public interface ILocationRepository : IRepository<Location>
    {
        IEnumerable<SelectListItem> GetLocationListForDropDown();

        void Update(Location location);
    }
}
