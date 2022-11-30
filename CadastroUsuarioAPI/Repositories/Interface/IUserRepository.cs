using CadastroUsuarioAPI.DTO;

namespace CadastroUsuarioAPI.Repositories.Interface
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UsuarioDTO>> GetUsers();

        public Task<UsuarioDTO> CreateUser(UsuarioDTO usuarioDTO);

        public Task<UsuarioDTO> UpdateUser(UsuarioDTO usuarioDTO);

        public Task<bool> DeleteUser(int userId);
    }
}
