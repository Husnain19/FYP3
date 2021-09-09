using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Services> Services { get; set; }
    }
}
