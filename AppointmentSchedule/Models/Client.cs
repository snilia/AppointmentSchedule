using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedule.Models
{
    public class Client : Person
    {

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}