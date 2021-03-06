using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
  public  class Appointments
    {
        public int Id { get; set; }

        public string SalesPersonId { get; set; }
        public  ApplicationUser SalesPerson { get; set; }

        public DateTime AppointmentDate { get; set; }

        [NotMapped]
        public DateTime AppointmentTime { get; set; }

        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public bool isConfirmed { get; set; }

        public bool? isCar { get; set; }
        public bool? isService { get; set; }
        public List<ServicesAppointment> ServicesAppointments { get; set; }
        public List<CarAppointment> CarAppointments { get; set; }


    }
}
