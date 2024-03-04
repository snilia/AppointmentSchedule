using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ClientScheduler.Models
{
    public class Worker : Person
    {

//        public bool IsAdmin { get; set; }
//        public bool IsManager { get; set; }
//        public bool PermissionReadOwn { get; set; }
//        public bool PermissionEditOwn { get; set; }
//        public bool PermissionReadAll { get; set; }
//        public bool PermissionEditAll { get; set; }
//        public bool PermissionAddClient { get; set; }
//        public bool PermissionEditClient { get; set; }
        public bool IsActive { get; set; }
//        public string Username { get; set; }
//        public string Password { get; set; }





        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}