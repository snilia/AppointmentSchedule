using System.Collections.Generic;

namespace AppointmentSchedule.Models
{
    public class Client : Person
    {

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}