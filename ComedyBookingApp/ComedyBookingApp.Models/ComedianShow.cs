﻿using System;
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
        [Required]
        [Display(Name = "Comedian on Show")]
        public int ComedianId { get; set; }
        [ForeignKey("ComedianId")]
        public Comedian Comedian { get; set; }
        [Required]
        [Display(Name = "Show Comedian is on")]
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}
