using CadastroUsuarioAPI.DTO.Usuario;
using CadastroUsuarioAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuarioAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] LoginDTO login)
        {
            try
            {
                var usuario = _userService.Authenticate(login);
                if (usuario == null) return NotFound("Usuário ou senha inválidos");
                return Ok(new
                {
                    usuario = usuario.Value.usuario,
                    token = usuario.Value.token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
