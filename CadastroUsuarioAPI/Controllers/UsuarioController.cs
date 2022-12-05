using CadastroUsuarioAPI.DTO.Usuario;
using CadastroUsuarioAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuarioAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsuarioController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                var user = await _userService.GetUserById(userId);

                if (user == null) return NotFound();

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
        public async Task<IActionResult> CreateUser([FromBody] CriaUsuarioDTO user)
        {
            try
            {
                var usuarioCriado = await _userService.CreateUser(user);
                return Created(uri: $"v1/Usuario/{usuarioCriado.Id}", usuarioCriado);
            }
            catch(Exception ex){
                return BadRequest(new {
                    message = ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] AtualizaUsuarioDTO user)
        {
            try
            {
                var userUpdated = await _userService.UpdateUser(user);

                if(userUpdated is null) return NotFound();

                if(userUpdated.Value) return NoContent();
                
                return  StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch(Exception ex){
                return BadRequest(new {
                    message = ex.Message
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {
            try
            {
                var userDeleted = await _userService.DeleteUser(userId);

                if (userDeleted is null) return NotFound();
                
                if(userDeleted.Value) return NoContent();

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