using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
    public class Services
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
        public string SellerComments { get; set; }
        public string Description { get; set; }

        public bool Status { get; set; }
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


       public List<ServicesAppointment> ServicesAppointments { get; set; }
    }
}
