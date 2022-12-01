using CadastroUsuarioAPI.DTO;

namespace CadastroUsuarioAPI.Services.Interface
{
    public interface IUserService
    {
        public Task<UsuarioDTO> GetUserById(int userId);

        public Task<UsuarioDTO> CreateUser(UsuarioDTO user);

        public Task<bool> UpdateUser(UsuarioDTO user);

        public Task<bool> DeleteUser(int userId);
    }
}
