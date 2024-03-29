﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComedyBookingApp.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Event Name")]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Display(Name ="Description")]
        public string LongDesc { get; set; }
        
        [Required]
        [Display(Name = "Event Date")]
        public string Date { get; set; }

        [Required]
        [Display(Name = "Event Time")]
        public string Time { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Promotional Image")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Venue")]
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
