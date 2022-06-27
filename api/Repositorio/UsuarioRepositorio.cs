using api.Data;
using api.Entidades;
using api.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace api.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _contexto;
        public UsuarioRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Usuario[]> PegarTodasAsync()
        {
            IQueryable<Usuario> query = _contexto.Usuarios;

            query = query.AsNoTracking()
                         .OrderBy(ativ => ativ.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Usuario> PegarPorIdAsync(int id)
        {
            IQueryable<Usuario> query = _contexto.Usuarios;

            query = query.AsNoTracking()
                         .OrderBy(o => o.Id)
                         .Where(a => a.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
