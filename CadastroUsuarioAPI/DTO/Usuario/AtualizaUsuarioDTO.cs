using System.ComponentModel.DataAnnotations;

namespace CadastroUsuarioAPI.DTO.Usuario
{
    public class AtualizaUsuarioDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
