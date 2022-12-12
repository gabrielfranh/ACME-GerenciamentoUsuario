using CadastroUsuarioAPI.DTO.Usuario;
using CadastroUsuarioAPI.Services.Interface;
using CadastroUsuarioAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet]
        [Authorize(Roles = "Administrator,Confirmed,Unconfirmed")]
        public IActionResult GetUserById()
        {
            try
            {
                var userId = GetUserId();
                var user = _userService.GetUserById(userId);

                if (user == null) return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new {
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] CriaUsuarioDTO user)
        {
            try
            {
                var usuarioCriado = _userService.CreateUser(user);
                return Created(uri: $"v1/Usuario/{usuarioCriado.Id}", usuarioCriado);
            }
            catch (Exception ex) {
                return BadRequest(new {
                    message = ex.Message
                });
            }
        }

        [HttpPut]
        [Authorize(Roles = "Administrator,Confirmed")]
        public IActionResult UpdateUser([FromBody] AtualizaUsuarioDTO user)
        {
            try
            {
                var userId = GetUserId();

                var userUpdated = _userService.UpdateUser(userId, user);

                if (userUpdated is null) return NotFound();

                if (userUpdated.Value) return NoContent();

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex) {
                return BadRequest(new {
                    message = ex.Message
                });
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete()
        {
            try
            {
                var userId = GetUserId();

                var userDeleted = _userService.DeleteUser(userId);

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

        private int GetUserId()
        {
            var userClaimName = User.Claims.Where(claim => claim.Type.Equals(TokenUtils.ClaimUserId)).First();

            var userId = Convert.ToInt32(userClaimName.Value);

            return userId;
        }
    }
}