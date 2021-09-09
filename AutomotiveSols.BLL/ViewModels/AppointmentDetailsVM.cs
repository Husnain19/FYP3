using AutomotiveSols.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.ViewModels
{
   public class AppointmentDetailsVM
    {
        public Appointments Appointments { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Services> Services { get; set; }
    }
}
