﻿using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository.IRepository
{
    public interface IAgentRepository : IRepository<Agent>
    {
        IEnumerable<SelectListItem> GetAgentListForDropDown();

        void Update(Agent agent);
    }
}
