using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
    public class Mileage
    {
        public int Id { get; set; }
        public string NumberKm { get; set; }
        public List<Car> Cars { get; set; }

    }
}
