using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
    public class Trim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }

        //public List<Year> Years { get; set; }
        //public List<Transmission> Transmissions { get; set; }
        public List<Car> Cars { get; set; }

    }
}
