using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComedyBookingApp.Models
{
    public class ComedianShow
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ComedianId")]
        public Comedian Comedian { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}
