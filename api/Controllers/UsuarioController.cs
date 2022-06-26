using api.Interfaces.Servico;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController, Route("v1")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpGet, Route("usuario")]
        public async Task<IActionResult> Usuario()
        {
            try
            {
                var usuarios = await _usuarioServico.PegarTodosUsuariosAsync();
                if (usuarios == null) return NoContent();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpGet, Route("usuario/{id}")]
        public async Task<IActionResult> Usuario(int id)
        {
            try
            {
                var usuario = await _usuarioServico.PegarUsuarioPorIdAsync(id);
                if (usuario == null) return NoContent();
                
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }
    }
}
