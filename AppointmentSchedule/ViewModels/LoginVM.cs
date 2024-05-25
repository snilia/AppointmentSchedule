﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AppointmentSchedule.ViewModels
{
    public class LoginVM
    {
        //public int ID { get; set; }  //pretty sure i dont need an ID here, gpt agrees it seems//
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}