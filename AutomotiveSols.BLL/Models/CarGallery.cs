using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
   public class CarGallery
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public Car Car { get; set; }

    }
}
