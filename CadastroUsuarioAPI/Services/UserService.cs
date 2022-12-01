using CadastroUsuarioAPI.DTO;
using CadastroUsuarioAPI.Repositories.Interface;
using CadastroUsuarioAPI.Services.Interface;

namespace CadastroUsuarioAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<UsuarioDTO> CreateUser(UsuarioDTO user)
        {
            return await _userRepository.CreateUser(user);
        }

        public async Task<bool> UpdateUser(UsuarioDTO user)
        {
            return await _userRepository.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            return await _userRepository.DeleteUser(userId);
        }

        public async Task<UsuarioDTO> GetUserById(int userId)
        {
            return await _userRepository.GetUserById(userId);
        }
    }
}
