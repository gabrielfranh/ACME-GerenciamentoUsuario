using CadastroUsuarioAPI.Models;

namespace CadastroUsuarioAPI.Services.Interface
{
    public interface IUserService
    {
        public IEnumerable<User> GetUsers();

        public User CreateUser(User user);

        public bool UpdateUser(User user);

        public bool DeleteUser(int userId);
    }
}
