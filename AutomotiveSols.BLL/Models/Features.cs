using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
    public class Features
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<CarFeature> GetCarFeatures { get; set; }

    }
}
