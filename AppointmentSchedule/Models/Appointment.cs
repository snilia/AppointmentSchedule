using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentSchedule.Models
{
    public enum Status
    {
        Pending, Confirmed, Done, Canceled, NoShow
    }
    public class Appointment
    {
        public int ID { get; set; }
        [ForeignKey("Worker")] 
        public int? WorkerID { get; set; }
        [ForeignKey("Client")] 
        public int? ClientID { get; set; }
        public Status? Status { get; set; } 
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentDateTime { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Appointment length must be between 1 and 5 hours.")]
        public int LengthInHours { get; set; } //the length of the appointment in hours
        public string TextBox { get; set; } //for text comments 
        public virtual Worker Worker { get; set; }
        public virtual Client Client { get; set; }
    }
}