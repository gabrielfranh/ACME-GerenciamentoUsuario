using CadastroUsuarioAPI.Models;
using CadastroUsuarioAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsuarioController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public DefaultResponse GetUsers()
        {
            _userService.GetUsers();
        }

        [HttpPost]
        public DefaultResponse CreateUser([FromBody] User user)
        {
            if (user == null)
                return new DefaultResponse() {
                    HttpStatusCode = 400,
                    Object = BadRequest()
                };

            _userService.CreateUser(user);
        }

        [HttpPut]
        public DefaultResponse UpdateUser([FromBody] User user)
        {
            if (user == null)
                return new DefaultResponse()
                {
                    HttpStatusCode = 400,
                    Object = BadRequest()
                };

            _userService.UpdateUser(user);
        }

        [HttpDelete]
        public bool DefaultResponse(int userId)
        {
            _userService.DeleteUser(userId);
        }
    }
}