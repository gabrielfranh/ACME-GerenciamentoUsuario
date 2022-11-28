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
        public IActionResult GetUsers()
        {
            try{
                var users = _userService.GetUsers();
                return Ok(users);
            }
            catch(Exception ex){
                return BadRequest(new {
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            try{
                if (user == null)
                    return BadRequest();

                var userCreated = _userService.CreateUser(user);
                return Ok(userCreated);
            }
            catch(Exception ex){
                return BadRequest(new {
                    message = ex.Message
                });
            }
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try{
                if (user == null)
                    return BadRequest();

                var userUpdated = _userService.UpdateUser(user);
                
                if(userUpdated)
                    return NoContent();
                
                return  StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch(Exception ex){
                return BadRequest(new {
                    message = ex.Message
                });
            }
        }

        [HttpDelete]
        public IActionResult DefaultResponse(int userId)
        {
            try{
                var userDeleted = _userService.DeleteUser(userId);
                
                if(userDeleted)
                    return NoContent();

                return  StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch(Exception ex){
                return BadRequest(new {
                    message = ex.Message
                });
            }
        }
    }
}