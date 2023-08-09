using System.ComponentModel.DataAnnotations;

namespace petshop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da categoria é obrigatório")]
        [Display(Name = "Informe o nome da categoria")]
        [MinLength(3, ErrorMessage = "Nome deve ter pelo menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        [Display(Name = "Informe o nome do produto")]
        [MinLength(3, ErrorMessage = "Nome deve ter pelo menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
