using api.Entidades;
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

        [HttpPost]
        [Route("usuario")]
        public async Task<IActionResult> Post(Usuario model)
        {
            try
            {
                var usuario = await _usuarioServico.AdicionarUsuario(model);
                if (usuario == null) return NoContent();

                return Ok(usuario);
                    
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("usuario/{id}")]
        public async Task<IActionResult> Update(int id, Usuario model)
        {
            try
            {
                if (model.Id != id)
                    this.StatusCode(StatusCodes.Status409Conflict, "usuario errado");
                
                var usuario = await _usuarioServico.AtualizarUsuario(model);
                if(usuario == null) return NoContent();
                
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var atividade = await _usuarioServico.PegarUsuarioPorIdAsync(id);
                if (atividade == null)
                    this.StatusCode(StatusCodes.Status409Conflict,
                        "Você está tentando deletar um usuario que não existe");

                if (await _usuarioServico.DeletarUsuario(id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    return BadRequest("Ocorreu um problema não específico ao tentar deletar o usuario.");
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar usuario com id: ${id}. Erro: {ex.Message}");
            }
        }

    }
}
