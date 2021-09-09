using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
    public class Year
    {
        public int Id { get; set; }
        public string SolarYear { get; set; }

        public List<Car> Cars { get; set; }

    }
}
