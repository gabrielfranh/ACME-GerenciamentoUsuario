using AutoMapper;
using CadastroUsuarioAPI.Context;
using CadastroUsuarioAPI.Models;
using CadastroUsuarioAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarioAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _mySQLContext;

        public UserRepository(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }

        public async Task<Usuario> CreateUser(Usuario usuario)
        {
            await _mySQLContext.Usuarios.AddAsync(usuario);
            await _mySQLContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> UpdateUser(Usuario usuario)
        {
            try
            {
                _mySQLContext.Usuarios.Update(usuario);
                await _mySQLContext.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(Usuario usuario)
        {
            try
            {
                _mySQLContext.Usuarios.Remove(usuario);
                await _mySQLContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Usuario> GetUserById(int userId)
        {
            var user = await _mySQLContext.Usuarios.FirstOrDefaultAsync(user => user.Id == userId);
            return user;
        }

        public async Task<Usuario> GetUserByUsername(string userName)
        {
            var user = await _mySQLContext.Usuarios.FirstOrDefaultAsync(x => x.Username == userName);
            return user;
        }
    }
}
