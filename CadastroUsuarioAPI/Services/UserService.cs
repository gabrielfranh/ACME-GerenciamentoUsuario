using AutoMapper;
using CadastroUsuarioAPI.DTO.Usuario;
using CadastroUsuarioAPI.Models;
using CadastroUsuarioAPI.Utils;
using CadastroUsuarioAPI.Repositories.Interface;
using CadastroUsuarioAPI.Services.Interface;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace CadastroUsuarioAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly TokenUtils _tokenUtils;
        private RabbitMQService _rabbitMQService;

        public UserService(IUserRepository userRepository, IMapper mapper, TokenUtils tokenUtils)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenUtils = tokenUtils;
        }

        public UsuarioDTO CreateUser(CriaUsuarioDTO criaUsuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(criaUsuarioDto);

            var salt = SenhaUtils.GerarSalt();
            var hash = SenhaUtils.GerarHash(criaUsuarioDto.Senha, salt);

            usuario.Senha = hash;
            usuario.Salt = SenhaUtils.ToString(salt);
            usuario.Role = UsuarioUtils.Role.Confirmed.ToString();

            _userRepository.CreateUser(usuario);
            var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);

            if (_rabbitMQService == null)
                _rabbitMQService = new RabbitMQService("localhost");

            _rabbitMQService.RabbitMQBasicPublish("createUser", criaUsuarioDto);

            return usuarioDto;
        }

        public bool? UpdateUser(int userId, AtualizaUsuarioDTO atualizaUsuarioDTO)
        {
            var usuario = _userRepository.GetUserById(userId);

            if (usuario is null) return null;

            atualizaUsuarioDTO.Copy(usuario);
            var usuarioAtualizado = _userRepository.UpdateUser(usuario);

            if (_rabbitMQService == null)
                _rabbitMQService = new RabbitMQService("localhost");

            _rabbitMQService.RabbitMQBasicPublish("createUser", atualizaUsuarioDTO);

            return usuarioAtualizado;
        }

        public bool? DeleteUser(int userId)
        {
            var usuario = _userRepository.GetUserById(userId);
            if (usuario is null) return null;
            var usuarioDeletado = _userRepository.DeleteUser(usuario);

            if (_rabbitMQService == null)
                _rabbitMQService = new RabbitMQService("localhost");

            _rabbitMQService.RabbitMQBasicPublish("createUser", userId);

            return usuarioDeletado;
        }

        public UsuarioDTO GetUserById(int userId)
        {
            var usuario = _userRepository.GetUserById(userId);
            if (usuario is null) return null;
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return usuarioDTO;
        }

        public (UsuarioDTO usuario, string token)? Authenticate(LoginDTO login)
        {
            var usuario = _userRepository.GetUserByUsername(login.Username);
            if (usuario is null) return null;
            var salt = SenhaUtils.ToByte(usuario.Salt);
            var senhaHash = SenhaUtils.GerarHash(login.Senha, salt);
            if (senhaHash != usuario.Senha) return null;
            var token = _tokenUtils.Gerar(usuario);
            var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);
            return (usuarioDto, token);
        }
    }
}
