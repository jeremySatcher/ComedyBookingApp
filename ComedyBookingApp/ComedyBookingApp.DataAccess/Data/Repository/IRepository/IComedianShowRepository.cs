using ComedyBookingApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository.IRepository
{
    public interface IComedianShowRepository: IRepository<ComedianShow>
    {

        void Update(ComedianShow comedianshow);
    }
}
