using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Filmes_SENAI.Domains
{
    [Table("Genero")]
    public class Genero
    {
        [Key]
        public Guid IdGenero { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "Nome do Gênero é obrigatório!")]

        public string? Nome { get; set; }
    }
}
