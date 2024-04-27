﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentSchedule.ViewModels
{
    public class UserDetailsVM
    {
        public int ID { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }  // Password, decide what to do
        public bool IsActive { get; set; }
        public List<string> Roles { get; set; }
    }
}