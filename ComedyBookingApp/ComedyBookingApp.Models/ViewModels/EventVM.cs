using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.Models.ViewModels
{
    public class EventVM
    {
        public Event Event { get; set; }
        public IEnumerable<SelectListItem> LocationList { get; set; }

        public Location Location { get; set; }

    }
}
