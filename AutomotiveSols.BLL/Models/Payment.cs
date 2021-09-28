using System;
using System.Collections.Generic;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
   public class Payment
    {
        public int Id { get; set; }
        public string PaymentImage { get; set; }
        public int? CarId { get; set; }
        public Car Car { get; set; }
    }
}
