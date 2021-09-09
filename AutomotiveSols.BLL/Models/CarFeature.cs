using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
    public class CarFeature
    {
        public int Id { get; set; }
        public Car Car { get; set; }

        public int FeatureId { get; set; }
        public Features Features { get; set; }
    }
}
