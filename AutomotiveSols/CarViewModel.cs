using AutomotiveSols.BLL.Models;
using AutomotiveSols.BLL.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutomotiveSols
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public List<FeatureAssignedToCar> FeatureAssignedToCar { get; set; }
        public IEnumerable<SelectListItem> BrandList { get; set; }
        public IEnumerable<SelectListItem> ModelList { get; set; }
        public IEnumerable<SelectListItem> MileageList { get; set; }
        public IEnumerable<SelectListItem> RegistrationCityList { get; set; }
        public IEnumerable<SelectListItem> TransmissionList { get; set; }
        public IEnumerable<SelectListItem> TrimList { get; set; }
        public IEnumerable<SelectListItem> YearList { get; set; }

        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }

        [Display(Name = "Choose the gallery images of your Spare-part")]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

    }
}
