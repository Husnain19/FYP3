using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
   public class ServicesAppointment
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public  Appointments Appointments { get; set; }

        public int ServiceId { get; set; }

        public  Services Service { get; set; }
    }
}
