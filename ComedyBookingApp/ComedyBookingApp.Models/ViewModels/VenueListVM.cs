using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.Models.ViewModels
{
    public class VenueListVM
    {
        public IEnumerable<Location> LocationList { get; set; }

        public Location Location { get; set; }
        public Event Event { get; set; }
    }
}
