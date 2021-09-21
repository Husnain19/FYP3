using AutomotiveSols.BLL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace AutomotiveSols.BLL.ViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "Cars")]
        public int TotalCars { get; set; }
        [Display(Name = "Services")]
        public int TotalServices { get; set; }
        [Display(Name = "Spare Parts")]
        public int TotalSpareParts { get; set; }
        [Display(Name = "Application Users")]
        public int TotalUsers { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<AutoPart> AutoPartList { get; set; }

        public IEnumerable<ServiceType> ServiceTypes { get; set; }
        public IEnumerable<Services> Services { get; set; }
        public IEnumerable<Car> Cars { get; set; }

        /// <summary>
        /// 
        /// </summary>
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

        public DecisionVM DecisionVM { get; set; }


    }
}
