using CadastroUsuarioAPI.Models;
using CadastroUsuarioAPI.Repositories.Interface;

namespace CadastroUsuarioAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
