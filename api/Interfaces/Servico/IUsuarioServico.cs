using api.Entidades;

namespace api.Interfaces.Servico
{
    public interface IUsuarioServico
    {
        Task<Usuario> AdicionarUsuario(Usuario usuario);
        Task<Usuario> AtualizarUsuario(Usuario usuario);
        Task<bool> DeletarUsuario(int usuarioId);

        Task<Usuario[]> PegarTodosUsuariosAsync();
        Task<Usuario> PegarUsuarioPorIdAsync(int id);
    }
}