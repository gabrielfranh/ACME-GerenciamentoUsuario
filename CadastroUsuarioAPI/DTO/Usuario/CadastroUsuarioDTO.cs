using System.ComponentModel.DataAnnotations;

namespace CadastroUsuarioAPI.DTO.Usuario
{
    public class CriaUsuarioDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 9)]
        public string RG { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(CriaUsuarioDTO.Senha))]
        public string ConfirmaSenha { get; set; }
    }
}
