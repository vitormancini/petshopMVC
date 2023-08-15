using System.ComponentModel.DataAnnotations.Schema;

namespace petshop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
