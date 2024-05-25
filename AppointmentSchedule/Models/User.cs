using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedule.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<UserRoleMap> UserRoleMaps{ get; set; }

    }
}