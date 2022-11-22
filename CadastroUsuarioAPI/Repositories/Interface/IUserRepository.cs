using CadastroUsuarioAPI.Models;

namespace CadastroUsuarioAPI.Repositories.Interface
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();

        public User CreateUser(User user);

        public User UpdateUser(User user);

        public bool DeleteUser(int userId);
    }
}
