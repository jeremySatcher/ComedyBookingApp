using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.Models.ViewModels
{
    public class LocationContactVM
    {
        public LocationContact LocationContact { get; set; }
        public IEnumerable<SelectListItem> LocationList { get; set; }
    }
}
