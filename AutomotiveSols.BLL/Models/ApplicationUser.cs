using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
   public class ApplicationUser :IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }


        // public int? OrganizationId { get; set; }

        // [ForeignKey("ShowroomId")]
        //        public Organization Organization { get; set; }

        [NotMapped]
        public string Role { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public List<OrderHeader> OrderHeaders { get; set; }
        public List<AutoPart> AutoParts { get; set; }

        public List<Car> Cars { get; set; }

        public List<Services> Services { get; set; }
        public List<Appointments> Appointments { get; set; }
    }
}
