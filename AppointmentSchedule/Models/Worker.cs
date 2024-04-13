using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedule.Models
{
    public class Worker : Person
    {
        public bool IsActive { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}