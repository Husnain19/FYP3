using AutomotiveSols.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.ViewModels
{
    public class ServiceCartVM
    {
        public List<Services> Services { get; set; }

        public Appointments Appointments { get; set; }
    }
}
