using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppointmentSchedule.ViewModels
{
    public class UserDetailsVM
    {
        public int ID { get; set; } 
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public List<string> Roles { get; set; }
    }
}