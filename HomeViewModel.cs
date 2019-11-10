using System;
using System.Collections.Generic;
using System.Text;

namespace Uplift.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Comedian> ComedianList { get; set; }
        public IEnumerable<Event> EventList { get; set; }
    }
}
