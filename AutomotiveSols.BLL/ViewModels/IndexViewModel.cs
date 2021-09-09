using AutomotiveSols.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<AutoPart> AutoPartList { get; set; }

        public IEnumerable<ServiceType> ServiceTypes { get; set; }
        public IEnumerable<Services> Services { get; set; }
        public IEnumerable<Car> Cars { get; set; }


    }
}
