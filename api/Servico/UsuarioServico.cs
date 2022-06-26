using api.Entidades;
using api.Interfaces.Repositorio;
using api.Interfaces.Servico;

namespace api.Servico
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usarioRepositorio)
        {
            _usarioRepositorio = usarioRepositorio;
        }

        public async Task<Usuario[]> PegarTodosUsuariosAsync()
        {
            try
            {
                var usuarios = await _usarioRepositorio.PegarTodasAsync();
                if (usuarios == null) return null;
                
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> PegarUsuarioPorIdAsync(int id)
        {
            try
            {
                var usuario = await _usarioRepositorio.PegarPorIdAsync(id);
                if (usuario == null) return null;
                
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
