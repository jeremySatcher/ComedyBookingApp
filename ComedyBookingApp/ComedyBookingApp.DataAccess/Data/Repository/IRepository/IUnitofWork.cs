﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.DataAccess.Data.Repository.IRepository
{
    public interface IUnitofWork : IDisposable
    {
        IAgentRepository Agent { get; }
        IComedianRepository Comedian { get; }
        IEventRepository Event { get; }
        ILocationRepository Location { get; }
        IComedianShowRepository ComedianShow { get; }
        IUserRepository User { get; }
        void Save();
    }
}
