using AutoMapper;
using CadastroUsuarioAPI.Context;
using CadastroUsuarioAPI.DTO;
using CadastroUsuarioAPI.Models;
using CadastroUsuarioAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarioAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _mySQLContext;
        private readonly IMapper _mapper;

        public UserRepository(MySQLContext mySQLContext, IMapper mapper)
        {
            _mySQLContext = mySQLContext;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> CreateUser(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            await _mySQLContext.Usuarios.AddAsync(usuario);
            await _mySQLContext.SaveChangesAsync();
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<bool> UpdateUser(UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDTO);
                _mySQLContext.Usuarios.Update(usuario);
                await _mySQLContext.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var usuario = await _mySQLContext.Usuarios.Where(p => p.Id == userId).FirstOrDefaultAsync();

                if (usuario == null)
                    return false;
                
                _mySQLContext.Usuarios.Remove(usuario);
                await _mySQLContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<UsuarioDTO> GetUserById(int userId)
        {
            var user = await _mySQLContext.Usuarios.FirstOrDefaultAsync(user => user.Id == userId);
            return _mapper.Map<UsuarioDTO>(user);
        }
    }
}
