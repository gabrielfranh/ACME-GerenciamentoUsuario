using CadastroUsuarioAPI.DTO;

namespace CadastroUsuarioAPI.Services.Interface
{
    public interface IUserService
    {
        public Task<IEnumerable<UsuarioDTO>> GetUsers();

        public Task<UsuarioDTO> CreateUser(UsuarioDTO user);

        public Task<UsuarioDTO> UpdateUser(UsuarioDTO user);

        public Task<bool> DeleteUser(int userId);
    }
}
