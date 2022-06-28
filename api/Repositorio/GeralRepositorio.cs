using api.Data;
using api.Interfaces.Repositorio;

namespace api.Repositorio
{
    public class GeralRepositorio : IGeralRepositorio
    {
        private readonly Contexto _contexto;

        public GeralRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar<T>(T entity) where T : class
        {
            _contexto.Add(entity);
        }

        public void Atualizar<T>(T entinty) where T : class
        {
            _contexto.Update(entinty);
        }

        public void Deletar<T>(T entinty) where T : class
        {
            _contexto.Remove(entinty);
        }

        public void DeletarVarias<T>(T[] entinty) where T : class
        {
            _contexto.RemoveRange(entinty);
        }

        public async Task<bool> SalvarMudancasAsync()
        {
            return (await _contexto.SaveChangesAsync()) > 0;
        }
    }
}
