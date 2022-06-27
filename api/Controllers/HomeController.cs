using api.Data;
using api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("V2")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("sobre")]
        public async Task<IActionResult> Index()
        {
            return Ok("Testando asNotraking");
        }

        [HttpGet]
        [Route("consultaAsNoTraking")]
        public async Task<IActionResult> Consulta(
            [FromServices] Contexto contexto)
        {
            var curso = contexto.Cursos
                .Include(p => p.Instrutor)
                //.AsNoTracking()                       // a memoria fica com 1000 cursos e 1000 instrutor
                .AsNoTrackingWithIdentityResolution()   // a memoria fica com 1000 cursos e 1 instrutor
                .ToList();

            return Ok(curso);
        }


        [HttpGet]
        [Route("SetupAdd1000Registro")]
        public async Task<IActionResult> Setup(
            [FromServices] Contexto contexto)
        {
            try
            {
                var instrutor = new Instrutor
                {
                    Nome = "Instrutor 01",
                    Cursos = Enumerable.Range(1, 1000)
                                       .Select(c =>
                                           new Curso
                                           {
                                               Descricao = $"Curso - {c}"
                                           }).ToArray()
                };

                contexto.Add(instrutor);
                await contexto.SaveChangesAsync();

                return Ok("1000 registro criados");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes
                    .Status500InternalServerError, $"erro: {ex.Message}");
            }
        }
    }
}
