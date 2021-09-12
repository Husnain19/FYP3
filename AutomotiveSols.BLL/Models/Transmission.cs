using System.Collections.Generic;


namespace AutomotiveSols.BLL.Models
{
    public class Transmission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<Trim> Trims { get; set; }
        public List<Car> Cars { get; set; }

    }
}
