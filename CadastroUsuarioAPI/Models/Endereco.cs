using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroUsuarioAPI.Models
{
    [Table("endereco")]
    public class Endereco
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Column("logradouro")]
        [Required]
        public string Logradouro { get; set; }

        [Column("bairro")]
        [Required]
        public string Bairro { get; set; }

        [Column("cidade")]
        [Required]
        public string Cidade { get; set; }

        [Column("cep")]
        [Required]
        public string Cep { get; set; }
    }
}
