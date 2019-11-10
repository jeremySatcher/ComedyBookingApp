using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Uplift.Models
{
    public class LocationContact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Contact First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name="Contact Last Name")]
        public string LName { get; set; }

        [Required]
        [Display(Name="Contact Email")]
        public string Email { get; set; }

       
        [Display(Name="Contact Phone Number")]
        public string PhoneNumber { get; set; }


        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}