using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyBookingApp.Models.ViewModels
{
    public class ComedianVM
    {
        public Comedian Comedian { get; set; }

        public IEnumerable<SelectListItem> AgentList { get; set; }

    }
}
