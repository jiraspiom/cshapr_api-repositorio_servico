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

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            if(await _usarioRepositorio.PegarPorIdAsync(usuario.Id) == null)
            {
                _usarioRepositorio.Adicionar(usuario);
                if (await _usarioRepositorio.SalvarMudancasAsync())
                    return usuario;
            }

            return null;
        }

        public async Task<Usuario> AtualizarUsuario(Usuario usuario)
        {
            if(await _usarioRepositorio.PegarPorIdAsync(usuario.Id) != null)
            {
                _usarioRepositorio.Atualizar(usuario);
                if (await _usarioRepositorio.SalvarMudancasAsync())
                    return usuario;
            }

            return null;
        }

        public async Task<bool> DeletarUsuario(int usuarioId)
        {
            var usuario = await _usarioRepositorio.PegarPorIdAsync(usuarioId);
            if ( usuario == null)
                throw new Exception("usuario nao existe");
            
            _usarioRepositorio.Deletar(usuario);
            return await _usarioRepositorio.SalvarMudancasAsync();
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
