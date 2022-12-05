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

        [Column("RG")]
        [Required]
        public string RG { get; set; }
        
        [Column("CPF")]
        [Required]
        public string CPF { get; set; }

        [Column("senha")]
        [Required]
        public string Senha { get; set; }

        [Column("salt")]
        [Required]
        public string Salt { get; set; }

        public string Role { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
