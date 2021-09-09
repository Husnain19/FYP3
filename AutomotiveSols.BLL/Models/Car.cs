using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
    public class Car
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string MainImage { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser  ApplicationUser { get; set; }

        public int TransmissionId { get; set; }

        //[ForeignKey("CategoryId")]
        public Transmission Transmission { get; set; }

        public int BranId { get; set; }
        public Brand Brand { get; set; }
        public int MileageId { get; set; }
        public Mileage Mileage { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int RegistrationCityId { get; set; }
        public RegistrationCity RegistrationCity { get; set; }
        public bool Status { get; set; }
        public int TrimId { get; set; }
        public Trim Trim { get; set; }

        public int YearId { get; set; }
        public Year Year { get; set; }

        public IList<CarFeature> GetCarFeatures { get; set; }

        public List<CarGallery> CarGalleries { get; set; }
        public List<CarAppointment> CarAppointments { get; set; }


    }
}
