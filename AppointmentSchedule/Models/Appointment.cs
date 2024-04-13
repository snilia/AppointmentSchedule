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
        [ForeignKey("Worker")] //AIdded   //DELETE
        public int? WorkerID { get; set; }
        [ForeignKey("Client")] //AIdded   //DELETE
        public int? ClientID { get; set; }
        public Status? Status { get; set; }  //question mark means it's nullable //////////////
        [DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]  //////changed from this and fixed. //////DELETE
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentDateTime { get; set; }  //info in creating a more complex data model /////////////DELETE
        public string TextBox { get; set; } //for text comments 
        public virtual Worker Worker { get; set; }
        public virtual Client Client { get; set; }
    }
}