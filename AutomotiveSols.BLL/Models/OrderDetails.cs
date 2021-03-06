using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderHeader OrderHeader { get; set; }


       [Required]
        public int AutoPartId { get; set; }
        [ForeignKey("AutoPartId")]
        public AutoPart AutoPart { get; set; }

        public int Count { get; set; }
        public double Price { get; set; }
    }
}
