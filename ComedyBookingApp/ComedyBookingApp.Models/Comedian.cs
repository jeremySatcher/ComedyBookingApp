using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComedyBookingApp.Models
{
    public class Comedian

    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Comedian First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Comedian Last Name")]
        public string LastName { get; set; }

    
        [Display(Name="Comedian Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name="Comedian Email")]
        public string Email { get; set; }

    
        [Display(Name="Comedian Years of Experience")]
        public string ExpereinceYears { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name ="Comedian Headshot")]
        public string ImageUrl { get; set; }

        [Display(Name="Comedian Home State")]
        public string State { get; set; }

        [Display(Name="Comedian Home City")]
        public string City { get; set; }


    }
}