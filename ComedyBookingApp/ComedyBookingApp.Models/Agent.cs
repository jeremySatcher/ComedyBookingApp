using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Uplift.Models
{
    public class Agent

    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Agent First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Agent Last Name")]
        public string LastName { get; set; }

    
        [Display(Name="Agent Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name="Agent Email")]
        public string Email { get; set; }

        [Required]
        public string Comedian { get; set; }

        [ForeignKey("ComedianId")]
        public Comedian Comedian { get; set; }


    }
}