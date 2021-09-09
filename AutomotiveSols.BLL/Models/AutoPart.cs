using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutomotiveSols.BLL.Models
{
   public class AutoPart
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
       // [Required]
        [Range(1, 10000)]
        public double Price50 { get; set; }
       // [Required]
        [Range(1, 10000)]
        public double Price100 { get; set; }
       // [Required]
        public int CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        public  Category Category { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

       // [ForeignKey("SubCategoryId")]
        public  SubCategory SubCategory { get; set; }

        public string Description { get; set; }

        public string SellerComments { get; set; }

        public string MainImageUrl { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public bool Status { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } 

        public List<ShoppingCart> ShoppingCarts { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
        public List<PartGallery> PartGalleries { get; set; }

        //  public ICollection<PartGallery> PartGallery { get; set; }

    }
}
