using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppointmentSchedule.Models
{
    public class Role
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        public virtual ICollection<UserRoleMap> UserRoleMaps { get; set; }

    }
}