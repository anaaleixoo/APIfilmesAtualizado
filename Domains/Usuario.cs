using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Filmes_SENAI.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]

    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage ="O nome é obrigatório!")]
     
        public string? Nome { get; set; }

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage = "O e-mail é obrigatório!")]

        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha é obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage ="A senha deve ter no mínimo 10 caracteres e no máximo 60")]

        public string? Senha { get; set; }
    }
}
