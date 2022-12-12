using CadastroUsuarioAPI.DTO.Usuario;
using CadastroUsuarioAPI.Models;

namespace CadastroUsuarioAPI.Repositories.Interface
{
    public interface IUserRepository
    {
        public Usuario CreateUser(Usuario usuario);

        public bool UpdateUser(Usuario usuario);

        public bool DeleteUser(Usuario usuario);

        public Usuario GetUserById(int userId);

        public Usuario GetUserByUsername(string userName);
    }
}
