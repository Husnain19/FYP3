
namespace AutomotiveSols.BLL.Models
{
   public class Payment
    {
        public int Id { get; set; }
        public string PaymentImage { get; set; }
        public int? CarId { get; set; }
        public bool? Status { get; set; }
        public Car Car { get; set; }
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}