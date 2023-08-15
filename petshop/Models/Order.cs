using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace petshop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Informe seu nome completo")]
        [MinLength(3)]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string State { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public int TotalOrderItems { get; set; }
        public DateTime OrderSent { get; set; }
        public DateTime? OrderReceived { get; set; }
        public List<OrderDetail> CartItems { get; set; }
    }
}
