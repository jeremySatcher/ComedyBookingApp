using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.Models.ViewModels
{
    public class ComedianShowVM
    {
        public ComedianShow ComedianShow { get; set; }
        public IEnumerable<SelectListItem> ComedianList { get; set; }
        public IEnumerable<SelectListItem> EventList { get; set; }
        public Comedian Comedian { get; set; }


    }
}
