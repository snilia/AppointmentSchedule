using AppointmentSchedule.Models;


namespace AppointmentSchedule.ViewModels
{
    public class LimitedEditVM
    {
        public int ID { get; set; }
        public Status? Status { get; set; }
        public string TextBox { get; set; }
        public string WorkerFullName { get; set; }  
        public string ClientFullName { get; set; }  
    }
}