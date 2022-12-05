using System.ComponentModel.DataAnnotations;

namespace CadastroUsuarioAPI.DTO.Usuario
{
    public class AtualizaUsuarioDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(AtualizaUsuarioDTO.Senha))]
        public string ConfirmaSenha { get; set; }
    }
}
