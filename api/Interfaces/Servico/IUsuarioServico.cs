using api.Entidades;

namespace api.Interfaces.Servico
{
    public interface IUsuarioServico
    {
        Task<Usuario[]> PegarTodosUsuariosAsync();
        Task<Usuario> PegarUsuarioPorIdAsync(int id);
    }
}