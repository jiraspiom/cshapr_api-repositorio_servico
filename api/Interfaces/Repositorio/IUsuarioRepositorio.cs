using api.Entidades;

namespace api.Interfaces.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario[]> PegarTodasAsync();
        Task<Usuario> PegarPorIdAsync(int id);
    }
}
