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

        public Usuario CreateUser(Usuario usuario)
        {
            _mySQLContext.Usuarios.Add(usuario);
            _mySQLContext.SaveChanges();
            return usuario;
        }

        public bool UpdateUser(Usuario usuario)
        {
            try
            {
                _mySQLContext.Usuarios.Update(usuario);
                _mySQLContext.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(Usuario usuario)
        {
            try
            {
                _mySQLContext.Usuarios.Remove(usuario);
                _mySQLContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Usuario GetUserById(int userId)
        {
            var user = _mySQLContext.Usuarios.FirstOrDefault(user => user.Id == userId);
            return user;
        }

        public Usuario GetUserByUsername(string userName)
        {
            var user = _mySQLContext.Usuarios.FirstOrDefault(x => x.Username == userName);
            return user;
        }
    }
}
