using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveSols.Models
{
    public class OrderHistory
    {
        public DateTime OrderDate { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string Email { get; set; }
    }
}
