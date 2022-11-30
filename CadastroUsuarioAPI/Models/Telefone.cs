using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroUsuarioAPI.Models
{
    [Table("telefone")]
    public class Telefone
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Column("ddd")]
        [Required]
        public string Ddd { get; set; }

        [Column("numerotelefone")]
        [Required]
        public string NumeroTelefone { get; set; }
    }
}
