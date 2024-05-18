using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppointmentSchedule.Models
{
    public abstract class Person
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must contain 10 digits.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain 10 digits.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //makes a read only property
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

    }
}