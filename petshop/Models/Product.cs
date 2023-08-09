using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace petshop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o nome do produto")]
        [Display(Name = "Nome do produto")]
        [MinLength(5, ErrorMessage = "Nome do produto deve possuir pelo menos 5 caracteres")]
        [MaxLength(30, ErrorMessage = "Nome do produto deve possuir no máximo 30 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "É obrigatório informar uma breve descrição do produto")]
        [Display(Name = "Descrição curta")]
        [MinLength(5, ErrorMessage = "A descrição deve possuir pelo menos 5 caracteres")]
        [MaxLength(30, ErrorMessage = "A descrição deve possuir no máximo 30 caracteres")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a descrição do produto")]
        [Display(Name = "Descrição longa")]
        [MinLength(5, ErrorMessage = "A descrição deve possuir pelo menos 5 caracteres")]
        [MaxLength(200, ErrorMessage = "A descrição deve possuir no máximo 200 caracteres")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o preço do produto")]
        [Display(Name = "Informe o preço do produto")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.1,999.99, ErrorMessage = "O preço deve ser de 0 a 999.99 ")]
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public bool Highlighted { get; set; }
        public bool Available { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
