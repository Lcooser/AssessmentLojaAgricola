using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgricolaLoja.Models
{
    public class ProdutosModel
    {

       

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a categoria do produto")]
        public string Categoria { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite o valor do produto")]
        public decimal Valor { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset DataDeLancamento { get; set; } = DateTimeOffset.UtcNow;

       

        
    }
}
