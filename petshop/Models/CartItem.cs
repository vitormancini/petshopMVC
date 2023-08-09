using System.ComponentModel.DataAnnotations;

namespace petshop.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [StringLength(200)]
        [Required]
        public string CartId { get; set; }
    }
}
