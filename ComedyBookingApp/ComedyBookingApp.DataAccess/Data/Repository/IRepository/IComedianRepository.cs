using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository.IRepository
{
    public interface IComedianRepository: IRepository<Comedian>
    {
        IEnumerable<SelectListItem> GetComedianListForDropDown();

        void Update(Comedian comedian);
    }
}
