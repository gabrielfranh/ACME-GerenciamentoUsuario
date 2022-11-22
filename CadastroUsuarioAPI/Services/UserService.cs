using CadastroUsuarioAPI.Models;
using CadastroUsuarioAPI.Services.Interface;

namespace CadastroUsuarioAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserService _userRepository;

        public UserService(IUserService userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public User UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public bool DeleteUser(int userId)
        {
            return _userRepository.DeleteUser(userId);
        }
    }
}
