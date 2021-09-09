using AutomotiveSols.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.ViewModels
{
   public class CarAppointmentVM
    {
        public List<Car> Cars { get; set; }

        public Appointments Appointments { get; set; }

    }
}
