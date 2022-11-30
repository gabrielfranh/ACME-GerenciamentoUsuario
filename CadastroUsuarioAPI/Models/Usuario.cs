using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroUsuarioAPI.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        [Required]
        public string Username { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("nome")]
        [Required]
        public string Nome { get; set; }

        [Column("dataNascimento")]
        [Required]
        public DateTime DataNascimento { get; set; }

        [Column("documento")]
        [Required]
        public string Documento { get; set; }

        [Column("senha")]
        [Required]
        public byte[]? SenhaHash { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
