using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppointmentSchedule.Models
{
    public class UserRoleMap
    {
        public int ID { get; set; }
        [ForeignKey("User")]
        public int? UserID { get; set; } //question mark means it's nullable check if i can delete the question mark, cuz i need them both to always be //////////////
        [ForeignKey("Role")]
        public int? RoleID { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}

