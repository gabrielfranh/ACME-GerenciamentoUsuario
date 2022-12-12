using CadastroUsuarioAPI.DTO.Usuario;

namespace CadastroUsuarioAPI.Services.Interface
{
    public interface IUserService
    {
        public UsuarioDTO GetUserById(int userId);

        public UsuarioDTO CreateUser(CriaUsuarioDTO user);

        public bool? UpdateUser(int userId, AtualizaUsuarioDTO user);

        public bool? DeleteUser(int userId);

        public (UsuarioDTO usuario, string token)? Authenticate(LoginDTO login);
    }
}
