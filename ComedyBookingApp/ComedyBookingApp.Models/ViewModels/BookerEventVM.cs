using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.Models.ViewModels
{
    public class BookerEventVM
    {
        public IEnumerable<Event> EventList { get; set; }

        public IEnumerable<ComedianShow> ComedianShowList { get; set; } 

        public ComedianShow ComedianShow { get; set; }

        public IEnumerable<Comedian> ComedianList { get; set; }

        public Comedian Comedian { get; set; }
    }
}
