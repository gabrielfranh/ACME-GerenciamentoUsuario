using CadastroUsuarioAPI.DTO.Usuario;

namespace CadastroUsuarioAPI.Services.Interface
{
    public interface IUserService
    {
        public Task<UsuarioDTO> GetUserById(int userId);

        public Task<UsuarioDTO> CreateUser(CriaUsuarioDTO user);

        public Task<bool?> UpdateUser(AtualizaUsuarioDTO user);

        public Task<bool?> DeleteUser(int userId);

        public Task<(UsuarioDTO usuario, string token)?> Authenticate(LoginDTO login);
    }
}
