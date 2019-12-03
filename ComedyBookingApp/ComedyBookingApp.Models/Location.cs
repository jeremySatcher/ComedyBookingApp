using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComedyBookingApp.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Location Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Location Street")]
        public string Street { get; set; }

        [Required]
        [Display(Name="Location City")]
        public string City { get; set; }

        [Required]
        [Display(Name="Location Zip")]
        public string Zip { get; set; }

        [Required]
        [Display(Name="Location Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name="Location Email")]
        public string Email { get; set; }


        [Display(Name="Capacity")]
        public int Capacity { get; set; } 
    }
}
