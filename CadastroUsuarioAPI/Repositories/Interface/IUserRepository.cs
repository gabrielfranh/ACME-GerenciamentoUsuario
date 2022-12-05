using CadastroUsuarioAPI.DTO.Usuario;
using CadastroUsuarioAPI.Models;

namespace CadastroUsuarioAPI.Repositories.Interface
{
    public interface IUserRepository
    {
        public Task<Usuario> CreateUser(Usuario usuario);

        public Task<bool> UpdateUser(Usuario usuario);

        public Task<bool> DeleteUser(Usuario usuario);

        public Task<Usuario> GetUserById(int userId);
    }
}
