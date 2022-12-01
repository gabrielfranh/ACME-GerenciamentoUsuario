using CadastroUsuarioAPI.DTO;
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
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsers();
                return Ok(users);
            }
            catch(Exception ex){
                return BadRequest(new {
                    message = ex.Message
                });
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                var user = await _userService.GetUserById(userId);
                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(new {
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UsuarioDTO user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                var userCreated = await _userService.CreateUser(user);
                return Ok(userCreated);
            }
            catch(Exception ex){
                return BadRequest(new {
                    message = ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UsuarioDTO user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                var userUpdated = await _userService.UpdateUser(user);

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
        public async Task<IActionResult> DefaultResponse(int userId)
        {
            try
            {
                var userDeleted = await _userService.DeleteUser(userId);
                
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