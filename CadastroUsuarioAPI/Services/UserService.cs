using AutoMapper;
using CadastroUsuarioAPI.DTO.Usuario;
using CadastroUsuarioAPI.Models;
using CadastroUsuarioAPI.Utils;
using CadastroUsuarioAPI.Repositories.Interface;
using CadastroUsuarioAPI.Services.Interface;

namespace CadastroUsuarioAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> CreateUser(CriaUsuarioDTO criaUsuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(criaUsuarioDto);

            var salt = SenhaUtils.GerarSalt();
            var hash = SenhaUtils.GerarHash(criaUsuarioDto.Senha, salt);

            usuario.Senha = hash;
            usuario.Salt = SenhaUtils.ToString(salt);
            usuario.Role = UsuarioUtils.Role.Unconfirmed.ToString();

            await _userRepository.CreateUser(usuario);
            var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);
            return usuarioDto;
        }

        public async Task<bool?> UpdateUser(int userId, AtualizaUsuarioDTO atualizaUsuarioDTO)
        {
            var usuario = await _userRepository.GetUserById(userId);

            if (usuario is null) return null;

            atualizaUsuarioDTO.Copy(usuario);
            var usuarioAtualizado = await _userRepository.UpdateUser(usuario);
            return usuarioAtualizado;
        }

        public async Task<bool?> DeleteUser(int userId)
        {
            var usuario = await _userRepository.GetUserById(userId);
            if (usuario is null) return null;
            var usuarioDeletado = await _userRepository.DeleteUser(usuario);
            return usuarioDeletado;
        }

        public async Task<UsuarioDTO> GetUserById(int userId)
        {
            var usuario = await _userRepository.GetUserById(userId);
            if (usuario is null) return null;
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return usuarioDTO;
        }

        public async Task<(UsuarioDTO usuario, string token)?> Authenticate(LoginDTO login)
        {
            var usuario = await _userRepository.GetUserByUsername(login.Username);
            if (usuario is null) return null;
            var salt = SenhaUtils.ToByte(usuario.Salt);
            var senhaHash = SenhaUtils.GerarHash(login.Senha, salt);
            if (senhaHash != usuario.Senha) return null;
            var token = TokenUtils.Gerar(usuario);
            var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);
            return (usuarioDto, token);
        }
    }
}
